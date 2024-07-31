using UnityEngine;

public class DialController : MonoBehaviour
{
    public TaskManager taskManager;

    private Camera cam;
    private Collider2D col;
    private Vector3 screenPos;
    private float angleOffset;

    private void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!taskManager.IsCompleted())
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                if (col == Physics2D.OverlapPoint(mousePos))
                {
                    screenPos = cam.WorldToScreenPoint(transform.position);
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (col == Physics2D.OverlapPoint(mousePos))
                {
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                }
            }
        }
    }
}
