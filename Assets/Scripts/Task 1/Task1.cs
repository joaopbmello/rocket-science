using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    public GameObject target;
    public List<bool> targets = new List<bool> { false, false, false, false };

    void Start()
    {
        float[,] centers = { { -4f, 2.5f }, { 1f, 2.5f }, { -4f, -2.5f }, { 1f, -2.5f } };

        for (int i = 0; i < 4; i++)
        {
            Vector3 v = new Vector2(centers[i, 0], centers[i, 1]) + Random.insideUnitCircle.normalized * 2f;
            GameObject t = Instantiate(target, v, Quaternion.identity);
            t.GetComponent<TargetTrigger>().id = i;
            t.transform.SetParent(this.transform);
        }
    }

    void Update()
    {
        if (!targets.Contains(false))
        {
            // Destruir todos os alvos manualmente
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Target"))
                {
                    Destroy(child.gameObject);
                }
            }

            GameManager.instance.CompleteTask(1);
        }
    }

    public void changeLight(int id)
    {
        string lightName = "Light " + (id + 1);

        SpriteRenderer light = GameObject.Find(lightName).GetComponent<SpriteRenderer>();

        light.color = targets[id] ? new Color(56f / 255f, 183f / 255f, 100f / 255f) : new Color(148f / 255f, 176f / 255f, 194f / 255f);
    }
}
