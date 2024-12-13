using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthFun : MonoBehaviour
{

    public float maxHealth = 100; // set max health
    public float currentHealth; // allows to keep track of current health
    
    void Start()
    {
        currentHealth = maxHealth; // current health is the same as max health in the beginning 
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage; // allows the player to take damage
        if (maxHealth <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Player is dead!"); // tells us the player is dead
        }
    }
}
