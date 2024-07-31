using UnityEngine;

public class GridBox : MonoBehaviour
{
    public GridPanel gridPanel;
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
        sr.color = selected ? new Color(148f / 255f, 176f / 255f, 194f / 255f) : new Color(177f / 255f, 62f / 255f, 83f / 255f);
    }

    void OnMouseDown()
    {
        if (gridPanel.taskManager.IsCompleted()) return;

        selected = !selected;
        UpdateColor();
        gridPanel.SelectBox(selected);
    }
}