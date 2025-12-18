using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
  public int jumpForce = 10; 
  public float gravityModifier = 1.5f;
  private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>(); 
       Physics.gravity = Physics.gravity * gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space))
        {
           rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse); 
        }
    }
}
//Je m'apelle Sacha 
// Je suis en france
// je veux apprendre l'allemand 