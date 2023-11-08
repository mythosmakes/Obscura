using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowHazardController : MonoBehaviour
{
    [SerializeField] private float slowAmount; // default player speed is divided by this number when slowed

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var playerController))
        {
            playerController.CorruptionEffect();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out var playerController))
        {
            playerController.ResetSpeed();
        }
    }
}
