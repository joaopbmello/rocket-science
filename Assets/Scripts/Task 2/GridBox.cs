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
        sr.color = selected ? Color.green : Color.red;
    }

    void OnMouseDown()
    {
        if (!selected)
        {
            selected = true;
            GameObject.Find("GridPanel").GetComponent<GridPanel>().SelectBox();
            UpdateColor();
        }
    }
    
}