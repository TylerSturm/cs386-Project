using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public GameObject player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse position in world space
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPosition = player.transform.position;

            // Calculate direction from player to mouse
            Vector2 direction = (mousePosition - playerPosition).normalized;

            // Spawn bullet at player position
            GameObject bullet = Instantiate(bulletPrefab, playerPosition, Quaternion.identity);

            // Give it velocity
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * bulletSpeed;
            }
        }
    }
}
