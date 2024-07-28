using UnityEngine;

public class Pipe : MonoBehaviour
{
    public bool isConnected = false;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, -90));
    }
}
