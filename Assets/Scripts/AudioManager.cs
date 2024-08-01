using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixer audioMixer;
    public AudioSource completeAS, warningAS;
    public AudioClip completeSound, warningSound;

    private bool warningTask;
    
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

    // Start is called before the first frame update
    void Start()
    {
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        if (musicVolume <= 0.001f) 
            audioMixer.SetFloat("MusicVolume", -100f);
        else 
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 30);

        float soundVolume = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        if (soundVolume <= 0.001f) 
            audioMixer.SetFloat("SoundVolume", -100f);
        else 
            audioMixer.SetFloat("SoundVolume", Mathf.Log10(soundVolume) * 30);

        completeAS.clip = completeSound;
        warningAS.clip = warningSound;
    }

    public void SetMusicVolume(float volume)
    {
        if (volume <= 0.001f)
        {
            audioMixer.SetFloat("MusicVolume", -100f);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 30);
        }        
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    
    public void SetSoundVolume(float volume)
    {
        if (volume <= 0.001f)
        {
            audioMixer.SetFloat("SoundVolume", -100f);
        }
        else
        {
            audioMixer.SetFloat("SoundVolume", Mathf.Log10(volume) * 30);
        }        
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }
}
