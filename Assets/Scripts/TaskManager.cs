using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public int id;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.currentTask != "")
        {
            if (SceneManager.GetSceneByName(GameManager.instance.currentTask).isLoaded && Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;

                BoxCollider2D boxCollider = GameObject.Find("Task Panel").GetComponent<BoxCollider2D>();
                if (!boxCollider.bounds.Contains(mousePosition))
                {
                    CloseTask();
                }
            }
        }

        // tirar depois
        if (Input.GetKeyDown(KeyCode.X)){
            GameManager.instance.CompleteTask(id);
            CloseTask();
        }
    }

    public void CloseTask()
    {
        SceneManager.UnloadSceneAsync(GameManager.instance.currentTask);
        GameManager.instance.currentTask = "";
    }

}
