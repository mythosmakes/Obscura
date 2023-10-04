using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    public int Coins { get; private set; }

    public int MirrorShards { get; private set; }

    [SerializeField] private int maxCoins;
    [SerializeField] private int minCoins;
    [SerializeField] private int maxShards;
    [SerializeField] private int minShards;


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void UpdateCoins(int amount)
    {
        Coins = Mathf.Clamp(Coins + amount, minCoins, maxCoins);
        Debug.Log(Coins);
    }

    public void UpdateShards(int amount)
    {
        MirrorShards = Mathf.Clamp(MirrorShards + amount, minShards, maxShards);
        Debug.Log(MirrorShards);
    }
}
