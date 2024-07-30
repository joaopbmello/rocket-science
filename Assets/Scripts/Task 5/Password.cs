using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password : MonoBehaviour
{
    private int[] code = new int[4];
    public DigitBox[] digitBoxes;
    public TextMesh passwordText;

    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            code[i] = Random.Range(0, 10);
        }
        passwordText.text = string.Join("", code);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCorrect(0) && isCorrect(1) && isCorrect(2) && isCorrect(3))
        {
            GameManager.instance.CompleteTask(5);
        }
    }

    public bool isCorrect(int id){
        if (digitBoxes[id].digit == code[id]) 
            return true;
        return false;
    }
    
}
