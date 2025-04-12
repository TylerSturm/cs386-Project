using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct CardInfo
{
    public int number; // 1-13
    public int color;  // 1-4

    public CardInfo(int number, int color)
    {
        this.number = number;
        this.color = color;
    }

    public override string ToString()
    {
        return $"Card Number: {number}, Color: {color}";
    }
}

public class Ride : MonoBehaviour
{
    public GameObject[] cards;
    public GameObject coverCard;
    public Vector3 playerPosition = new Vector3(-10f, 0, 0);

    private List<GameObject> coverCards = new List<GameObject>();
    private List<CardInfo> drawnCards = new List<CardInfo>();
    private int coverCardIndex = 0;
    private int guessIndex = 0;
    private int phase = 1;
    private int currentPhase = 0;
    private bool isGameOver = false;
    private CardInfo firstCard;
    private CardInfo secondCard;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            CardInfo cardInfo = drawCard(playerPosition);
            drawnCards.Add(cardInfo);

            GameObject cover = coverCardAtPosition(playerPosition);
            coverCards.Add(cover);

            playerPosition.x += 1.5f;
        }

        firstCard = drawnCards[0];
        secondCard = drawnCards[1];

        Debug.Log("=================================================");
        Debug.Log("Welcome to Ride the Bus!");
        Debug.Log("Press c to reveal one card at a time to cheat.");
    }

    void Update()
    {
        if (isGameOver) return;

        // Show phase instructions once per phase
        if (phase != currentPhase)
        {
            currentPhase = phase;
            ShowPhaseInstructions();
        }

        if (phase == 1)
        {
            if (Input.GetKeyDown(KeyCode.R)) colorGuess("red");
            else if (Input.GetKeyDown(KeyCode.B)) colorGuess("black");
        }
        else if (phase == 2)
        {
            if (Input.GetKeyDown(KeyCode.H)) higherLowerGuess("higher");
            else if (Input.GetKeyDown(KeyCode.L)) higherLowerGuess("lower");
        }
        else if (phase == 3)
        {
            if (Input.GetKeyDown(KeyCode.I)) insideOutsideGuess("inside");
            else if (Input.GetKeyDown(KeyCode.O)) insideOutsideGuess("outside");
        }
        else if (phase == 4)
        {
            if (Input.GetKeyDown(KeyCode.C)) guessSuit("clubs");
            else if (Input.GetKeyDown(KeyCode.D)) guessSuit("diamonds");
            else if (Input.GetKeyDown(KeyCode.H)) guessSuit("hearts");
            else if (Input.GetKeyDown(KeyCode.S)) guessSuit("spades");
        }

        // Manual reveal
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (coverCardIndex < coverCards.Count)
            {
                RemoveCoverCard(coverCardIndex);
                coverCardIndex++;
            }
            else
            {
                Debug.Log("All cover cards have been removed.");
            }
        }
    }

    void ShowPhaseInstructions()
    {
        switch (phase)
        {
            case 1:
                Debug.Log("Round 1: Guess the color of the card!");
                Debug.Log("Controls: Press 'R' for Red or 'B' for Black.");
                break;
            case 2:
                Debug.Log("Round 2: Will the card be higher or lower than your first card?");
                Debug.Log("Controls: Press 'H' for Higher or 'L' for Lower.");
                break;
            case 3:
                Debug.Log("Round 3: Will the card be inside or outside the range of your first two cards?");
                Debug.Log("Controls: Press 'I' for Inside or 'O' for Outside.");
                break;
            case 4:
                Debug.Log("Round 4: Guess the suit of the card!");
                Debug.Log("Controls: Press 'C' for Clubs, 'D' for Diamonds, 'H' for Hearts, or 'S' for Spades.");

                break;
        }
    }

    void colorGuess(string guess)
    {
        if (guessIndex >= drawnCards.Count)
        {
            Debug.Log("No more cards to guess.");
            return;
        }

        CardInfo card = drawnCards[guessIndex];
        string actualColor = (card.color == 2 || card.color == 3) ? "red" : "black";

        Debug.Log($"You guessed: {guess}");
        Debug.Log($"Actual card color: {actualColor} (Suit {card.color})");

        RemoveCoverCard(guessIndex);
        guessIndex++;

        if (guess == actualColor)
        {
            Debug.Log("✅ Correct guess!");
            phase++;
        }
        else
        {
            Debug.Log("❌ Wrong guess! Ride the bus...");
            isGameOver = true;
        }
    }

    void higherLowerGuess(string guess)
    {
        if (guessIndex >= drawnCards.Count)
        {
            Debug.Log("No more cards to guess.");
            return;
        }

        CardInfo currentCard = drawnCards[guessIndex];

        string result = currentCard.number > firstCard.number ? "higher" :
                        currentCard.number < firstCard.number ? "lower" : "equal";

        Debug.Log($"You guessed: {guess}");
        Debug.Log($"Actual card: {currentCard.number} vs First card: {firstCard.number} → {result}");

        RemoveCoverCard(guessIndex);
        guessIndex++;

        if (guess == result || result == "equal")
        {
            Debug.Log("✅ Correct guess or tie (tie is a win)!");
            phase++;
        }
        else
        {
            Debug.Log("❌ Wrong guess! Ride the bus...");
            isGameOver = true;
        }
    }

    void insideOutsideGuess(string guess)
    {
        if (guessIndex >= drawnCards.Count)
        {
            Debug.Log("No more cards to guess.");
            return;
        }

        CardInfo currentCard = drawnCards[guessIndex];
        bool isInside = currentCard.number > Mathf.Min(firstCard.number, secondCard.number) &&
                        currentCard.number < Mathf.Max(firstCard.number, secondCard.number);
        string result = isInside ? "inside" : "outside";

        Debug.Log($"You guessed: {guess}");
        Debug.Log($"Card {currentCard.number} is {result} the range of first ({firstCard.number}) and second card ({secondCard.number})");

        RemoveCoverCard(guessIndex);
        guessIndex++;

        if (guess == result || currentCard.number == firstCard.number || currentCard.number == secondCard.number)
        {
            Debug.Log("✅ Correct guess or tie (tie is a win)!");
            phase++;
        }
        else
        {
            Debug.Log("❌ Wrong guess! Ride the bus...");
            isGameOver = true;
        }
    }

    void guessSuit(string guess)
    {
        if (guessIndex >= drawnCards.Count)
        {
            Debug.Log("No more cards to guess.");
            return;
        }

        CardInfo currentCard = drawnCards[guessIndex];
        string actualSuit = currentCard.color switch
        {
            1 => "clubs",
            2 => "diamonds",
            3 => "hearts",
            4 => "spades",
            _ => "unknown"
        };

        Debug.Log($"You guessed: {guess}");
        Debug.Log($"Actual suit: {actualSuit}");

        RemoveCoverCard(guessIndex);
        guessIndex++;

        if (guess == actualSuit)
        {
            Debug.Log("✅ Correct guess! End Game");
            phase++;
            isGameOver = true;
        }
        else
        {
            Debug.Log("❌ Wrong guess! Ride the bus... End Game");
            isGameOver = true;
        }
    }

    CardInfo drawCard(Vector3 position)
    {
        int cardNum = Random.Range(1, 14);
        int cardColor = Random.Range(1, 5);

        int cardIndex = ((cardNum - 1) * 4) + (cardColor - 1);
        Instantiate(cards[cardIndex], position, Quaternion.identity);

        Debug.Log($"Drew card: Number {cardNum}, Color {cardColor}, Index {cardIndex}");
        return new CardInfo(cardNum, cardColor);
    }

    GameObject coverCardAtPosition(Vector3 position)
    {
        Vector3 coverPos = new Vector3(position.x, position.y, position.z - 0.1f);
        return Instantiate(coverCard, coverPos, Quaternion.identity);
    }

    void RemoveCoverCard(int index)
    {
        if (index >= 0 && index < coverCards.Count)
        {
            Destroy(coverCards[index]);
        }
    }
}
