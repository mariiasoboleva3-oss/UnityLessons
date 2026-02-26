using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject powerup;
     private float spawnRange = 9; 
    private int waveNumber = 1;
    private int enemyCount;

    void Start()
    {
       SpawnEnemy(waveNumber);
       SpawnPowerup();
    }

   void Update()
    {
      enemyCount = FindObjectsByType<EnemyControler>(FindObjectsSortMode.None).Length;

      if(enemyCount <= 0)
      {
         waveNumber++;
         SpawnEnemy(waveNumber);
         SpawnPowerup();
      }
    }
    private void SpawnPowerup()
    { 
         Instantiate(powerup, GenerateSpawnPos(), transform.rotation);
    }
    private void SpawnEnemy(int numberOfEnemiesPerSpawn)
    {  
       for (int i = 0; i < numberOfEnemiesPerSpawn; i++)
       { 
         int randomEnemy = Random.Range(0,enemyPrefabs.Length);
         Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnPos(), transform.rotation);
       }
    }


    private Vector3 GenerateSpawnPos()
    {
        float spawmPositionX = Random.Range(-spawnRange , spawnRange);
       float spawnPositionZ =  Random.Range(-spawnRange , spawnRange);
       Vector3 spawnPosition = new Vector3 (spawmPositionX,0, spawnPositionZ);
       return spawnPosition;
    }
}

//ADD POWERUP POWER SPAWN every wave