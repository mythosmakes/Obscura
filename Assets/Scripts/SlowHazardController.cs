using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowHazardController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.SlowEffect();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.ResetSpeed();
        }
    }
}
