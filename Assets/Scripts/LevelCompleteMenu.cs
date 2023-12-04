using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteMenu : MonoBehaviour
{
    // Exposed Properties
    [SerializeField] List<Button> shardIconShadows = new List<Button>();
    [SerializeField] List<Image> shardIcons = new List<Image>();
    [SerializeField] List<TextMeshProUGUI> buyTexts = new List<TextMeshProUGUI>();

    [SerializeField] private int shardCost;
    public int ShardCost { get { return shardCost; } }


    // References
    private CurrencyShop currencyShop;
    private PlayerController player;

    private void Awake()
    {
        //Change later with better architecture
        currencyShop = FindObjectOfType<CurrencyShop>().GetComponent<CurrencyShop>();
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //Debug.Log("From LevelCompleteMenu: " + currencyShop.Coins);
        for (int i = 0; i < SaveManager.Instance.GetShards(); i++)
        {
            shardIcons[i].gameObject.SetActive(true);
        }
        for(int i = shardIconShadows.Count-1; i >= SaveManager.Instance.GetShards(); i--)
        {
            shardIconShadows[i].gameObject.SetActive(true);
        }

        UpdateBuyTexts();
    }

    private void OnDisable()
    {
        foreach (Image icon in shardIcons)
        {
            icon.gameObject.SetActive(false);
        }
        foreach (Button button in shardIconShadows)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void UpdateBuyTexts()
    {
        foreach (TextMeshProUGUI text in buyTexts)
        {
            text.text = shardCost + " coins";
            if (currencyShop.Coins >= shardCost)
            {
                text.color = Color.green;
            }
            else
            {
                text.color = Color.red;
            }
        }
    }
}
