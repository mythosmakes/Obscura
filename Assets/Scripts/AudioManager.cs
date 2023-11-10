using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this); 
            return ;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
