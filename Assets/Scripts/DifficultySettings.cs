using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DifficultySettings : MonoBehaviour
{
    public static DifficultySettings instance;
    public float difficultyLevel;

    private int endingIndex = 0;
    private string[,] texts = { 
        {"Mission Failed", "Mission Accomplished"} , 
        {"Missão Falhou", "Missão cumprida"} 
    };
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetEndingIndex(int value)
    {
        endingIndex = value;
    }

    public void SetFinalText()
    {
        TMP_Text finalText = GameObject.FindWithTag("FinalText").GetComponent<TMP_Text>();
        if (finalText != null)
        {
            int languageIndex = PlayerPrefs.GetInt("Language", 0);
            finalText.text = texts[languageIndex,endingIndex];
        }
        endingIndex = 0;
    }
}
