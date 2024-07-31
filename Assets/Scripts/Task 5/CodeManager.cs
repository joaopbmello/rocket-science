using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour
{
    public TaskManager taskManager;
    public DigitBox[] digitBoxes;
    public TextMesh codeText;
    private int[] code = new int[4];

    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            code[i] = Random.Range(0, 10);
        }
        codeText.text = string.Join("", code);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCorrect(0) && IsCorrect(1) && IsCorrect(2) && IsCorrect(3))
        {
            taskManager.CompleteTask();
        }
    }

    public bool IsCorrect(int id)
    {
        if (digitBoxes[id].GetDigit() == code[id])
        { 
            return true;
        }
        return false;
    }
    
}
