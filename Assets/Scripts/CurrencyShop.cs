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
    private float playerMoney;

    void Start()
    {
        gameUI.SetActive(true);
        shopUI.SetActive(false);
        moneyText.text = string.Format("Balance: ${0:F2}", playerMoney);
        coinsText.text = coins.ToString();
    }

    public void OpenShop()
    {
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
        
        if(playerMoney >= cost)
        {
            playerMoney -= cost;
            moneyText.text = string.Format("Balance: ${0:F2}", playerMoney);
            coins += addedCoins;
            coinsText.text = coins.ToString();
        }
        else
        {
            Debug.Log("Insufficient Funds!");
        }
    }

    public void AddMoney()
    {
        playerMoney += .10f;
        moneyText.text = string.Format("Balance: ${0:F2}", playerMoney);
    }
}
