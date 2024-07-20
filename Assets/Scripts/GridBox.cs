using UnityEngine;

public class GridBox : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool selected = true;

    void Awake()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        UpdateColor();
    }

    public void SetSelected(bool isSelected)
    {
        selected = isSelected;
        UpdateColor();
    }

    private void UpdateColor()
    {
        if (selected)
        {
            sr.color = Color.green;
        }
        else
        {
            sr.color = Color.red;
        }
    }

    void OnMouseDown()
    {
        if (!selected)
        {
            selected = true;
            UpdateColor();
        }
    }

    void Update()
    {

    }
}