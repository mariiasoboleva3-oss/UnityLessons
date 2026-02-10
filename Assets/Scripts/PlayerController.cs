using System;
using System.Collections;
using System.Collections.Generic;


using UnityEditor;
using UnityEngine;

public class PlayerControler : MonoBehaviour

{
    public int speed;
    public GameObject focalPoint;
    private Rigidbody rigidBody; 
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

}

