using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas, difficultyCanvas;

    void Start()
    {
        if (menuCanvas != null && difficultyCanvas != null)
        {
            menuCanvas.SetActive(true);
            difficultyCanvas.SetActive(false);
        }
    }

    public void OnPlayButton(float difficultyLevel)
    {
        // after choosing difficulty
        if (difficultyLevel > 0f)
        {
            DifficultySettings.instance.difficultyLevel = difficultyLevel;
            SceneManager.LoadScene("MainScene");
        }
        // game over / success scene
        else if (difficultyLevel == 0f)
        {
            Debug.Log("restart");
            SceneManager.LoadScene("MainScene");
        }
        // before choosing difficulty
        else
        {
            menuCanvas.SetActive(false);
            difficultyCanvas.SetActive(true);
        }

    }

    public void OnOptionsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OnQuitButton(bool onMenuScene)
    {
        if (menuCanvas.activeSelf)
        {
            Application.Quit();
        }
        else if (difficultyCanvas.activeSelf)
        {
            menuCanvas.SetActive(true);
            difficultyCanvas.SetActive(false);
        }
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
