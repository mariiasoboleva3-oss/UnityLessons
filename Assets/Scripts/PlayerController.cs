using System.Collections;                                   
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{ 
  public int jumpForce = 10; 
  public float gravityModifier = 1.5f;
  public bool isGameOver;
  private Rigidbody rigidbody; 
  private bool isOnGround = true;


    // Start is called before the first frame updatepsyco
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>(); 
       Physics.gravity = Physics.gravity * gravityModifier;
    }

    // Update is called once per frahmelp
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && isGameOver == false )
        { 
          isOnGround = false;
           rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse); 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            isOnGround = true;
        }   
     if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            isGameOver = true;
            Debug.Log("GameOver"); 
        }
    }
}
//Je m'apelle Sacha 
// Je suis en france
// je veux apprendre l'allemand 

