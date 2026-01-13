using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManaget : MonoBehaviour
{
    public GameObject obstacle; 
    public Vector3 spawnPosition = new Vector3(25,0,0);
    public float delayTime = 2;
    public float repeatTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof (SpawnObstacle),delayTime,repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        // SpawnObstacle();
    }

    private void SpawnObstacle()
    { 
    Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
    }
}
