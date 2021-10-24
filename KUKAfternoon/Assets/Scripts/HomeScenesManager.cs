using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScenesManager : MonoBehaviour
{
  public void GoToPlayground()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        SceneManager.LoadScene("playground");
    }
    public void ContinuePlay()
    {
        if (PlayerPrefs.HasKey("PrevScene"))
        {
           string prevSceneName = PlayerPrefs.GetString("PrevScene");
            SceneManager.LoadScene(prevSceneName);
        }
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
