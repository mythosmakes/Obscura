using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorPad : MonoBehaviour
{
    //public Door doorReference;
    private CurrencyManager currencyManager;
    [SerializeField] int shardsNeededToUnlock;
    [SerializeField] int coinRewardAmount;

    [SerializeField] UnityEvent onActivate;

    private void Start()
    {
        currencyManager = CurrencyManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController> (out PlayerController playerController) == true)
        {
            if (playerController.ShardsCollected == shardsNeededToUnlock)
            {
                currencyManager.UpdateShards(playerController.ShardsCollected);
                playerController.UpdateShards(-shardsNeededToUnlock);
                currencyManager.UpdateCoins(coinRewardAmount);
                onActivate.Invoke ();
            }
        }
    }

}
