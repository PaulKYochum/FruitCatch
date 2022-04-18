using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Paul Kent Yochum
// Main Menu Script
// 4/17/2022

// Note: Methods for menu buttons to load specific scenes


public class MainMenu : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene("FruitCatch");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LeaderBoard()
    {
        SceneManager.LoadScene("Leaderboards");
    }
}
