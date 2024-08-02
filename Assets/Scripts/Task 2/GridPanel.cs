using System.Collections.Generic;
using UnityEngine;

public class GridPanel : MonoBehaviour
{
    public TaskManager taskManager;

    private List<int> unselectedIndexes;
    private int totalBoxes = 16;
    private int unselectedCount = 5;
    private bool completed = false;

    void Start()
    {
        HashSet<int> uniqueIndexes = new HashSet<int>();
        while (uniqueIndexes.Count < unselectedCount)
        {
            uniqueIndexes.Add(Random.Range(0, totalBoxes));
        }
        unselectedIndexes = new List<int>(uniqueIndexes);

        for (int i = 0; i < totalBoxes; i++)
        {
            GridBox gridBox = transform.GetChild(i).GetComponent<GridBox>();
            gridBox.SetSelected(!unselectedIndexes.Contains(i));
        }
    }

    void Update()
    {
        if (unselectedCount == 0 && !taskManager.IsCompleted())
        {
            completed = true;
            taskManager.CompleteTask();
        }
    }

    public void SelectBox(bool selected)
    {
        if (selected)
        {
            unselectedCount--;
        }
        else
        {
            unselectedCount++;
        }
    }

    public bool IsCompleted()
    {
        return completed;
    }
}