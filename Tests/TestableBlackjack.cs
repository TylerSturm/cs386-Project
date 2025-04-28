using UnityEngine;

public class TestableBlackjack : Blackjack
{
    private int nextDealerCardValue = 10;

    public void SetNextDealerCard(int value)
    {
        nextDealerCardValue = value;
    }

    // No "new" keyword needed
    private int getCard(Vector3 position)
    {
        return nextDealerCardValue;
    }
}
