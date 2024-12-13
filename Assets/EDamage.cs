using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    public PlayerHealth pHealth; // Allows the script to access the players health
    public float damage;
    public int Deaths; // Keeps track of the number of deaths

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Gets the player
        {
            pHealth.currentHealth -= damage;
            if (pHealth.currentHealth <= 0) // Plays death screen
            {
                SceneManager.LoadScene(Deaths);
            }
        }
    }
}