using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public int id;
    public string taskName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown(){
        if (GameManager.instance.IsPending(id) && GameManager.instance.currentTask == "" 
            && !SceneManager.GetSceneByName(taskName).isLoaded)
        {
            GameManager.instance.currentTask = taskName;
            SceneManager.LoadScene(taskName, LoadSceneMode.Additive);
        }
    }
}
