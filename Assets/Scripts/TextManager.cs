using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public List<string> textsList;
    public bool isContextScene = false;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        int index = PlayerPrefs.GetInt("Language", 0);
        text.text = textsList[index];

        if (isContextScene)
        {
            StartCoroutine(ContextScene(textsList[index]));
        }
    }

    public void UpdateText()
    {
        int index = PlayerPrefs.GetInt("Language", 0);
        text.text = textsList[index];
    }

    // context scene
    IEnumerator ContextScene(string message)
    {
        message = message.Replace("\\n", "\n");
        float delay = 0.025f;
        text.text = "";
        foreach (char letter in message.ToCharArray())
        {
            if (Input.anyKeyDown) break;
            text.text += letter;
            yield return new WaitForSeconds(delay);
        }

        text.text = message;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainScene");
    }
}
