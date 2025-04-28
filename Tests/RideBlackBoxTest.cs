using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RideBlackBoxTests
{
    private GameObject testObject;
    private Ride ride;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        testObject = new GameObject("RideTestObject");
        ride = testObject.AddComponent<Ride>();
        yield return null; // Wait for Unity to call Start()
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        Object.DestroyImmediate(testObject);
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerCorrectlyGuessesColor_PhaseAdvances()
    {
        ride.SetUpNewRound(new CardInfo(7, 2)); // Diamonds = red
        yield return null;

        ride.GuessColor("red");
        yield return null;

        Assert.AreEqual(2, ride.CurrentPhase); // Should advance to phase 2
        Assert.IsFalse(ride.IsGameOver);
    }

    [UnityTest]
    public IEnumerator PlayerIncorrectlyGuessesColor_GameOver()
    {
        ride.SetUpNewRound(new CardInfo(7, 4)); // Spades = black
        yield return null;

        ride.GuessColor("red"); // Wrong guess
        yield return null;

        Assert.AreEqual(0, ride.CurrentPhase); // Likely reset
        Assert.IsTrue(ride.IsGameOver);
    }

    [UnityTest]
    public IEnumerator SetupCreatesStartingPhase()
    {
        ride.SetUpNewRound(new CardInfo(5, 1)); // Hearts = red
        yield return null;

        Assert.AreEqual(1, ride.CurrentPhase); // Should start at phase 1
    }

    [UnityTest]
    public IEnumerator GuessAfterGameOver_DoesNothing()
    {
        ride.SetUpNewRound(new CardInfo(10, 4)); // Spades = black
        yield return null;

        ride.GuessColor("red"); // Wrong guess
        yield return null;

        Assert.IsTrue(ride.IsGameOver);

        int oldPhase = ride.CurrentPhase;

        ride.GuessColor("black"); // Try to guess after losing
        yield return null;

        Assert.AreEqual(oldPhase, ride.CurrentPhase); // Should not change
    }
}
