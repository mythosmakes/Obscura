using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public int levelOneShards { get; private set; } = 0;
    public int levelTwoShards { get; private set; } = 0;
    public int levelThreeShards { get; private set; } = 0;
    public int levelFourShards { get; private set; } = 0;
    public int levelFiveShards { get; private set; } = 0;

    public int totalCoins { get; private set; } = 0;

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

    private void Start()
    {
        
    }

    public void SaveData(int shardsCollected, int sceneIndex, int coinsCollected)
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

        totalCoins = coinsCollected;

    }
}
