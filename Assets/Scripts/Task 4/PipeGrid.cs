using System.Collections.Generic;
using UnityEngine;

public class PipeGrid : MonoBehaviour
{
    public TaskManager taskManager;
    public GameObject curvedPipe, straightPipe;

    // 0 = straight, 1 = curved
    private int[,,] maps = {
        { { 0, 1, 0, 1 }, { 0, 0, 0, 0 }, { 1, 1, 0, 1 }, { 0, 0, 0, 1 } },
        { { 1, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 1, 1 }, { 1, 1, 0, 0 } },
        { { 1, 1, 1, 1 }, { 1, 1, 0, 0 }, { 1, 0, 1, 1 }, { 0, 0, 1, 1 } },
        { { 1, 0, 1, 0 }, { 0, 1, 1, 1 }, { 0, 1, 0, 0 }, { 1, 0, 0, 1 } },
        { { 0, 1, 1, 1 }, { 1, 0, 0, 0 }, { 0, 1, 1, 0 }, { 1, 0, 1, 1 } },
        { { 1, 0, 1, 0 }, { 1, 0, 1, 1 }, { 0, 0, 0, 1 }, { 1, 0, 1, 0 } },
        { { 0, 0, 1, 1 }, { 0, 1, 0, 0 }, { 0, 0, 1, 1 }, { 0, 1, 1, 0 } },
        { { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 1, 0, 0, 1 }, { 0, 1, 1, 0 } }
    };
    private PipeController[,] pipes = new PipeController[4, 4];
    private FinalPipe finalPipe;

    // Start is called before the first frame update
    void Start()
    {
        CreatePipes();
        finalPipe = GameObject.Find("Final Pipe").GetComponent<FinalPipe>();
    }

    void CreatePipes()
    {
        int mapIndex = Random.Range(0, maps.GetLength(0));
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Vector3 pos = new Vector3(-5.625f + j * 3.75f, 5.625f - i * 3.75f, -1f);
                int angle = Random.Range(0, 4) * 90;

                GameObject newPipe;
                if (maps[mapIndex, i, j] == 0)
                {
                    newPipe = Instantiate(straightPipe, pos, Quaternion.Euler(0, 0, angle));
                }
                else
                {
                    newPipe = Instantiate(curvedPipe, pos, Quaternion.Euler(0, 0, angle));
                }

                pipes[i, j] = newPipe.GetComponent<PipeController>();
                pipes[i, j].isCurved = maps[mapIndex, i, j] == 1 ? true : false;
                pipes[i, j].row = i;
                pipes[i, j].column = j;
                pipes[i, j].pipeGrid = this;
                pipes[i, j].taskManager = taskManager;
            }
        }
    }

    public void SetConnections()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                pipes[i, j].isConnected = false;
            }
        }

        Queue<PipeController> queue = new Queue<PipeController>();

        // first pipe
        if (pipes[0, 0].ContainsDirection('L'))
        {
            queue.Enqueue(pipes[0, 0]);
        }

        while (queue.Count > 0)
        {
            PipeController current = queue.Dequeue();
            current.isConnected = true;

            if (current.ContainsDirection('U') && IsPositionValid(current.row - 1, current.column))
            {
                PipeController other = pipes[current.row - 1, current.column];
                if (!other.isConnected && other.ContainsDirection('D')) queue.Enqueue(other);

            }
            if (current.ContainsDirection('D') && IsPositionValid(current.row + 1, current.column))
            {
                PipeController other = pipes[current.row + 1, current.column];
                if (!other.isConnected && other.ContainsDirection('U')) queue.Enqueue(other);

            }
            if (current.ContainsDirection('L') && IsPositionValid(current.row, current.column - 1))
            {
                PipeController other = pipes[current.row, current.column - 1];
                if (!other.isConnected && other.ContainsDirection('R')) queue.Enqueue(other);

            }
            if (current.ContainsDirection('R') && IsPositionValid(current.row, current.column + 1))
            {
                PipeController other = pipes[current.row, current.column + 1];
                if (!other.isConnected && other.ContainsDirection('L')) queue.Enqueue(other);
            }
        }

        // pipe connected to final pipe
        if (pipes[0, 3].ContainsDirection('R') && pipes[0, 3].isConnected)
        {
            finalPipe.SetConnected();
            taskManager.CompleteTask();
        }
    }

    bool IsPositionValid(int row, int column)
    {
        return row >= 0 && row < 4 && column >= 0 && column < 4;
    }
}
