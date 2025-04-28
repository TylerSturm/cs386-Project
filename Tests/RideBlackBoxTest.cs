using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RideBlackBoxTest
{
    private GameObject testObject;
    private Ride ride;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        testObject = new GameObject("RideTestObject");
        ride = testObject.AddComponent<Ride>();

        yield return null; // Wait for Unity to auto-call Start()
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        Object.Destroy(testObject);
        yield return null;
    }

    [UnityTest]
    public IEnumerator AcceptanceTest_PlayerGuessesCorrectColor()
    {
        yield return null; // Let Start() happen

        // 💥 IMPORTANT: Force clean setup
        SetPrivateField("drawnCards", new System.Collections.Generic.List<CardInfo> {
            new CardInfo(7, 2) // Red card (Diamonds)
        });
        SetPrivateField("phase", 1);
        SetPrivateField("guessIndex", 0);
        SetPrivateField("isGameOver", false);

        // 💥 Directly simulate the player guessing red
        InvokePrivateMethod("colorGuess", "red");

        yield return new WaitForSeconds(0.1f);

        // 💥 Check the phase moved to 2 (player guessed correctly)
        int phase = GetPrivateField<int>("phase");
        Assert.AreEqual(2, phase);

        // 💥 Check that game did not end
        bool isGameOver = GetPrivateField<bool>("isGameOver");
        Assert.IsFalse(isGameOver);
    }

    private void InvokePrivateMethod(string name, params object[] parameters)
    {
        typeof(Ride).GetMethod(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .Invoke(ride, parameters);
    }

    private void SetPrivateField<T>(string name, T value)
    {
        typeof(Ride).GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(ride, value);
    }

    private T GetPrivateField<T>(string name)
    {
        return (T)typeof(Ride).GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(ride);
    }
}
