using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyShardButton : MonoBehaviour
{
    private CurrencyShop currencyShop;
    private PlayerController playerController;
    private LevelCompleteMenu levelCompleteMenu;

    [SerializeField] TextMeshProUGUI buyText;
    [SerializeField] Image shardIcon;

    private void Awake()
    {
        //Change later with better architecture
        currencyShop = FindObjectOfType<CurrencyShop>().GetComponent<CurrencyShop>();
        playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        levelCompleteMenu = FindObjectOfType<LevelCompleteMenu>().GetComponent<LevelCompleteMenu>();
    }
    public void BuyShard()
    {
        //Debug.Log("BuyShard() called");
        if (SaveManager.Instance.totalCoins >= levelCompleteMenu.ShardCost)
        {
            //Debug.Log("if statement met");
            currencyShop.SpendCoins(levelCompleteMenu.ShardCost);
            shardIcon.gameObject.SetActive(true);
            gameObject.SetActive(false);
            levelCompleteMenu.UpdateBuyTexts();
            playerController.shardsCollected++;
            SaveManager.Instance.SaveData(playerController.shardsCollected, SceneManager.GetActiveScene().buildIndex);
        }
    }
}
