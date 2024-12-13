using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100; // Set max health
    public float currentHealth; // Allows to keep track of current health
    public HealthSlider HealthSlider; // Shows the health slider
    void Start()
    {
        currentHealth = maxHealth; // Current health is equal to max health in the beginning
        HealthSlider.currentHealth = maxHealth; // Health slider is max health in the beginning
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount; // Makes the player take damage
        HealthSlider.TakeDamage(amount); // Makes the slider reduce

        
    }
    public void Heal(float amount)
    {
        maxHealth += amount; // Lets the player heal
        if (maxHealth > 100f) maxHealth = 100f;  // Prevent health from exceeding max value

        // Update the health bar
        if (HealthSlider != null)
        {
            HealthSlider.Heal(amount);
        }
        

    }
}