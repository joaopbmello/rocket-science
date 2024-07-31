using UnityEngine;

public class PipeController : MonoBehaviour
{
    public TaskManager taskManager;
    public PipeGrid pipeGrid;
    public Animator animator;
    public bool isConnected, isCurved;
    public int row, column;

    private char direction1, direction2;

    void Start()
    {
        UpdateDirections();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

    }

    void Update()
    {
        if (isConnected)
        {
            animator.SetBool("isConnected", true);
        }
        else
        {
            animator.SetBool("isConnected", false);
        }
    }

    private void OnMouseDown()
    {
        if (taskManager.IsCompleted()) return;

        transform.Rotate(new Vector3(0, 0, -90));
        UpdateDirections();
    }

    void UpdateDirections()
    {
        int angle = (int) transform.localRotation.eulerAngles.z;
        if (isCurved)
        {
            if (angle == 0) SetDirections('D', 'R');
            else if (angle == 90) SetDirections('U', 'R');
            else if (angle == 180) SetDirections('U', 'L');
            else if (angle == 270) SetDirections('D', 'L');
        }
        else
        {
            if (angle == 0 || angle == 180) SetDirections('L', 'R');
            else SetDirections('U', 'D');
        }

        pipeGrid.SetConnections();
    }

    void SetDirections(char d1, char d2)
    {
        direction1 = d1;
        direction2 = d2;
    }

    public bool ContainsDirection(char direction)
    {
        return direction1 == direction || direction2 == direction;
    }
}
