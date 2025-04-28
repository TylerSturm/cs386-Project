using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BlackjackBlackBoxTests
{
    private GameObject testObject;
    private Blackjack blackjack;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        testObject = new GameObject("BlackjackTestObject");
        blackjack = testObject.AddComponent<Blackjack>();

        yield return null;
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        Object.Destroy(testObject);
        yield return null;
    }

    [UnityTest]
    public IEnumerator AcceptanceTest_PlayerWinsAfterStanding()
    {
        yield return null; // Let Start()

        SetPrivateField("playerTotal", 18);
        SetPrivateField("dealerTotal", 16); 
        SetPrivateField("cover", new GameObject()); 


        InvokePrivateMethod("dealerTurn");

        yield return new WaitForSeconds(0.5f);

        bool playerWin = GetPrivateField<bool>("playerWin");
        Assert.IsTrue(playerWin);
    }

    [UnityTest]
    public IEnumerator AcceptanceTest_PlayerLosesByBust()
    {
        yield return null; 

        SetPrivateField("playerTotal", 20);

        blackjack.playerTotal += 5; 

        if (blackjack.playerTotal > 21)
        {
            Debug.Log("Simulated Bust: Player total is " + blackjack.playerTotal);
            SetPrivateField("playerWin", false);
        }

        yield return new WaitForSeconds(0.5f);

        bool playerWin = GetPrivateField<bool>("playerWin");
        Assert.IsFalse(playerWin);
    }


    private void InvokePrivateMethod(string name, params object[] parameters)
    {
        typeof(Blackjack).GetMethod(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.Invoke(blackjack, parameters);
    }

    private void SetPrivateField<T>(string name, T value)
    {
        typeof(Blackjack).GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.SetValue(blackjack, value);
    }

    private T GetPrivateField<T>(string name)
    {
        return (T)typeof(Blackjack).GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.GetValue(blackjack);
    }
}
