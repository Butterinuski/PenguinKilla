using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthFun : MonoBehaviour
{

    public float maxHealth = 100;
    public float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage;
        if (maxHealth <= 0f)
        {
            Destroy(gameObject);
            Debug.Log("Player is dead!");
        }
    }
}
