using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public int  speed = 5;
    public int turnSpeed = 30;
    public float verticalInput; 
    public float horizontalInput; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical"); 
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(0, 0, speed * Time.deltaTime * verticalInput); 
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
    }
}
