using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    //void OnTriggerEnter(Collider other)
    //{
    //    var playerController = other.GetComponent<PlayerController>();
    //    {
    //        if(playerController != null)
    //        {
    //            playerController.CorruptionEffect();
    //        }
    //    }
    //}

    // New corruption effect trigger using collisions

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerController>(out var playerController))
        {
            playerController.CorruptionEffect();
        }
    }
}
