using UnityEngine;

public class bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Destroys the penguin
            Destroy(gameObject);           // Destroys the bullet
        }
    }
}