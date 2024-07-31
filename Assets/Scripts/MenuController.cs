using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnOptionsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OnQuitButton(bool onMenuScene)
    {
        if (onMenuScene) Application.Quit();
        else SceneManager.LoadScene("MainMenu");        
    }
}
