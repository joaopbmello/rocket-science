using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TaskManager : MonoBehaviour
{
    public int id;
    private bool completed = false;

    void Start()
    {

    }

    void Update()
    {
        string task = GameManager.instance.currentTask;
        if (task != "" && SceneManager.GetSceneByName(task).isLoaded && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            BoxCollider2D boxCollider = GameObject.Find("Task Panel").GetComponent<BoxCollider2D>();
            if (!boxCollider.bounds.Contains(mousePosition))
            {
                CloseTask(task);
            }
        }
    }

    public void CompleteTask()
    {
        completed = true;
        string task = GameManager.instance.currentTask;
        Debug.Log(task.ToString() + " completa");
        
        GameManager.instance.RemoveTask(id);
        StartCoroutine(WaitAndCloseTask(0.5f, task));   

        AudioManager.instance.completeAS.Play();     
    }

    public void CloseTask(string task)
    {
        SceneManager.UnloadSceneAsync(task);
        GameManager.instance.currentTask = "";
        ClearTask();
    }

    IEnumerator WaitAndCloseTask(float time, string task)
    {
        yield return new WaitForSeconds(time);

        if (SceneManager.GetSceneByName(task).isLoaded)
        {
            SceneManager.UnloadSceneAsync(task);
            GameManager.instance.currentTask = "";
            ClearTask();
        }
    }

    public void ClearTask()
    {
        GameObject[] taskObjects = GameObject.FindGameObjectsWithTag("TaskObject");
        foreach (GameObject go in taskObjects) Destroy(go);

        taskObjects = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject go in taskObjects) Destroy(go);
    }

    public bool IsCompleted()
    {
        return completed;
    }

}
