using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    private float spawnRange = 9;

    void Start()
    {
       SpawnEnemy();
       SpawnEnemy2();
    }

   void Update()
    {

    }
    private void SpawnEnemy()
    {  
       
       Instantiate(enemyPrefab, GenerateSpawnPos(), transform.rotation);
    }

private void SpawnEnemy2()
    {  
       
       Instantiate(enemyPrefab2, GenerateSpawnPos(), transform.rotation);
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawmPositionX = Random.Range(-spawnRange , spawnRange);
       float spawnPositionZ =  Random.Range(-spawnRange , spawnRange);
       Vector3 spawnPosition = new Vector3 (spawmPositionX,0, spawnPositionZ);
       return spawnPosition;
    }
}

