using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        sr.color = Color.green;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        sr.color = Color.red;
    }
}
