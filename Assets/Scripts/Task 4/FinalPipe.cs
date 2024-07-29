using UnityEngine;

public class FinalPipe : MonoBehaviour
{
    public bool isConnected = false;
    public Animator animator;

    void Start()
    {
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

    public void SetConnected()
    {
        isConnected = true;
    }
}
