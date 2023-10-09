using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    private CurrencyManager currencyManager;
    public TextMeshProUGUI coinsCounter;

    private void Start()
    {
        currencyManager = CurrencyManager.instance;
    }

    private void Update()
    {
        coinsCounter.text = "Coins: " + currencyManager.Coins;
    }
}
