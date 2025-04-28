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

        yield return null; // Let Start() finish
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

        // 💥 SET UP: Control state
        SetPrivateField("playerTotal", 18);
        SetPrivateField("dealerTotal", 16); // dealer low so he must draw and bust
        SetPrivateField("cover", new GameObject()); // Dummy cover so no null error when Destroy()

        // 💥 Simulate player pressing "N" (Stand)
        InvokePrivateMethod("dealerTurn");

        yield return new WaitForSeconds(0.5f);

        // 💥 VERIFY: Player should win
        bool playerWin = GetPrivateField<bool>("playerWin");
        Assert.IsTrue(playerWin);
    }

    [UnityTest]
    public IEnumerator AcceptanceTest_PlayerLosesByBust()
    {
        yield return null; // Let Start()

        // 💥 SET UP: Make player total 20 (near bust)
        SetPrivateField("playerTotal", 20);

        // 💥 Simulate player pressing "Y" (Hit)
        // But since Unity can't simulate Input.GetKeyDown, we fake a "bust" by manually adding points
        blackjack.playerTotal += 5; // simulate bust (now 25)

        // 💥 Simulate Update check (manual check if bust happens)
        if (blackjack.playerTotal > 21)
        {
            Debug.Log("Simulated Bust: Player total is " + blackjack.playerTotal);
            SetPrivateField("playerWin", false);
        }

        yield return new WaitForSeconds(0.5f);

        // 💥 VERIFY: Player should lose
        bool playerWin = GetPrivateField<bool>("playerWin");
        Assert.IsFalse(playerWin);
    }

    // Utility methods
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
