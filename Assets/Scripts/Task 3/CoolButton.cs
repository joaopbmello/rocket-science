using UnityEngine;

public class CoolButton : MonoBehaviour
{
    public TaskManager taskManager;
    public BarManager temperatureBar;
    public Animator animator;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void OnMouseDown()
    {
        if (taskManager.IsCompleted()) return;

        temperatureBar.SetButtonPress(true);
        animator.SetBool("isPressed", true);
    }

    void OnMouseUp()
    {
        if (taskManager.IsCompleted()) return;
        
        temperatureBar.SetButtonPress(false);
        animator.SetBool("isPressed", false);
    }

}
