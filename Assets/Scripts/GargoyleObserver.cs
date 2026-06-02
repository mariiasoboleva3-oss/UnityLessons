using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleObserver : MonoBehaviour
{
    private bool isPlayerInRange;
    private Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController playerController))
        {
             isPlayerInRange = true;
             player = playerController.transform;
        }
       
    }

    private void OTriggerExit(Collider other)
    {
       if (other.gameObject.TryGetComponent(out PlayerController playercontroller))
        {
            isPlayerInRange = false;
            player = null;
        }
    }

    private void Update()
    {
      if (isPlayerInRange == true)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position , direction);

            if (Physics.Raycast(ray , out RaycastHit raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    /////////////////////'
                }
            }
        }
    }
    
}   
   
