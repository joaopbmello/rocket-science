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
        gridTransform = gameObject.GetComponent<Transform>();

        HashSet<int> uniqueIndexes = new HashSet<int>();
        while (uniqueIndexes.Count < unselectedCount)
        {
            uniqueIndexes.Add(Random.Range(0, totalBoxes));
        }
        unselectedIndexes = new List<int>(uniqueIndexes);

        for (int i = 0; i < totalBoxes; i++)
        {
            GridBox gridBox = gridTransform.GetChild(i).GetComponent<GridBox>();
            if (unselectedIndexes.Contains(i))
            {
                gridBox.SetSelected(false);
            }
            else
            {
                gridBox.SetSelected(true);
            }
        }
    }

    void Update()
    {

    }
}