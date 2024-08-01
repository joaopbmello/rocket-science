using System.Collections;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color startColor = new Color(65f / 255f, 166f / 255f, 245f / 255f);
    public Color endColor = new Color(26f / 255f, 28f / 255f, 44f / 255f);
    public float duration = 15f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = startColor;
    }

    void Update()
    {

    }

    public void ChangeColor()
    {
        StartCoroutine(LerpColor());
    }

    IEnumerator LerpColor()
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = endColor;
    }
}
