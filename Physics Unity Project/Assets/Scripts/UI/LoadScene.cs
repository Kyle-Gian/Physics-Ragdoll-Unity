//Author Kyle Gian
//Date Created 20/3/2021
//Last Modified 20/3/2021

//Used to load a scene when the corresponding button has been clicked

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void RestartGame()
    {
        GameTimer.timerFinished = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {

    }
}
