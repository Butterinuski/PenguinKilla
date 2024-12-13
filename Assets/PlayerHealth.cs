using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100;
    public float currentHealth;
    public HealthSlider HealthSlider;
    void Start()
    {
        currentHealth = maxHealth;
        HealthSlider.currentHealth = maxHealth;
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        HealthSlider.TakeDamage(amount);

        if (currentHealth <= 0)
        {
            // We're dead
            // Game over

        }
    }
    public void Heal(float amount)
    {
        maxHealth += amount;
        if (maxHealth > 100f) maxHealth = 100f;  // Prevent health from exceeding max value

        // Update the health bar
        if (HealthSlider != null)
        {
            HealthSlider.Heal(amount);
        }
        

    }
}