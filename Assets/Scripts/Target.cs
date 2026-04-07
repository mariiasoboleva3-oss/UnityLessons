using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class Target : MonoBehaviour
{   
   public enum State
  {
    Good, 
    Bad,

  }

    // Start is called before the first frame update
    private Rigidbody targetRigidbody;
    private float minSpeed = 14;
    private float maxSpeed = 18;
    private float torqueRange = 10;
    private float xRange = 4;
    private float ySpawnPosition = -6;
    private GameManager gameManager;

    public int pointCounter = 1;
    public State currentState;
    public ParticleSystem particleSystem;
    void Start()
    {

      
      gameManager = FindObjectOfType<GameManager>();
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out BottomBound bottomBound))
    {
     
      Destroy(gameObject);
    }
    }
    void  OnMouseDown()
    {
    if (gameManager.isGameActive)
    {
       gameManager.UpdateScore(pointCounter); 
      Instantiate(particleSystem , transform.position, particleSystem.transform.rotation);
        Destroy(gameObject);
        if(currentState == State.Bad)
    {
      gameManager.CucumberDeath();
    }
    }
     
    }
}




// smake particle
