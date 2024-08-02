using System.Collections;
using UnityEngine;

public class StarsManager : MonoBehaviour
{
    public float scaleDuration = 24f;

    public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    public void ZoomIn()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        Vector3 initialScale = transform.localScale;
        float elapsedTime = 0;

        while (elapsedTime < scaleDuration)
        {
            float t = elapsedTime / scaleDuration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;

        spriteRenderer.enabled = false;
    }
}
