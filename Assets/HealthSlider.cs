using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Slider healthSlider;  // The Slider component for the health bar
    public float maxHealth = 100f;  // Max health value
    public float currentHealth;  // Current health value

    void Start()
    {
        // Initialize the current health
        currentHealth = maxHealth;

        // Set the slider's max value and current value
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        // Update the slider value to reflect the current health
        healthSlider.value = currentHealth;

        
        if (currentHealth <= maxHealth * 0.25f)
        {
            healthSlider.fillRect.GetComponent<Image>().color = Color.red;
        }
        else
        {
            healthSlider.fillRect.GetComponent<Image>().color = Color.green;
        }
    }

    // Method to change the player's health (to be called when the player takes damage)
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;  // Prevent negative health
    }

    // Method to heal the player 
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;  // Prevent health from exceeding max value
    }
}