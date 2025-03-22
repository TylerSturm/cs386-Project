using UnityEngine;

public class Ride : MonoBehaviour
{
    private int currentCardValue;
    private int previousCardValue;
    private string currentCardSuit;
    private string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

    private int phase = 1;  // Track which phase the player is in
    private bool isGameOver = false;  // Stops the game once it's over

    void Start()
    {
        Debug.Log("Welcome to Ride the Bus!");
        Debug.Log("Phase 1: Guess the color (Press R for Red / B for Black)");
    }

    void Update()
    {
        if (isGameOver) return;  // Stop processing if the game is over

        // Phase 1: Color Guess
        if (phase == 1 && (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.B)))
        {
            colorGuess();
        }
        // Phase 2: Higher or Lower
        else if (phase == 2 && (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.L)))
        {
            highLowerGuess();
        }
        // Phase 3: Inside or Outside
        else if (phase == 3 && (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O)))
        {
            insideOutsideGuess();
        }
        // Phase 4: Suit Guess
        else if (phase == 4 && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) ||
                                Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4)))
        {
            suitGuess();
        }
    }

    void colorGuess()
    {
        DrawCard();
        bool isRed = (currentCardSuit == "Hearts" || currentCardSuit == "Diamonds");
        bool guessedRed = Input.GetKeyDown(KeyCode.R);

        Debug.Log($"You drew {GetCardFace(currentCardValue)} of {currentCardSuit}");

        if (isRed == guessedRed)
        {
            Debug.Log("Correct! Move to Phase 2: Higher or Lower (Press H for Higher / L for Lower)");
            previousCardValue = currentCardValue;
            phase = 2;
        }
        else
        {
            GameOver("Wrong guess! Game Over.");
        }
    }

    void highLowerGuess()
    {
        DrawCard();
        bool guessHigher = Input.GetKeyDown(KeyCode.H);

        Debug.Log($"You drew {GetCardFace(currentCardValue)} of {currentCardSuit}");

        if ((guessHigher && currentCardValue > previousCardValue) ||
            (!guessHigher && currentCardValue < previousCardValue))
        {
            Debug.Log("Correct! Move to Phase 3: Inside or Outside (Press I for Inside / O for Outside)");
            previousCardValue = currentCardValue;
            phase = 3;
        }
        else
        {
            GameOver("Wrong guess! Game Over.");
        }
    }

    void insideOutsideGuess()
    {
        int secondValue = previousCardValue;
        previousCardValue = currentCardValue;

        DrawCard();

        int low = Mathf.Min(previousCardValue, secondValue);
        int high = Mathf.Max(previousCardValue, secondValue);
        bool isInside = currentCardValue > low && currentCardValue < high;
        bool guessedInside = Input.GetKeyDown(KeyCode.I);

        Debug.Log($"You drew {GetCardFace(currentCardValue)} of {currentCardSuit}");

        if ((guessedInside && isInside) || (!guessedInside && !isInside))
        {
            Debug.Log("Correct! Move to Phase 4: Guess the suit (1-Hearts, 2-Diamonds, 3-Clubs, 4-Spades)");
            phase = 4;
        }
        else
        {
            GameOver("Wrong guess! Game Over.");
        }
    }

    void suitGuess()
    {
        DrawCard();

        int guessedSuit = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1)) guessedSuit = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) guessedSuit = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) guessedSuit = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4)) guessedSuit = 3;

        int drawnSuitIndex = System.Array.IndexOf(suits, currentCardSuit);

        Debug.Log($"You drew {GetCardFace(currentCardValue)} of {currentCardSuit}");

        if (guessedSuit == drawnSuitIndex)
        {
            Debug.Log("Congratulations! You finished the ride!");
            isGameOver = true;
        }
        else
        {
            GameOver("Wrong suit! Game Over.");
        }
    }

    void DrawCard()
    {
        currentCardValue = Random.Range(1, 14); // Ace (1) to King (13)
        currentCardSuit = suits[Random.Range(0, 4)];
    }

    string GetCardFace(int value)
    {
        switch (value)
        {
            case 1: return "Ace";
            case 11: return "Jack";
            case 12: return "Queen";
            case 13: return "King";
            default: return value.ToString();
        }
    }

    void GameOver(string message)
    {
        Debug.Log(message);
        isGameOver = true;
    }
}
