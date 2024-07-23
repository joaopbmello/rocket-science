using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Task1();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName(GameManager.instance.currentTask).isLoaded && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            BoxCollider2D boxCollider = GameObject.Find("Task Panel").GetComponent<BoxCollider2D>();
            if (!boxCollider.bounds.Contains(mousePosition))
            {
                SceneManager.UnloadSceneAsync(GameManager.instance.currentTask);
                GameManager.instance.currentTask = "";
            }
        }
    }

    public GameObject triangle;
    public GameObject target;

    void Task1()
    {
        float[,] centers = { { -3.5f, 1.5f }, { 3.5f, 1.5f }, { -3.5f, -1.5f }, { 3.5f, -1.5f } };

        for (int i = 0; i < 4; i++)
        {
            Vector2 v = new Vector2(centers[i, 0], centers[i, 1]) + Random.insideUnitCircle.normalized * 1.25f;
            Vector3 v3 = v;
            Instantiate(target, v3, Quaternion.identity);
        }
    }
}
