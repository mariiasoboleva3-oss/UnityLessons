using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float deletionX = -50;
    public int speed = 15;
    private PlayerController player ;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < deletionX)
        {
            Destroy(gameObject);
        }
        
        if (player.isGameOver == false)
        {
             transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
       
    }//if position x is over position it deletes
    
}
