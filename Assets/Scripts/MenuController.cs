using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButton()
    {
        Debug.Log("Play button pressed");
        SceneManager.LoadScene("MainScene");
    }

    public void OnOptionsButton()
    {
        Debug.Log("Options button pressed");
    }

    public void OnQuitButton(bool onMenuScene)
    {
        Debug.Log("Quit button pressed");
        if (onMenuScene)
            Application.Quit();
        else
            SceneManager.LoadScene("MainMenu");        
        
    }
}
