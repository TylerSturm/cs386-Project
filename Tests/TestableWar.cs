using UnityEngine;

public class TestableWar : War
{
    private int nextCardValue = 10;

    public void SetNextCard(int value)
    {
        nextCardValue = value;
    }

    // Just normal private method, no "new" keyword needed
    private int getCard(Vector3 position)
    {
        return nextCardValue;
    }

    // Public method to call the base compare
    public void FakeCompare(int playerTotal, int dealerTotal)
    {
        base.compare(playerTotal, dealerTotal);
    }
}
