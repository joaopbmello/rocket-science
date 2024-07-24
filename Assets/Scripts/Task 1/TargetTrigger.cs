using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public Task1 taskScript;
    public int id;
    private SpriteRenderer sr;

    void Start()
    {
        taskScript = GameObject.Find("Task 1").GetComponent<Task1>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(0f, 0f, 0f, 0f);
        taskScript.changeLight(id);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            taskScript.targets[id] = true;
            taskScript.changeLight(id);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            taskScript.targets[id] = false;
            taskScript.changeLight(id);
        }
    }
}
