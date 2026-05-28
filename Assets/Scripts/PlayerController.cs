using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public bool hasKey;

    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;
    private Animator animator; 
    private Rigidbody rigidbody;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      rigidbody = GetComponent<Rigidbody>();
    }                                              

    // Update is called once per frame
    void FixedUpdate()
    {
      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");

      movement.Set(horizontalInput,0,verticalInput);
      movement.Normalize();

       bool hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0);
       bool hasVerticalInput = !Mathf.Approximately(verticalInput, 0);

       bool isWalking = hasHorizontalInput || hasVerticalInput;
       
       animator.SetBool("IsWalking" , isWalking);

       Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement , turnSpeed  * Time.deltaTime, 0);
       rotation = Quaternion.LookRotation(desiredForward);
       // 
       
       
    
    }

    private void  OnAnimatorMove()
  {
    rigidbody.MovePosition(rigidbody.position + movement * animator.deltaPosition.magnitude);
    rigidbody.MoveRotation(rotation);
  }
    private void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.TryGetComponent(out Key key))
    {
      Destroy(other.gameObject);
      hasKey = true;
    }

    }
}

