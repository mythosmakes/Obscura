using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorPad : MonoBehaviour
{
    public int shardsNeeded;
    public int coinReward;
    public CurrencyShop currencyShop;

    private bool activated = false;
    public UnityEvent onActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController> (out PlayerController playerController) == true)
        {
            if (playerController.shardsCollected >= shardsNeeded && activated == false)
            {
                playerController.UpdateShards(-shardsNeeded);
                currencyShop.RewardCoins(coinReward);
                Debug.Log("From DoorPad: " + currencyShop.Coins);
                onActivate.Invoke();
                activated = true;
            }
        }
    }

}
