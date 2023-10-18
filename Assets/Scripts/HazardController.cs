using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var playerController = other.GetComponent<PlayerController>();
        {
            if(playerController != null)
            {
                playerController.CorruptionEffect();
            }
        }
    }
}
