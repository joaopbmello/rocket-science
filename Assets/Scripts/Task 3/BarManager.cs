using UnityEngine;

public class BarManager : MonoBehaviour
{
    public TaskManager taskManager;
    public float increaseRate = 1f, decreaseRate = 3f;
    public bool buttonPressed = false;

    private float height = 4f;
    private Vector3 initialPosition;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (height <= 0f)
        {
            taskManager.CompleteTask();
        }
        else if (!buttonPressed)
        {
            height = Mathf.Min(height + increaseRate * Time.deltaTime, 9.5f);
        }
        else
        {
            height = Mathf.Max(height - decreaseRate * Time.deltaTime, 0f);
        }

        transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
        float newHeight = initialPosition.y + (height - initialScale.y) / 2;
        transform.localPosition = new Vector3(transform.localPosition.x, newHeight, transform.localPosition.z);
    }

    public void SetButtonPress(bool value)
    {
        buttonPressed = value;
    }
}
