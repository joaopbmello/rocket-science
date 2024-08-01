using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySettings : MonoBehaviour
{
    public static DifficultySettings instance;
    public float difficultyLevel;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
