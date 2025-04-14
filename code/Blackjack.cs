using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blackjack : MonoBehaviour
{
    public GameObject card1, card2, card3, card4, card5, card6, card7, card8, card9, card10, card11, card12, card13, card14, card15, card16, card17, card18, card19, card20, 
    card21, card22, card23, card24, card25, card26, card27, card28, card29, card30, card31, card32, card33, card34, card35, card36, card37, card38, card39, card40, card41,
    card42, card43, card44, card45, card46, card47, card48, card49, card50, card51, card52, coverCard;
    public int cardNum;
    public int cardColor;
    public Vector3 playerPosition;
    public Vector3 dealerPosition;
    public int playerTotal = 0;
    public int dealerTotal = 0;
    public GameObject cover;
    public bool playerWin;
    public GameObject warTable;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Welcome to Blackjack!");
        Debug.Log("Press \"Y\" to hit and \"N\" to stand");
        // deal player cards
        for(int i = 0; i < 2; i++)
        {
            playerTotal += getCard(playerPosition);
            playerPosition.x +=1;
        }

        // check for player blackjack
        if(playerTotal == 21)
        {
            Debug.Log("Blackjack, you win!");
            playerWin = true;
            Invoke("nextGame", 3f);
        }

        // deal dealer cards
        for(int i = 0; i < 2; i++)
        {
            dealerTotal += getCard(dealerPosition);
            dealerPosition.x +=1;
        }
        cover = Instantiate(coverCard);
        cover.transform.position = new Vector3(dealerPosition.x - 1, dealerPosition.y, dealerPosition.z - 1);

        // check for dealer blackjack
        if(dealerTotal == 21)
        {
            playerWin = false;
            Debug.Log("Dealer Blackjack, you lose!");
            Invoke("nextGame", 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            playerTotal += getCard(playerPosition);
            playerPosition.x += 1;

            // checks if player bust
            if(playerTotal > 21)
            {
                Debug.Log("You Lose!");
                this.enabled = false; 
                playerWin = false;
                Invoke("nextGame", 3f);
            }
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            dealerTurn();
        }
    }

    void dealerTurn()
    {
        Destroy(cover);
        while(dealerTotal < 17)
        {
            dealerTotal += getCard(dealerPosition);
        }

        if(dealerTotal > 21)
        {
            Debug.Log("Dealer bust you win!");
            playerWin = true; 
            Invoke("nextGame", 3f);      
        }
        else if(playerTotal > dealerTotal)
        {
            Debug.Log("You win!");
            playerWin = true;
            Invoke("nextGame", 3f);
        }
        else if(dealerTotal > playerTotal)
        {
            Debug.Log("You lost!");
            playerWin = false;
            Invoke("nextGame", 3f);
        }
        else
        {
            Debug.Log("You tied!");
            playerWin = false;
            Invoke("nextGame", 3f);
        }
    }

    void nextGame()
    {
        SceneManager.LoadScene("War");
    }

    int getCard(Vector3 position)
    {
        // get a random number to decide card1 drawn
        cardNum = Random.Range(1,13);
        cardColor = Random.Range(1,4);

        // determine card drawn by using 2 random values
        switch(cardNum)
        {
            case 1:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card1);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card2);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card3);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card4);
                    card.transform.position = position;
                    break;
                }
                
            case 2:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card5);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card6);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card7);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card8);
                    card.transform.position = position;
                    break;
                }

            case 3:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card9);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card10);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card11);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card12);
                    card.transform.position = position;
                    break;
                }

            case 4:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card13);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card14);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card15);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card16);
                    card.transform.position = position;
                    break;
                }

            case 5:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card17);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card18);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card19);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card20);
                    card.transform.position = position;
                    break;
                }

            case 6:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card21);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card22);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card23);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card24);
                    card.transform.position = position;
                    break;
                }

            case 7:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card25);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card26);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card27);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card28);
                    card.transform.position = position;
                    break;
                }

            case 8:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card29);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card30);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card31);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card32);
                    card.transform.position = position;
                    break;
                }

            case 9:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card33);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card34);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card35);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card36);
                    card.transform.position = position;
                    break;
                }

            case 10:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card37);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card38);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card39);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card40);
                    card.transform.position = position;
                    break;
                }

            case 11:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card41);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card42);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card43);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card44);
                    card.transform.position = position;
                    break;
                }

            case 12:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card45);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card46);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card47);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card48);
                    card.transform.position = position;
                    break;
                }

            case 13:
                if(cardColor == 1)
                {
                    GameObject card = Instantiate(card49);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 2)
                {
                    GameObject card = Instantiate(card50);
                    card.transform.position = position;
                    break;
                }
                else if(cardColor == 3)
                {
                    GameObject card = Instantiate(card51);
                    card.transform.position = position;
                    break;
                }
                else
                {
                    GameObject card = Instantiate(card52);
                    card.transform.position = position;
                    break;
                }
        }
        if(cardNum > 10)
        {
            return 10;
        }
        else if(cardNum == 1)
        {
            return 11;
        }
        else
        {
            return cardNum;
        }
    }
}
