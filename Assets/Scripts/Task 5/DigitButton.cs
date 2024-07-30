using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitButton : MonoBehaviour
{
    public bool up;
    private DigitBox digitBox;

    // Start is called before the first frame update
    void Start()
    {
        digitBox = GetComponentInParent<DigitBox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (up) digitBox.Increment();
        else digitBox.Decrement();
    }
}
