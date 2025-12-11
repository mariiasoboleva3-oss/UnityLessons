using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    public GameObject[] animalPrefabs;
    public float spawnPositionZ = 41;
    public int xRange = 10 ; 
    public float startDelay = 2;
    public float repeatTime = 5;
    // animal spawn
      

    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating(nameof(SpawnAnimal),startDelay,repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void SpawnAnimal()
    { 
        Vector3  spawnPosition = new Vector3(Random.Range(-xRange, xRange), transform.position.y , spawnPositionZ); //616161616161 999
        int randomAnimalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[randomAnimalIndex], spawnPosition , animalPrefabs[randomAnimalIndex].transform.rotation );
             
    }
}

