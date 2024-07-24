using System.Collections.Generic;
using UnityEngine;

public class GridPanel : MonoBehaviour
{
    private Transform gridTransform;
    private List<int> unselectedIndexes;
    private int totalBoxes = 16;
    private int unselectedCount = 5;

    void Start()
    {
        gridTransform = gameObject.transform;

        HashSet<int> uniqueIndexes = new HashSet<int>();
        while (uniqueIndexes.Count < unselectedCount)
        {
            uniqueIndexes.Add(Random.Range(0, totalBoxes));
        }
        unselectedIndexes = new List<int>(uniqueIndexes);

        for (int i = 0; i < totalBoxes; i++)
        {
            GridBox gridBox = gridTransform.GetChild(i).GetComponent<GridBox>();
            gridBox.SetSelected(!unselectedIndexes.Contains(i));
        }
    }

    void Update()
    {
        if (unselectedCount == 0){
            GameManager.instance.CompleteTask(2);
        }
    }

    public void SelectBox(){
        unselectedCount--;
    }
}