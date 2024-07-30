using System;
using System.Collections;
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

    private bool isWaiting;

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
        isWaiting = false;
        pendingTasks = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Mathf.Max(0f, currentTime - Time.deltaTime);
        countdownText.text = currentTime.ToString("F2");

        if (currentTime <= 0){
            if (pendingTasks.Count > 0)
            {
                GameOver();
            }
            else
            {
                Debug.Log("Sucesso");
            }
        }

        if (!isWaiting)
        {
            isWaiting = true;
            float time = UnityEngine.Random.Range(2f, 5f);
            StartCoroutine(WaitAndInitialize(time));
        }

    }

    void InitializeTask(int task)
    {
        Color newColor;
        if (task == 3) newColor = Color.red;
        else newColor = new Color(1.0f, 0.647f, 0.0f);

        GameObject.Find("Button " + task.ToString()).GetComponent<SpriteRenderer>().color = newColor;
    }

    // task e currentTask?
    public void CompleteTask(int task)
    {
        Debug.Log("Task " + task.ToString() + " completa");
        ClearTask();

        Color color;
        ColorUtility.TryParseHtmlString("#333B58", out color);
        GameObject.Find("Button " + task.ToString()).GetComponent<SpriteRenderer>().color = color;

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

    IEnumerator WaitAndInitialize(float time)
    {
        Debug.Log("time: " + time.ToString());
        yield return new WaitForSeconds(time);

        isWaiting = false;
        int amount = UnityEngine.Random.Range(1, 2);
        Debug.Log("amount: " + amount.ToString());
        for (int i = 0; i < amount; i++){
            int index = UnityEngine.Random.Range(1, tasksAmount + 1);
            Debug.Log("    add index: " + index.ToString());
            pendingTasks.Add(index);
            InitializeTask(index);
        }
    }
}
