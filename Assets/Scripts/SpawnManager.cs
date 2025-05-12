using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //List
    public Transform[] spawnPoints;
    public List<Transform> currentWaveSpawnPoint;
    public GameObject[] enemyPrefab;
    private int ballIndex;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(5f);
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(5f);
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        int ballRandom = Random.Range(0, enemyPrefab.Length);
        Instantiate(
            enemyPrefab[ballRandom],
            spawnPoints[randomIndex].position,
            Quaternion.identity
        );

    }
}
