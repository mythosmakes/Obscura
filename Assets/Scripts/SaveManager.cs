using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public int levelOneShards { get; private set; } = 0;
    public int levelTwoShards { get; private set; } = 0;
    public int levelThreeShards { get; private set; } = 0;
    public int levelFourShards { get; private set; } = 0;
    public int levelFiveShards { get; private set; } = 0;

    public int totalCoins;
    public float totalMoney;

    public bool isPlayingTileRotation { get; private set; } = true;

    public static Action OnMuteMusic;
    public static Action OnUnmuteMusic;
    public bool muteMusic { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void ToggleMusic(bool condition)
    {
        if(condition == true)
        {
            OnMuteMusic?.Invoke();
            muteMusic = true;
        }
        else
        {
            OnUnmuteMusic?.Invoke();
            muteMusic = false;
        }
    }


    public void SetGamemode(int gamemode)
    {
        if(gamemode == 1)
        {
            isPlayingTileRotation = true;
            Debug.Log("gamemode = 1");
        }
        else if(gamemode == 0)
        {
            isPlayingTileRotation = false;
            Debug.Log("gamemode = 0");
        }
        else
        {
            Debug.Log("Invalid Gamemode");
        }
    }

    public void SaveData(int shardsCollected, int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 3: // level one
                {
                    if(shardsCollected > levelOneShards) { levelOneShards = shardsCollected; }
                    break;
                }
            case 4: // level two
                {
                    if (shardsCollected > levelTwoShards) { levelTwoShards = shardsCollected; }
                    break;
                }
            case 5: // level three
                {
                    if (shardsCollected > levelThreeShards) { levelThreeShards = shardsCollected; }
                    break;
                }
            case 6: // level four
                {
                    if (shardsCollected > levelFourShards) { levelFourShards = shardsCollected; }
                    break;
                }
            case 7: // level five
                {
                    if (shardsCollected > levelFiveShards) { levelFiveShards = shardsCollected; }
                    break;
                }
        }
    }

    public int GetShards()
    {
         switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3: // level one
                {
                    return levelOneShards;
                }
            case 4: // level two
                {
                    return levelTwoShards;
                }
            case 5: // level three
                {
                    return levelThreeShards;
                }
            case 6: // level four
                {
                    return levelFourShards;
                }
            case 7: // level five
                {
                    return levelFiveShards;
                }
            default:
                {
                    return 0;
                }
        }
    }

    //public void SetCoins(int amount)
    //{
    //    totalCoins = amount;
    //    Debug.Log("SaveManager: " + totalCoins);
    //}

    //public void SetPlayerMoney(float amount)
    //{
    //    totalMoney = amount;
    //}
}
