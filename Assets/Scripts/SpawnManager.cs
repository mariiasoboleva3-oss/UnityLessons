using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManaget : MonoBehaviour
{
    public GameObject[] obstacle; 
    public Vector3 spawnPosition = new Vector3(25,0,0);
    public float delayTime = 2;
    public float repeatTime = 2; 
    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof (SpawnObstacle),delayTime,repeatTime);
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }

    private void SpawnObstacle()
    { 
        if (player.isGameOver == false)
        {  
            int randomObstacle = Random.Range(0,obstacle.Length);
            Instantiate(obstacle[randomObstacle], spawnPosition, obstacle[randomObstacle].transform.rotation);
        }
    }
}   

//