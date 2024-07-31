using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public List<string> textsList;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        int index = PlayerPrefs.GetInt("Language", 0);
        text.text = textsList[index];
    }

    public void UpdateText()
    {
        int index = PlayerPrefs.GetInt("Language", 0);
        text.text = textsList[index];
    }
}
