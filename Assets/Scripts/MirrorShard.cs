using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorShard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            other.gameObject.GetComponent<PlayerController>().UpdateShards();
            gameObject.SetActive(false);
        }
        
    }
}
