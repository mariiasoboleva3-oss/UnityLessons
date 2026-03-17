using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public List<Target> targets;
    public float spawnRate = 1;
    
    // Start is called before the first frame update
    void Start()
    {
     StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }  
    private IEnumerator SpawnTarget()
    {
     while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomTarget = Random.Range(0,targets.Count);
            Instantiate(targets[randomTarget].gameObject);
        }
    }
}   
 
