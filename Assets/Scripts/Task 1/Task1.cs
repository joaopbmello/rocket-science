using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Task1 : MonoBehaviour
{
    public GameObject triangle;
    public GameObject target;
    public List<bool> targets = new List<bool> { false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        float[,] centers = { { -3.5f, 1.5f }, { 3.5f, 1.5f }, { -3.5f, -1.5f }, { 3.5f, -1.5f } };

        for (int i = 0; i < 4; i++)
        {
            Vector3 v = new Vector2(centers[i, 0], centers[i, 1]) + Random.insideUnitCircle.normalized * 1.25f;
            GameObject t = Instantiate(target, v, Quaternion.identity);
            t.GetComponent<TargetTrigger>().id = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!targets.Contains(false))
        {
            // tentar fazer surgir na nova cena pra não precisar disso
            foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>(true))
            {
                if (go.CompareTag("Target")) Destroy(go);
            }

            GameManager.instance.CompleteTask(1);
        }
    }

}
