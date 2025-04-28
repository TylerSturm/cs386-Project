using NUnit.Framework;
using UnityEngine;

public class BlackjackWhiteBoxTests
{
    private Blackjack blackjack;

    [SetUp]
    public void Setup()
    {
        GameObject testObject = new GameObject("BlackjackWhiteBoxTestObject");
        blackjack = testObject.AddComponent<Blackjack>();

        // Skip Unity's Start method randomness by directly setting up player and dealer totals
        blackjack.playerTotal = 0;
        blackjack.dealerTotal = 0;
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(blackjack.gameObject);
    }

    [Test]
    public void DealerTurn_PlayerWins_WhenDealerBusts()
    {
        // Arrange
        blackjack.playerTotal = 18;
        blackjack.dealerTotal = 16;
        blackjack.cover = new GameObject(); // Dummy cover so Destroy doesn't crash

        blackjack.dealerTotal += 10; // Force dealer to bust (16 + 10 = 26)
        // Act
        CallDealerTurn();

        // Assert
        Assert.IsTrue(blackjack.playerWin, "Expected player to win when dealer busts");
    }

    [Test]
    public void DealerTurn_PlayerLoses_WhenDealerBeatsPlayer()
    {
        // Arrange
        blackjack.playerTotal = 17;
        blackjack.dealerTotal = 19;
        blackjack.cover = new GameObject();

        // Act
        CallDealerTurn();

        // Assert
        Assert.IsFalse(blackjack.playerWin, "Expected player to lose when dealer has higher total");
    }

    [Test]
    public void DealerTurn_PlayerTies_WhenEqualTotals()
    {
        // Arrange
        blackjack.playerTotal = 18;
        blackjack.dealerTotal = 18;
        blackjack.cover = new GameObject();

        // Act
        CallDealerTurn();

        // Assert
        Assert.IsFalse(blackjack.playerWin, "Expected tie results in playerWin = false");
    }

    private void CallDealerTurn()
    {
        // Directly call dealerTurn using Reflection because it is private
        var method = typeof(Blackjack).GetMethod("dealerTurn", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        method.Invoke(blackjack, null);
    }
}
