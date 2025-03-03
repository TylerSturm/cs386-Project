using UnityEngine;
using System.Collections;

public class RouletteGame : MonoBehaviour
{
    public enum BetType
    {
        // bet types are ranked by difficulty to win
        // highest rank
        ExactNumber, 
        // lower rank 
        Color, 
        // medium rank       
        Range,  
        // lower rank      
        EvenOdd       
    }

    private BetType selectedBetType;
    private int chosenNumber;
    private string chosenColor;
    private int rangeMin, rangeMax;
    private bool choseEven;
    private int winningNumber;
    private string winningColor;
    // stores the rank of the win based on difficulty
    private int winRank; 

    void Start()
    {
        StartCoroutine(GetPlayerChoice());
    }

    IEnumerator GetPlayerChoice()
    {
        Debug.Log("Welcome to Roulette!");
        Debug.Log("Choose a bet type from: 'number', 'color', 'range', or 'evenodd'.");

        yield return WaitForPlayerInput();

        switch (playerInput.ToLower())
        {
            case "number":
                selectedBetType = BetType.ExactNumber;
                Debug.Log("Choose a number between 0 and 36:");
                yield return WaitForPlayerInput();
                chosenNumber = int.Parse(playerInput);
                break;

            case "color":
                selectedBetType = BetType.Color;
                Debug.Log("Choose 'Red' or 'Black':");
                yield return WaitForPlayerInput();
                chosenColor = playerInput;
                break;

            case "range":
                selectedBetType = BetType.Range;
                Debug.Log("Choose minimum number (1-36):");
                yield return WaitForPlayerInput();
                rangeMin = int.Parse(playerInput);
                Debug.Log("Choose maximum number (greater than min):");
                yield return WaitForPlayerInput();
                rangeMax = int.Parse(playerInput);
                break;

            case "evenodd":
                selectedBetType = BetType.EvenOdd;
                Debug.Log("Choose 'Even' or 'Odd':");
                yield return WaitForPlayerInput();
                choseEven = (playerInput.ToLower() == "even");
                break;

            default:
                Debug.Log("Invalid choice. Please restart the game.");
                yield break;
        }

        SpinAndCheck();
    }

    void SpinAndCheck()
    {
        SpinRouletteWheel();
        // store the win rank 
        winRank = CheckWin(); 

        if (winRank > 0)
        {
            Debug.Log("You won!");
        }
        else
        {
            Debug.Log("You lost!");
        }

    }

    void SpinRouletteWheel()
    {
        winningNumber = Random.Range(0, 37);
        winningColor = (winningNumber == 0) ? "Green" : (winningNumber % 2 == 0 ? "Black" : "Red");
        Debug.Log("Winning Number: " + winningNumber + " (" + winningColor + ")");
    }

    int CheckWin()
    {
        switch (selectedBetType)
        {
            case BetType.ExactNumber:
                return (chosenNumber == winningNumber) ? 4 : 0;

            case BetType.Color:
                return (chosenColor.ToLower() == winningColor.ToLower()) ? 2 : 0;

            case BetType.Range:
                return (winningNumber >= rangeMin && winningNumber <= rangeMax) ? 3 : 0;

            case BetType.EvenOdd:
                bool isWinningEven = (winningNumber % 2 == 0 && winningNumber != 0);
                return (isWinningEven == choseEven) ? 1 : 0;
        }
        return 0;
    }

    private string playerInput;
    private IEnumerator WaitForPlayerInput()
    {
        playerInput = null;
        while (playerInput == null)
        {
            yield return null;
        }
    }

    public void ReceivePlayerInput(string input)
    {
        playerInput = input;
    }

    // used in future game to get the win ranking 
    public int GetWinRank()
    {
        return winRank;
    }
}
