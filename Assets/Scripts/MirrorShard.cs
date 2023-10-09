using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorShard : MonoBehaviour
{
    [SerializeField] private int rewardAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            other.gameObject.GetComponent<PlayerController>().UpdateShards(rewardAmount);
            gameObject.SetActive(false);
        }
        
    }
}
