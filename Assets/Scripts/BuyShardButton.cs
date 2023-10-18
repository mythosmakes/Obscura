using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyShardButton : MonoBehaviour
{
    private CurrencyShop currencyShop;
    private PlayerController player;
    private LevelCompleteMenu levelCompleteMenu;

    [SerializeField] TextMeshProUGUI buyText;
    [SerializeField] Image shardIcon;

    private void Awake()
    {
        //Change later with better architecture
        currencyShop = FindObjectOfType<CurrencyShop>().GetComponent<CurrencyShop>();
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        levelCompleteMenu = FindObjectOfType<LevelCompleteMenu>().GetComponent<LevelCompleteMenu>();
    }
    public void BuyShard()
    {
        if (currencyShop.Coins >= levelCompleteMenu.ShardCost)
        {
            currencyShop.SpendCoins(levelCompleteMenu.ShardCost);
            shardIcon.gameObject.SetActive(true);
            gameObject.SetActive(false);
            levelCompleteMenu.UpdateBuyTexts();
        }
    }
}
