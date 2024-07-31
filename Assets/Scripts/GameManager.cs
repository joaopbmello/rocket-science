using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string currentTask = "";
    public int tasksAmount;
    public GameObject finishButton;
    public TMP_Text countdownText;

    private bool isWaiting = false;
    private List<int> pendingTasks = new List<int>();
    private float currentTime, countdownTime = 24.1f;
    private bool completed;

    void Start()
    {
        instance = this;
        currentTime = countdownTime;
        currentTask = "";
        finishButton.SetActive(false);
    }

    void Update()
    {
        currentTime = Mathf.Max(0f, currentTime - Time.deltaTime);
        countdownText.text = currentTime.ToString("F2");

        if (currentTime <= 3)
        {
            GameObject.Find("Cockpit").GetComponent<CockpitManager>().StartShake();
        }

        if (currentTime <= 0)
        {
            if (pendingTasks.Count > 0)
            {
                GameOver();
            }
            else if (completed)
            {
                GameObject.Find("Sky").GetComponent<SkyManager>().ChangeColor();
                GameObject.Find("Clouds").GetComponent<CloudsManager>().Expand();

                // SceneManager.LoadScene("EndScene");
            }
        }

        if (!isWaiting && currentTime > 10)
        {
            isWaiting = true;
            //float time = UnityEngine.Random.Range(2f, 5f);
            float time = 4f;
            StartCoroutine(WaitAndInitialize(time));
        }

        if (currentTime < 3 && pendingTasks.Count == 0)
        {
            finishButton.SetActive(true);
        }

    }

    public void GameOver()
    {
        Debug.Log("Fim");
        SceneManager.LoadScene("GameOver");
    }

    public void CompleteGame()
    {
        Debug.Log("Sucesso");
        completed = true;
    }

    public bool IsPending(int task)
    {
        return pendingTasks.Contains(task);
    }

    void TaskWarning(int task)
    {
        GameObject.Find("Task " + task.ToString()).GetComponent<Animator>().SetBool("isPending", true);
    }

    IEnumerator WaitAndInitialize(float time)
    {
        yield return new WaitForSeconds(time);

        isWaiting = false;
        int amount = 1;
        for (int i = 0; i < amount; i++)
        {
            int index = UnityEngine.Random.Range(1, tasksAmount + 1);
            Debug.Log("add index: " + index.ToString());
            pendingTasks.Add(index);
            TaskWarning(index);
        }
    }

    public void RemoveTask(int task)
    {
        pendingTasks.Remove(task);

        GameObject.Find("Task " + task.ToString()).GetComponent<Animator>().SetBool("isPending", false);
    }


}
