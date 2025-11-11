using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{  
    public PlayerController player; 
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
      startPosition = transform.position;  
    }

    // Update is called once per frame
    void LateUpdate()
    {
     transform.position = player.transform.position + startPosition;   
    }
}
