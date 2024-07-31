using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class GameSettings : MonoBehaviour
{
    public Slider musicSlider, soundSlider;
    public Button languageLeft, languageRight;
    public TMP_Text languageText;

    private List<string> languages = new List<string>() {"english", "português"};
    private int languageIndex;
    public AudioMixer audioMixer;

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 0.75f);
        languageIndex = PlayerPrefs.GetInt("Language", 0);
        languageText.text = languages[languageIndex];
        UpdateLanguageButtons();

        musicSlider.onValueChanged.AddListener(AudioManager.instance.SetMusicVolume);
        soundSlider.onValueChanged.AddListener(AudioManager.instance.SetSoundVolume);
    }

    public void ChangeLanguage(int i)
    {
        languageIndex += i;
        languageText.text = languages[languageIndex];
        PlayerPrefs.SetInt("Language", languageIndex);
        UpdateLanguageButtons();

        UpdateText();
    }

    void UpdateLanguageButtons()
    {
        if (languageIndex == 0)  languageLeft.gameObject.SetActive(false);
        else languageLeft.gameObject.SetActive(true);
        
        if (languageIndex == languages.Count - 1) languageRight.gameObject.SetActive(false);
        else languageRight.gameObject.SetActive(true); 
    }

    void UpdateText()
    {
        GameObject[] textObjects = GameObject.FindGameObjectsWithTag("Text");

        foreach (GameObject go in textObjects)
        {
            TextManager tm = go.GetComponent<TextManager>();
            if (tm != null) tm.UpdateText();
        }
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
