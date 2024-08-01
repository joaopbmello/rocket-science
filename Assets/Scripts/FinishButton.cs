using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        AudioManager.instance.completeAS.Play();   
        GameManager.instance.CompleteGame();
    }
}
