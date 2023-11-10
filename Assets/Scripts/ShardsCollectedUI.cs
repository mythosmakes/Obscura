using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardsCollectedUI : MonoBehaviour
{

    [SerializeField] GameObject mirrorShard1;
    [SerializeField] GameObject mirrorShard2;
    [SerializeField] GameObject mirrorShard3;

    [SerializeField] GameObject mirrorShard1S;
    [SerializeField] GameObject mirrorShard2S;
    [SerializeField] GameObject mirrorShard3S;

    [SerializeField] int level;
    private int shardsCollected;
    private SaveManager saveManager;

    private void Start()
    {
        saveManager = SaveManager.Instance;
        switch (level)
        {
            case 1:
                {
                    shardsCollected = saveManager.levelOneShards;
                    break;
                }
            case 2:
                {
                    shardsCollected = saveManager.levelTwoShards;
                    break;
                }
            case 3:
                {
                    shardsCollected = saveManager.levelThreeShards;
                    break;
                }
            case 4:
                {
                    shardsCollected = saveManager.levelFourShards;
                    break;
                }
            case 5:
                {
                    shardsCollected = saveManager.levelFiveShards;
                    break;
                }
        }

        mirrorShard1.SetActive(false);
        mirrorShard2.SetActive(false);
        mirrorShard3.SetActive(false);
        mirrorShard1S.SetActive(false);
        mirrorShard2S.SetActive(false);
        mirrorShard3S.SetActive(false);

        switch (shardsCollected)
        {
            case 1:
                mirrorShard1.SetActive(true);
                mirrorShard2S.SetActive(true);
                mirrorShard3S.SetActive(true);
                break;
            case 2:
                mirrorShard1.SetActive(true);
                mirrorShard2.SetActive(true);
                mirrorShard3S.SetActive(true);
                break;
            case 3:
                mirrorShard1.SetActive(true);
                mirrorShard2.SetActive(true);
                mirrorShard3.SetActive(true);
                break;
            default:
                mirrorShard1S.SetActive(true);
                mirrorShard2S.SetActive(true);
                mirrorShard3S.SetActive(true);
                break;
        }

    }

    void OnEnable()
    {
        
    }
}
