using System;
using System.Collections;
using System.Collections.Generic;


using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour

{
    public int speed;
    public float powerupStrength;
     public GameObject focalPoint;
    private Rigidbody rigidBody; 
    private bool hasPowerup;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()

    {
     float verticalInput = Input.GetAxis("Vertical");
     rigidBody.AddForce(focalPoint.transform.forward * verticalInput * speed);
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.TryGetComponent(out Powerup powerup))
        {
          Destroy(powerup.gameObject);
          hasPowerup = true;
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
}


   
