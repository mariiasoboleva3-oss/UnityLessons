using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    public GameObject key;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        int randomSpawnPositionIndex = Random.Range(0, spawnPositions.Length);
        Instantiate(key, spawnPositions[randomSpawnPositionIndex].position , key.transform.rotation);
  
  
    }

    
}
