using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemyamage : MonoBehaviour
{
    public PlayerHealthFun pHealth;
    public float damage;
    public int Deaths;

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.currentHealth -= damage;
            if (pHealth.currentHealth <= 0)
            {
                SceneManager.LoadScene(Deaths);
            }
        }
    }
}