using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
    
    public void LoadLevelStart()
    {
        SceneManager.LoadScene("LevelStart");
    }

    public void LoadRotationLevelStart()
    {
        SceneManager.LoadScene("Level1Rotate(6x6) 1");
    }

    public void LoadRotationLevel1()
    {
        SceneManager.LoadScene("Level4Rotate(9x9) 1");
    }

    public void LoadChristmasLevel1()
    {
        SceneManager.LoadScene("Level2Rotate(6x6)");
    }

    public void LoadChristmasLevel2()
    {
        SceneManager.LoadScene("Level3Rotate(9x9)");
    }
}
