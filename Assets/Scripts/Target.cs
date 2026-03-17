using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class Target : MonoBehaviour
{   

    // Start is called before the first frame update
    private Rigidbody targetRigidbody;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float torqueRange = 10;
    private float xRange = 4;
    private float ySpawnPosition = -6;
    void Start()
    {
      targetRigidbody = GetComponent<Rigidbody>();

      targetRigidbody.AddForce(RandomForce(),ForceMode.Impulse); 
      targetRigidbody.AddTorque(RandomTorque(),RandomTorque() , RandomTorque() , ForceMode.Impulse);

      transform.position = RandomSpawnPosition(); 
    }

    private Vector3 RandomForce()
  {
    return Vector3.up * Random.Range(minSpeed,maxSpeed);
  }
    private Vector3 RandomSpawnPosition()
  {
    return  new Vector3(Random.Range(-xRange , xRange) , ySpawnPosition );
  }
  private float RandomTorque()
  {
    return Random.Range(-torqueRange, torqueRange);
  }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}




// spawm manqger instatiate
