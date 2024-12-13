using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2f;  // Enemy speed
    public Transform player;  // Reference to the player's transform for target movement

    void Start()
    {
        flip();
    }

    void Update()
    {
        // movement towards the player 
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject); // Destroy the enemy when health reaches zero
        }
    }

private void flip()  // Flips when the penguin touches a point
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}