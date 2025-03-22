using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Reflection;

public class RideTests
{
    private GameObject testObject;
    private Ride ride;

    [SetUp]
    public void Setup()
    {
        testObject = new GameObject();
        ride = testObject.AddComponent<Ride>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(testObject);
    }

    // Simulate a correct color guess
    [Test]
    public void TestColorGuessCorrect()
    {
        // Set the current card to a red suit (Hearts or Diamonds)
        SetPrivateField("currentCardSuit", "Hearts");
        SetPrivateField("currentCardValue", 7);
        SetPrivateField("phase", 1); // Color Guess Phase

        // Simulate pressing 'R' for Red
        var method = GetPrivateMethod("colorGuess");
        method.Invoke(ride, null);

        // Assert phase advances to Phase 2
        int phase = (int)GetPrivateField("phase");
        Assert.AreEqual(2, phase, "Phase should advance to 2 after correct color guess.");
    }

    // Simulate a wrong color guess (should end the game)
    [Test]
    public void TestColorGuessWrong()
    {
        // Set the current card to a black suit (Clubs or Spades)
        SetPrivateField("currentCardSuit", "Clubs");
        SetPrivateField("currentCardValue", 10);
        SetPrivateField("phase", 1); // Color Guess Phase

        // Simulate pressing 'R' for Red (incorrect guess)
        var method = GetPrivateMethod("colorGuess");
        method.Invoke(ride, null);

        // Assert the game is over
        bool isGameOver = (bool)GetPrivateField("isGameOver");
        Assert.IsTrue(isGameOver, "Game should be over after a wrong color guess.");
    }

    // Simulate a correct higher/lower guess
    [Test]
    public void TestHighLowerGuessCorrect()
    {
        SetPrivateField("phase", 2);
        SetPrivateField("previousCardValue", 5); // Previous card is 5
        SetPrivateField("currentCardValue", 10); // Drawn card is 10 (higher)

        // Simulate pressing 'H' for higher
        var method = GetPrivateMethod("highLowerGuess");
        method.Invoke(ride, null);

        // Assert phase advances to Phase 3
        int phase = (int)GetPrivateField("phase");
        Assert.AreEqual(3, phase, "Phase should advance to 3 after correct high/lower guess.");
    }

    // Simulate a wrong higher/lower guess (should end the game)
    [Test]
    public void TestHighLowerGuessWrong()
    {
        SetPrivateField("phase", 2);
        SetPrivateField("previousCardValue", 10); // Previous card is 10
        SetPrivateField("currentCardValue", 5); // Drawn card is 5 (lower)

        // Simulate pressing 'H' for higher (incorrect guess)
        var method = GetPrivateMethod("highLowerGuess");
        method.Invoke(ride, null);

        // Assert the game is over
        bool isGameOver = (bool)GetPrivateField("isGameOver");
        Assert.IsTrue(isGameOver, "Game should be over after a wrong high/lower guess.");
    }

    // Simulate a correct inside/outside guess
    [Test]
    public void TestInsideOutsideGuessCorrect()
    {
        SetPrivateField("phase", 3);
        SetPrivateField("previousCardValue", 5); // First card value is 5
        SetPrivateField("currentCardValue", 7); // Drawn card is inside (between 5 and 10)

        // Simulate pressing 'I' for inside
        var method = GetPrivateMethod("insideOutsideGuess");
        method.Invoke(ride, null);

        // Assert phase advances to Phase 4
        int phase = (int)GetPrivateField("phase");
        Assert.AreEqual(4, phase, "Phase should advance to 4 after correct inside/outside guess.");
    }

    // Simulate a wrong inside/outside guess (should end the game)
    [Test]
    public void TestInsideOutsideGuessWrong()
    {
        SetPrivateField("phase", 3);
        SetPrivateField("previousCardValue", 10); // First card value is 10
        SetPrivateField("currentCardValue", 5); // Drawn card is outside (less than 10)

        // Simulate pressing 'I' for inside (incorrect guess)
        var method = GetPrivateMethod("insideOutsideGuess");
        method.Invoke(ride, null);

        // Assert the game is over
        bool isGameOver = (bool)GetPrivateField("isGameOver");
        Assert.IsTrue(isGameOver, "Game should be over after a wrong inside/outside guess.");
    }

    // Simulate a correct suit guess
    [Test]
    public void TestSuitGuessCorrect()
    {
        SetPrivateField("phase", 4);
        SetPrivateField("currentCardSuit", "Clubs"); // 3rd suit (index 2)

        // Simulate pressing '3' for Clubs
        var method = GetPrivateMethod("suitGuess");
        method.Invoke(ride, null);

        // Assert the game is over
        bool isGameOver = (bool)GetPrivateField("isGameOver");
        Assert.IsTrue(isGameOver, "Game should end after correct suit guess.");
    }

    // Simulate a wrong suit guess (should end the game)
    [Test]
    public void TestSuitGuessWrong()
    {
        SetPrivateField("phase", 4);
        SetPrivateField("currentCardSuit", "Hearts"); // 1st suit (index 0)

        // Simulate pressing '2' for Diamonds (incorrect guess)
        var method = GetPrivateMethod("suitGuess");
        method.Invoke(ride, null);

        // Assert the game is over
        bool isGameOver = (bool)GetPrivateField("isGameOver");
        Assert.IsTrue(isGameOver, "Game should end after wrong suit guess.");
    }

    // Helper methods to access private fields and methods
    private void SetPrivateField(string fieldName, object value)
    {
        var field = typeof(Ride).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(ride, value);
    }

    private object GetPrivateField(string fieldName)
    {
        var field = typeof(Ride).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        return field.GetValue(ride);
    }

    private MethodInfo GetPrivateMethod(string methodName)
    {
        return typeof(Ride).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
    }
}
