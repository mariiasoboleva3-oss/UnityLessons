using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {   
        Debug.Log(other.gameObject.name);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
