using UnityEngine;

public class BarManager : MonoBehaviour
{
    public TaskManager taskManager;
    public float increaseRate = 1f, decreaseRate = 3f;
    public bool buttonPressed = false;

    private float height = 4f, minHeight = 0f, maxHeight = 9.5f;
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
        if (height >= maxHeight)
        {
            GameManager.instance.GameOver();
        }
        else if (height <= minHeight)
        {
            taskManager.CompleteTask();
        }
        else if (!buttonPressed)
        {
            height = Mathf.Min(height + increaseRate * Time.deltaTime, maxHeight);
        }
        else
        {
            height = Mathf.Max(height - decreaseRate * Time.deltaTime, minHeight);
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
