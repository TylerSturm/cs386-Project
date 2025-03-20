using System.Collections;
using UnityEngine;

public class War : MonoBehaviour
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
    public int playerWin = 0;
    public int dealerWin = 0;
    public int plays = 1;

    void Start()
    {
        playerPosition = new Vector3(-2, -3, -2);
        dealerPosition = new Vector3(-2, 1, -2);

        // Instantiate cover cards
        for (int i = 0; i < 3; i++)
        {
            Instantiate(coverCard, dealerPosition, Quaternion.identity);
            Instantiate(coverCard, playerPosition, Quaternion.identity);
            playerPosition.x += 2;
            dealerPosition.x += 2;
        }
        playerPosition.x -= 6;
        dealerPosition.x -= 6;
        playerPosition.z--;
        dealerPosition.z--;

        StartCoroutine(PlayCoroutine(playerPosition, dealerPosition));
    }

    IEnumerator PlayCoroutine(Vector3 playerPos, Vector3 dealerPos)
    {
        while (plays <= 3)
        {
            playerTotal += getCard(playerPos);
            dealerTotal += getCard(dealerPos);
            compare(playerTotal, dealerTotal);

            playerTotal = 0;
            dealerTotal = 0;
            playerPos.x += 2;
            dealerPos.x += 2;
            plays++;

            yield return new WaitForSeconds(2f); 
        }

        if (playerWin > dealerWin)
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("You lose!");
        }
    }

    void compare(int playerTotal, int dealerTotal)
    {
        if (playerTotal > dealerTotal)
        {
            playerWin++;
        }
        else
        {
            dealerWin++;
        }
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
