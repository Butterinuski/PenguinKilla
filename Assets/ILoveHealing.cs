using UnityEngine;

public class ILoveHealing : MonoBehaviour
{
    public float healingAmount = 25f;  // Amount of health this object heals
    public float healRadius = 3f;      // Radius within which the player can interact
    public string playerTag = "Player"; // Tag for the player object
    public bool PlayerHealth;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the healing radius (trigger area)
        if (other.CompareTag("Player"))
        {
            // Try to get the Player component from the colliding object (the player)
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                // Heal the player
                player.Heal(healingAmount);

                
                Destroy(gameObject);  // Destroy the healing object after being used
            }
        }
    }
}