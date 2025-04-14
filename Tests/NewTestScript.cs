using UnityEngine;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;

public class RideTests
{
    private GameObject testObject;
    private Ride ride;

    [SetUp]
    public void Setup()
    {
        testObject = new GameObject();
        ride = testObject.AddComponent<Ride>();

        // Initialize required private lists
        SetPrivateField("drawnCards", new List<CardInfo>());
        SetPrivateField("coverCards", new List<GameObject>());
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(testObject);
    }

    [Test]
    public void TestColorGuessCorrect()
    {
        SetPrivateField("phase", 1);
        SetPrivateField("guessIndex", 0);
        AddCardToDrawnCards(new CardInfo(7, 2)); // Diamonds (red)

        InvokePrivateMethod("colorGuess", "red");

        Assert.AreEqual(2, GetPrivateField<int>("phase"));
    }

    [Test]
    public void TestColorGuessWrong()
    {
        SetPrivateField("phase", 1);
        SetPrivateField("guessIndex", 0);
        AddCardToDrawnCards(new CardInfo(10, 4)); // Spades (black)

        InvokePrivateMethod("colorGuess", "red");

        Assert.IsTrue(GetPrivateField<bool>("isGameOver"));
    }

    [Test]
    public void TestHighLowerGuessCorrect()
    {
        SetPrivateField("phase", 2);
        SetPrivateField("guessIndex", 1);
        SetPrivateField("firstCard", new CardInfo(5, 1)); // value 5
        AddCardToDrawnCards(new CardInfo(0, 0)); // index 0 filler
        AddCardToDrawnCards(new CardInfo(10, 3)); // value 10 (higher)

        InvokePrivateMethod("higherLowerGuess", "higher");

        Assert.AreEqual(3, GetPrivateField<int>("phase"));
    }

    [Test]
    public void TestHighLowerGuessWrong()
    {
        SetPrivateField("phase", 2);
        SetPrivateField("guessIndex", 1);
        SetPrivateField("firstCard", new CardInfo(10, 1));
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(5, 3));

        InvokePrivateMethod("higherLowerGuess", "higher");

        Assert.IsTrue(GetPrivateField<bool>("isGameOver"));
    }

    [Test]
    public void TestInsideOutsideGuessCorrect()
    {
        SetPrivateField("phase", 3);
        SetPrivateField("guessIndex", 2);
        SetPrivateField("firstCard", new CardInfo(5, 1));
        SetPrivateField("secondCard", new CardInfo(10, 2));
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(7, 3));

        InvokePrivateMethod("insideOutsideGuess", "inside");

        Assert.AreEqual(4, GetPrivateField<int>("phase"));
    }

    [Test]
    public void TestInsideOutsideGuessWrong()
    {
        SetPrivateField("phase", 3);
        SetPrivateField("guessIndex", 2);
        SetPrivateField("firstCard", new CardInfo(3, 1));
        SetPrivateField("secondCard", new CardInfo(8, 2));
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(10, 3));

        InvokePrivateMethod("insideOutsideGuess", "inside");

        Assert.IsTrue(GetPrivateField<bool>("isGameOver"));
    }

    [Test]
    public void TestSuitGuessCorrect()
    {
        SetPrivateField("phase", 4);
        SetPrivateField("guessIndex", 3);
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(7, 1)); // Clubs

        InvokePrivateMethod("guessSuit", "clubs");

        Assert.IsTrue(GetPrivateField<bool>("isGameOver"));
    }

    [Test]
    public void TestSuitGuessWrong()
    {
        SetPrivateField("phase", 4);
        SetPrivateField("guessIndex", 3);
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(0, 0));
        AddCardToDrawnCards(new CardInfo(7, 3)); // Hearts

        InvokePrivateMethod("guessSuit", "spades");

        Assert.IsTrue(GetPrivateField<bool>("isGameOver"));
    }

    // Utilities

    private void SetPrivateField<T>(string name, T value)
    {
        typeof(Ride).GetField(name, BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(ride, value);
    }

    private T GetPrivateField<T>(string name)
    {
        return (T)typeof(Ride).GetField(name, BindingFlags.NonPublic | BindingFlags.Instance)
            .GetValue(ride);
    }

    private void InvokePrivateMethod(string name, params object[] parameters)
    {
        typeof(Ride).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance)
            .Invoke(ride, parameters);
    }

    private void AddCardToDrawnCards(CardInfo card)
    {
        var drawnCards = GetPrivateField<List<CardInfo>>("drawnCards");
        drawnCards.Add(card);
    }
}
