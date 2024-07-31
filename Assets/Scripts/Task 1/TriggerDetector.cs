using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public DialGameManager manager;
    public string comparisonTag;
    public int id;
    
    private SpriteRenderer sr;

    void Start()
    {
        manager = transform.parent.gameObject.GetComponent<DialGameManager>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(0f, 0f, 0f, 0f);
        manager.ChangeLight(id);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(comparisonTag))
        {
            manager.SetTarget(id, true);
            manager.ChangeLight(id);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(comparisonTag))
        {
            manager.SetTarget(id, false);
            manager.ChangeLight(id);
        }
    }
}
