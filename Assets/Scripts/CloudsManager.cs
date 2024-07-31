using UnityEngine;

public class CloudsManager : MonoBehaviour
{
    public float speed = 0.5f;

    private Vector3 initialPosition;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
