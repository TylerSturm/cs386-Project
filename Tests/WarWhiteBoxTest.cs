using NUnit.Framework;
using UnityEngine;

public class WarWhiteBoxTests
{
    private TestableWar war;

    [SetUp]
    public void SetUp()
    {
        GameObject testObject = new GameObject("TestableWarWhiteBoxObject");
        war = testObject.AddComponent<TestableWar>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(war.gameObject);
    }

    [Test]
    public void CompareMethod_PlayerWins()
    {
        // Arrange
        war.playerWin = 0;
        war.dealerWin = 0;

        // Act
        war.FakeCompare(10, 5); // Controlled input via mock

        // Assert
        Assert.AreEqual(1, war.playerWin);
        Assert.AreEqual(0, war.dealerWin);
    }

    [Test]
    public void CompareMethod_DealerWins()
    {
        // Arrange
        war.playerWin = 0;
        war.dealerWin = 0;

        // Act
        war.FakeCompare(5, 10);

        // Assert
        Assert.AreEqual(0, war.playerWin);
        Assert.AreEqual(1, war.dealerWin);
    }
}
