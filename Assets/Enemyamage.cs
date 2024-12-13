using UnityEngine;

public class Enemyamage : MonoBehaviour
{
    public float damage = 10f; // Amount of damage the enemy deals

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the player's script and call the TakeDamage method
            PlayerHealthFun player = collision.gameObject.GetComponent<PlayerHealthFun>();
            if (player != null)
            {
                player.TakeDamage(damage); // Deal damage to the player
                Debug.Log("Player took damage!");
            }
        }
    }
}