using System.Collections.Generic;
using UnityEngine;

public class DialGameManager : MonoBehaviour
{
    public TaskManager taskManager;
    public GameObject target;
    private List<bool> targets = new List<bool> { false, false, false };

    void Start()
    {
        float[,] centers = { { -6f, -3.75f }, { 0f, -3.75f }, { 6f, -3.75f } };
        for (int i = 0; i < 3; i++)
        {
            Vector3 v = new Vector2(centers[i, 0], centers[i, 1]) + Random.insideUnitCircle.normalized * 2.5f;
            GameObject t = Instantiate(target, v, Quaternion.identity);
            t.GetComponent<TriggerDetector>().id = i;
            t.transform.SetParent(this.transform);
        }
    }

    void Update()
    {
        if (!targets.Contains(false))
        {
            taskManager.CompleteTask();
        }
    }

    public void ChangeLight(int id)
    {
        string lightName = "Light " + (id + 1);

        GameObject light = GameObject.Find(lightName);
        if (light != null)
        {
            light.GetComponent<SpriteRenderer>().color =
                targets[id] ? new Color(148f / 255f, 176f / 255f, 194f / 255f) : new Color(177f / 255f, 62f / 255f, 83f / 255f);
        }
    }

    public void SetTarget(int id, bool value)
    {
        targets[id] = value;
    }
}
