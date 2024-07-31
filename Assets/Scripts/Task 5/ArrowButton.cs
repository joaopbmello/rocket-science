using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButton : MonoBehaviour
{
    public TaskManager taskManager;
    public bool isIncreaseButton;
    private DigitBox digitBox;

    // Start is called before the first frame update
    void Start()
    {
        digitBox = GetComponentInParent<DigitBox>();
    }

    void OnMouseDown()
    {
        if (taskManager.IsCompleted()) return;

        if (isIncreaseButton)
        {
            digitBox.Increase();
        }
        else
        {
            digitBox.Decrease();
        }
    }
}
