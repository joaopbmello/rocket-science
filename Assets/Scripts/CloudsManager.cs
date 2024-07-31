using System.Collections;
using UnityEngine;

public class CloudsManager : MonoBehaviour
{
    public float speed = 0.5f;
    public float scaleDuration = 3f;


    public Vector3 targetScale = new Vector3(6f, 6f, 6f);
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void Expand()
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
