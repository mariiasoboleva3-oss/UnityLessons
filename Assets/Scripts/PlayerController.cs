using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
  private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>(); 
       
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space))
        {
           rigidbody.AddForce(Vector3.up * 10,ForceMode.Impulse); 
        }
    }
}
//Je m'apelle Sacha 
// Je suis en france
// je veux apprendre l'allemand