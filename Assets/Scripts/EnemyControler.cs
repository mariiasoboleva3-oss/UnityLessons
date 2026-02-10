using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        rigidBody.AddForce(moveDirection * speed);
    }
}
