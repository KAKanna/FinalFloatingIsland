using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<Transform> currentWaveSpawnPoint;
    public GameObject[] enemyPrefab;

    public GameObject Player;
    private GameObject currentPlayer;
    public Transform spawnPointsPlayer;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }
    private void Update()
    {
        if (currentPlayer == null)
        {
            Player.transform.position = spawnPointsPlayer.position;
            SpawnPlayer();
        }
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
    void SpawnPlayer()
    {
        currentPlayer = Instantiate(Player, spawnPointsPlayer.position, Quaternion.identity);
    }
}
