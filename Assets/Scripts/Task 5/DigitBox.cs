using UnityEngine;

public class DigitBox : MonoBehaviour
{
    public int id;
    public TextMesh digitText;
    public CodeManager codeManager;

    private int digit;
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        digit = Random.Range(0, 10);
        UpdateText();
    }

    void UpdateText()
    {
        digitText.text = digit.ToString();

        if (codeManager.IsCorrect(id))
        {
            digitText.color = new Color(148f / 255f, 176f / 255f, 194f / 255f);
        }
        else
        {
            digitText.color = new Color(177f / 255f, 62f / 255f, 83f / 255f);
        }
    }

    public int GetDigit()
    {
        return digit;
    }

    public void Increase()
    {
        digit = (digit + 1) % 10;
        UpdateText();
    }

    public void Decrease()
    {
        digit = (digit - 1 + 10) % 10;
        UpdateText();
    }

}
