using System;
using System.Collections;
using System.Collections.Generic;


using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerControler : MonoBehaviour

{
    public int speed;
    public float powerupStrength;
     public GameObject focalPoint;
     public GameObject powerupIndicator;
    private Rigidbody rigidBody; 
    private bool hasPowerup;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
                                             
        powerupIndicator.SetActive(false);
    }                                       

    // Update is called once per frame
    void Update()

    {
     float verticalInput = Input.GetAxis("Vertical");
     rigidBody.AddForce(focalPoint.transform.forward * verticalInput * speed);
     powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f , 0);
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.TryGetComponent(out Powerup powerup))
        {
          Destroy(powerup.gameObject); 
          powerupIndicator.SetActive(true);
          hasPowerup = true;

          StartCoroutine(PowerupCountdown());
        }
      
    }
    void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.TryGetComponent(out EnemyControler enemyControler) && hasPowerup )
        {
            Rigidbody enemyRigidBody = enemyControler.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (enemyControler.transform.position - transform.position);

            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength,ForceMode.Impulse);
        }
    }

    private IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
    
}

// add enemies and add spawn
   
