using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public int walkSpeed = 10;
    public float xRange = 15;
    public GameObject foodPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //float verticalInput = Input.GetAxis("Vertical");
      float horizontalInput = Input.GetAxis("Horizontal");
      transform.Translate(Vector3.right * horizontalInput * walkSpeed * Time.deltaTime);            
      //transform.Translate(Vector3.forward * verticalInput * walkSpeed * Time.deltaTime);

      if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

      if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

      if (Input.GetKeyUp(KeyCode.Space))
        {
          Vector3 spawnPosition = new Vector3(transform.position.x, 1 , transform.position.z); //skibidi
            Instantiate(foodPrefab, spawnPosition, foodPrefab.transform.rotation );
        }
    }
}
