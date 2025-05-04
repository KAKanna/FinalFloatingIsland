using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //List
    public Transform[] spawnPoints;
    public List<Transform> currentWaveSpawnPoint;
    public GameObject enemyPrefab;

    public int totalSpawnEnemies, numberOfRandomSpawnPoint, delayStart, spawnInterval, numberOfPowerUp;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    { 
        yield return new WaitForSeconds(1f);
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2f);
        }
    }

    void SpawnEnemy()
    {
        int randomIndex =  Random.Range(0, spawnPoints.Length);
        
        
        //Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
