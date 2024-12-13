using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // The enemy prefab to spawn
    public Transform[] spawnPoints;     // Array of possible spawn points
    public float minSpawnTime = 1f;     // Minimum time 
    public float maxSpawnTime = 5f;     // Maximum time 

    private void Start()
    {
        // Start spawning enemies at random intervals
        StartCoroutine(SpawnEnemyRandomly());
    }

    // Coroutine to spawn enemies randomly
    IEnumerator SpawnEnemyRandomly()
    {
        while (true)
        {
            //random time between minSpawnTime and maxSpawnTime
            float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomTime);

            //random spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate the enemy at the chosen spawn point
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}