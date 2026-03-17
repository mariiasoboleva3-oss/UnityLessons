using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
     public GameObject Object;
    public int numberToSpawn = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            Instantiate(Object, new Vector3(i * 0, 0, 0), Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
