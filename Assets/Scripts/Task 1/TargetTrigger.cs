using UnityEngine;

public class TargetTrigger : MonoBehaviour
{
    public Task1 taskScript;
    public int id;
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        taskScript = GameObject.Find("Task 1").GetComponent<Task1>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.red;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            taskScript.targets[id] = true;
            sr.color = Color.green;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Line"))
        {
            taskScript.targets[id] = false;
            sr.color = Color.red;
        }
    }
}
