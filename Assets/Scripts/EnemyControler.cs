using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class EnemyControler : MonoBehaviour
{
    public int speed;
    private PlayerControler player;

        private Rigidbody rigidBody; 
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }


        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        rigidBody.AddForce(moveDirection * speed);
    }
}
