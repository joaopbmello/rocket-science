using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject leftButton, rightButton;
    public TMP_Text difficultyText;
    public string[,] difficulties = {
        {"Easy", "Medium", "Hard"},
        {"Fácil", "Médio", "Difícil"}
    };
    public bool endingScene, creditsScene;

    private int difficultyIndex = 0;

    void Start()
    {
        if (creditsScene) return;

        if (endingScene)
        {
            DifficultySettings.instance.SetFinalText();
        }
        else
        {
            ChangeDifficulty(0);
        }
    }

    public void OnPlayButton(bool restart)
    {
        if (restart)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            DifficultySettings.instance.difficultyLevel = difficultyIndex * 0.5f + 1;
            SceneManager.LoadScene("Context");
        } 
    }

    public void ChangeDifficulty(int i)
    {
        int languageIndex = PlayerPrefs.GetInt("Language", 0);
        difficultyIndex += i;
        difficultyText.text = difficulties[languageIndex, difficultyIndex];

        if (difficultyIndex == 0) leftButton.SetActive(false);
        else leftButton.SetActive(true);

        if (difficultyIndex == 2) rightButton.SetActive(false);
        else rightButton.SetActive(true);
    }

    public void OnOptionsButton()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OnCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
