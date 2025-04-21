using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Time between choosing new positions
    public float moveInterval = 2f;    
    // Movement speed
    public float speed = 2f;           
    public float xRange = 5f;
    public float yRange = 5f;

    private Vector2 targetPosition;

    void Start()
    {
        // Start coroutine that updates target position every so often
        StartCoroutine(ChooseNewPosition());
    }

    void Update()
    {
        // Move toward the target smoothly
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    System.Collections.IEnumerator ChooseNewPosition()
    {
        while (true)
        {
            // Pick a new random position
            targetPosition = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));

            // Wait before picking another target
            yield return new WaitForSeconds(moveInterval);
        }
    }
}
