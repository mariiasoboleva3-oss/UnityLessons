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
  private Animator animator;
  private bool isOnGround = true;


    // Start is called before the first frame updatepsyco
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>(); 
       animator = GetComponent<Animator>();
       Physics.gravity = Physics.gravity * gravityModifier;
    }

    // Update is called once per frahmelp
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && isGameOver == false )
        { 
          isOnGround = false;
           rigidbody.AddForce(Vector3.up * jumpForce,ForceMode.Impulse); 
           animator.SetTrigger("Jump_trig");
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
            animator.SetBool("Death_b",true);
            animator.SetInteger("DeathType_int",1);
            Debug.Log("GameOver"); 
        }
    }
}
//Je m'apelle Sacha 
// Je suis en france
// je veux apprendre l'allemand 
