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
    public GameObject explosions;
    public TMP_Text countdownText;

    private List<int> pendingTasks = new List<int>();
    private float currentTime, countdownTime = 24.1f, newTaskDelay;
    private float[] taskDelay = new float[] { 6f, 3f, 3f, 6f, 6f };
    private bool gameOver = false;

    // 1 = easy, 1.5 = medium, 2 = hard
    private float difficultyLevel = 1;

    void Start()
    {
        instance = this;
        currentTime = countdownTime;
        currentTask = "";
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
        if (newTaskDelay <= 0f)
        {
            InitializeRandomTask((int)difficultyLevel);
        }

        // end animation and game ending
        if (currentTime <= 3)
        {
            if (currentTime > 0 && !AudioManager.instance.countdownAS.isPlaying)
            {
                AudioManager.instance.countdownAS.Play();
            }

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
                    if (!AudioManager.instance.explosionAS.isPlaying)
                    {
                        AudioManager.instance.explosionAS.Play();
                    }
                    gameOver = true;

                    string task = GameManager.instance.currentTask;
                    if (task != "" && SceneManager.GetSceneByName(task).isLoaded)
                        SceneManager.UnloadSceneAsync(task);

                    StartCoroutine(GameOver());
                }
            }
            else
            {
                if (!AudioManager.instance.launchAS.isPlaying)
                {
                    AudioManager.instance.launchAS.Play();
                }
                GameObject.Find("Sky").GetComponent<SkyManager>().ChangeColor();
                GameObject.Find("Clouds").GetComponent<CloudsManager>().Expand();
                Invoke("CompleteGame", 12f);
            }
        }

    }

    public void CompleteGame()
    {
        AudioManager.instance.launchAS.Stop();
        DifficultySettings.instance.SetEndingIndex(1);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator GameOver()
    {
        Instantiate(explosions, new Vector3(0, 0, -2), Quaternion.identity);
        yield return new WaitForSeconds(1);
        Debug.Log("Fim");
        DifficultySettings.instance.SetEndingIndex(0);
        SceneManager.LoadScene("GameOver");
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
                if (currentTime <= (8f - difficultyLevel * 2)) return;

                int t = UnityEngine.Random.Range(1, tasksAmount + 1);
                if (!pendingTasks.Contains(t) && currentTime > (taskDelay[t-1] - difficultyLevel))
                {
                    newTaskDelay = Mathf.Max(newTaskDelay, (taskDelay[t-1] + difficultyLevel) / difficultyLevel);
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
