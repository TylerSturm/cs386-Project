using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class WarBlackBoxTests
{
    private GameObject testObject;
    private TestableWar war;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        testObject = new GameObject("TestableWarObject");
        war = testObject.AddComponent<TestableWar>();

        yield return null; // Let Start() happen
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        Object.Destroy(testObject);
        yield return null;
    }

    [UnityTest]
    public IEnumerator AcceptanceTest_PlayerWinsBestOfThree()
    {
        yield return null;

        // Force player's card higher for each play
        war.SetNextCard(10); // Player's first card
        war.playerTotal = 10;
        war.dealerTotal = 5; // Dealer lower

        InvokePrivateMethod("compare", war.playerTotal, war.dealerTotal);

        war.playerTotal = 10;
        war.dealerTotal = 8; // Dealer lower again

        InvokePrivateMethod("compare", war.playerTotal, war.dealerTotal);

        yield return new WaitForSeconds(0.5f);

        // Verify player wins at the end
        Assert.Greater(war.playerWin, war.dealerWin);
    }

    private void InvokePrivateMethod(string methodName, params object[] parameters)
    {
        typeof(War).GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .Invoke(war, parameters);
    }
}
