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
    public GameObject explosions;
    public TMP_Text countdownText;

    private List<int> pendingTasks = new List<int>();
    private float currentTime, countdownTime = 24.1f, newTaskDelay;
    private bool completed;
    private float[] taskDelay = new float[] { 9f, 3f, 3f, 6f, 6f };
    private bool gameOver = false;

    // 1 = easy, 1.5 = medium, 2 = hard
    private float difficultyLevel = 1;

    void Start()
    {
        instance = this;
        currentTime = countdownTime;
        currentTask = "";
        finishButton.SetActive(false);
        newTaskDelay = 1f;
        difficultyLevel = DifficultySettings.instance.difficultyLevel;
    }

    void Update()
    {
        // warning sound effect
        if (pendingTasks.Count == 0 && AudioManager.instance.warningAS.isPlaying)
        {
            AudioManager.instance.warningAS.Stop();
        }
        if (pendingTasks.Count > 0 && !AudioManager.instance.warningAS.isPlaying)
        {
            AudioManager.instance.warningAS.Play();
        }

        // time management
        currentTime = Mathf.Max(0f, currentTime - Time.deltaTime);
        countdownText.text = currentTime.ToString("F2");
        newTaskDelay -= Time.deltaTime;

        // creating new tasks
        if (newTaskDelay <= 0f && currentTime > 10f)
        {
            InitializeRandomTask((int)difficultyLevel);
        }

        // end animation and game ending
        if (currentTime <= 3)
        {
            GameObject.Find("Cockpit").GetComponent<CockpitManager>().StartShake();
        }
        if (currentTime <= 0)
        {

            if (AudioManager.instance.warningAS.isPlaying)
            {
                AudioManager.instance.warningAS.Stop();
            }

            if (pendingTasks.Count > 0)
            {
                if (!gameOver)
                {
                    gameOver = true;
                    StartCoroutine(GameOver());
                }
            }
            else if (completed)
            {
                GameObject.Find("Sky").GetComponent<SkyManager>().ChangeColor();
                GameObject.Find("Clouds").GetComponent<CloudsManager>().Expand();
                Invoke("EndGame", 12f);
            }
        }
        if (currentTime < 2f && pendingTasks.Count == 0)
        {
            finishButton.SetActive(true);
        }

    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndScene");
    }

    IEnumerator GameOver()
    {
        Instantiate(explosions, new Vector3(0, 0, -2), Quaternion.identity);
        yield return new WaitForSeconds(1);
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

    void InitializeRandomTask(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (pendingTasks.Count == tasksAmount) break;

            int newTask = -1;
            while (newTask == -1)
            {
                if (currentTime <= (4.5f - difficultyLevel)) return;

                int t = UnityEngine.Random.Range(1, tasksAmount + 1);
                if (!pendingTasks.Contains(t) && currentTime > (taskDelay[t - 1] - difficultyLevel + 1))
                {
                    newTaskDelay = Mathf.Max(newTaskDelay, taskDelay[t - 1] - (difficultyLevel % 1) * 2);
                    newTask = t;
                }
            }

            pendingTasks.Add(newTask);
            TaskWarning(newTask);
        }
    }

    public void RemoveTask(int task)
    {
        pendingTasks.Remove(task);
        GameObject.Find("Task " + task.ToString()).GetComponent<Animator>().SetBool("isPending", false);
    }


}
