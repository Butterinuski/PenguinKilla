using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2f;   // Enemy speed
    public Transform player;   // Reference to the player's transform
    public PlayerHealthFun pHealth;
    public float damage;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (player != null)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Flip the sprite based on the player's position
            if (direction.x < 0)
            {
                // Flip right 
                spriteRenderer.flipX = false;
            }
            else
            {
                // Flip left 
                spriteRenderer.flipX = true;
            }

            // Move towards the player
            transform.Translate(direction * speed * Time.deltaTime);
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

    
    }
