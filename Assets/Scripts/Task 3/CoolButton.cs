using UnityEngine;

public class CoolButton : MonoBehaviour
{
    private Task3 barScript;
    public Animator animator;

    void Start()
    {
        barScript = GameObject.Find("Bar").GetComponent<Task3>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        barScript.buttonPressed = true;
        animator.SetBool("isPressed", true);
    }

    void OnMouseUp()
    {
        barScript.buttonPressed = false;
        animator.SetBool("isPressed", false);
    }

}
