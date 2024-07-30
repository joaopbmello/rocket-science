using UnityEngine;

public class DigitBox : MonoBehaviour
{
    public int id, digit;
    public TextMesh digitText;
    public Password passwordScript;
    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        digit = Random.Range(0, 10);
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateText()
    {
        digitText.text = digit.ToString();

        if (passwordScript.isCorrect(id))
            digitText.color = new Color(148f / 255f, 176f / 255f, 194f / 255f);
        else
            digitText.color = new Color(177f / 255f, 62f / 255f, 83f / 255f);
    }

    public void Increment()
    {
        digit = (digit + 1) % 10;
        UpdateText();
    }

    public void Decrement()
    {
        digit = (digit - 1 + 10) % 10;
        UpdateText();
    }

}
