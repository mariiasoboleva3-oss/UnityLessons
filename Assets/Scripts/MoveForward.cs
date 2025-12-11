using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public int speed = 10;
    public int topBound = 45;

    public int BottomBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.forward * speed * Time.deltaTime);

       if(transform.position.z > topBound) 
        {
            Destroy(gameObject);
        }
        
        if(transform.position.z < BottomBound)
        {
            Destroy(gameObject);
        }
    }
       
}
