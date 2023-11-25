using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourceToggler : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (SaveManager.Instance.muteMusic == true)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }

    private void OnEnable()
    {
        SaveManager.OnMuteMusic += Mute;
        SaveManager.OnUnmuteMusic += Unmute;
    }

    private void OnDisable()
    {
        SaveManager.OnMuteMusic -= Mute;
        SaveManager.OnUnmuteMusic -= Unmute;
    }

    private void Mute()
    {
        audioSource.mute = true;
    }

    private void Unmute()
    {
        audioSource.mute = false;
    }
}

