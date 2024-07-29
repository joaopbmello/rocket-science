using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string currentTask = "";
    public float countdownTime = 24.1f;
    public TMP_Text countdownText;
    public int tasksAmount;

    private List<int> pendingTasks;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
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

        currentTime = countdownTime;
        currentTask = "";

        HashSet<int> uniqueIndexes = new HashSet<int>();
        while (uniqueIndexes.Count < 3) // definir depois a quantidade
        {
            uniqueIndexes.Add(Random.Range(1, tasksAmount + 1));
        }
        //pendingTasks = new List<int>(uniqueIndexes);
        pendingTasks = new List<int>{4};

        foreach (int task in pendingTasks)
        {
            InitializeTask(task);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pendingTasks.Count == 0)
        {
            Debug.Log("Sucesso");
        }
        else
        {
            currentTime = Mathf.Max(0f, currentTime - Time.deltaTime);
            countdownText.text = currentTime.ToString("F2");
        }

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    void InitializeTask(int task)
    {
        GameObject.Find("Button " + task.ToString()).GetComponent<SpriteRenderer>().color = Color.red;
    }

    // task e currentTask?
    public void CompleteTask(int task)
    {
        ClearTask();
        GameObject.Find("Button " + task.ToString()).GetComponent<SpriteRenderer>().color = Color.green;
        pendingTasks.Remove(task);
        SceneManager.UnloadSceneAsync(GameManager.instance.currentTask);
        GameManager.instance.currentTask = "";
    }

    public bool IsPending(int task)
    {
        return pendingTasks.Contains(task);
    }

    public void GameOver()
    {
        Debug.Log("Fim");
        Time.timeScale = 0f;
    }
    
    public void ClearTask(){
        GameObject[] taskObjects = GameObject.FindGameObjectsWithTag("TaskObject");

        foreach (GameObject go in taskObjects)
        {
            Destroy(go);
        }
    }

}
