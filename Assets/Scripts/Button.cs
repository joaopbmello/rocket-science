using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Task3 barScript;

    // Start is called before the first frame update
    void Start()
    {
        barScript = GameObject.Find("Square (1)").GetComponent<Task3>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnMouseDown(){
        barScript.buttonPressed = true;
    }

    void OnMouseUp(){
        barScript.buttonPressed = false;
    }

}
