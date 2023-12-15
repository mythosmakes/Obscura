using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyShop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject gameUI;
    public Text coinsText;
    public Text moneyText;
    private int coins;
    private float cost;
    public float playerMoney { get; private set; }
    public float Coins { get { return coins; } }

    private SaveManager saveManager;

    void Start()
    {
        saveManager = SaveManager.Instance;
        gameUI.SetActive(true);
        shopUI.SetActive(false);
        moneyText.text = string.Format("Balance: ${0:F2}", saveManager.totalMoney);
        coinsText.text = saveManager.totalCoins.ToString();
    }

    public void OpenShop()
    {
        moneyText.text = string.Format("Balance: ${0:F2}", saveManager.totalMoney);
        coinsText.text = saveManager.totalCoins.ToString();
        gameUI.SetActive(false);
        shopUI.SetActive(true);
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
        gameUI.SetActive(true);
    }

    public void AddCoins(int addedCoins)
    {
        if(addedCoins == 100)
        {
            cost = 1.99f;
        }
        else if(addedCoins == 300)
        {
            cost = 4.99f;
        }
        else if(addedCoins == 500)
        {
            cost = 7.99f;
        }

        if(saveManager.totalMoney >= cost)
        {
            saveManager.totalMoney -= cost;
            moneyText.text = string.Format("Balance: ${0:F2}", saveManager.totalMoney);
            RewardCoins(addedCoins);
        }
        else
        {
            Debug.Log("Insufficient Funds!");
        }
    }

    public void RewardCoins(int rewardCoins)
    {
        saveManager.totalCoins += rewardCoins;
        coinsText.text = saveManager.totalCoins.ToString();
        //Debug.Log(coins);
    }

    public void AddMoney()
    {
        saveManager.totalMoney += .10f;
        moneyText.text = string.Format("Balance: ${0:F2}", saveManager.totalMoney);
    }

    public void SpendCoins(int amount)
    {
        saveManager.totalCoins -= amount;
        coinsText.text = saveManager.totalCoins.ToString();
        //Debug.Log(coins);
    }
}
