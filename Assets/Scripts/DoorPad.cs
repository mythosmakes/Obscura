using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorPad : MonoBehaviour
{
    public int shardsNeeded;
    public int coinReward;
    public CurrencyShop currencyShop;

    [SerializeField] UnityEvent onActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController> (out PlayerController playerController) == true)
        {
            if (playerController.shardsCollected == shardsNeeded)
            {
                playerController.UpdateShards(-shardsNeeded);
                currencyShop.RewardCoins(coinReward);
                onActivate.Invoke ();
            }
        }
    }

}
