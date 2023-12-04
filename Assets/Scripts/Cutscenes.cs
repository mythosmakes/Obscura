using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscenes : MonoBehaviour
{
	public string sceneName;
	public VideoPlayer videoPlayer;
	public float duration;

	private void Awake()
	{
		duration = (float)videoPlayer.length;
		Invoke("Skipping", duration);
	}

	public void Skipping()
	{
		SceneManager.LoadScene(sceneName);
	}
}
