using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public int id;

    void Start()
    {

    }

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
        if (Input.GetKeyDown(KeyCode.X))
        {
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
