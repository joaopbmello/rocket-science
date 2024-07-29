using System.Collections.Generic;
using UnityEngine;

public class PipeGrid : MonoBehaviour
{
    // 0 = reto, 1 = curvo
    public int[,] map = { { 0, 1, 0, 1 }, { 0, 0, 0, 0 }, { 1, 1, 0, 1 }, { 0, 0, 0, 1 } };
    public GameObject curvedPipe, straightPipe;

    public Pipe[,] pipes = new Pipe[4, 4];
    public FinalPipe finalPipe;

    // Start is called before the first frame update
    void Start()
    {
        CreatePipes();
        finalPipe = GameObject.Find("Final Pipe").GetComponent<FinalPipe>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreatePipes()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Vector3 pos = new Vector3(-3.75f + j * 2.5f, 3.75f - i * 2.5f, -1f);
                int angle = Random.Range(0, 4) * 90;

                GameObject newPipe;
                if (map[i, j] == 0)
                {
                    newPipe = Instantiate(straightPipe, pos, Quaternion.Euler(0, 0, angle));
                }
                else
                {
                    newPipe = Instantiate(curvedPipe, pos, Quaternion.Euler(0, 0, angle));
                }

                pipes[i, j] = newPipe.GetComponent<Pipe>();
                pipes[i, j].isCurved = map[i, j];
                pipes[i, j].row = i;
                pipes[i, j].column = j;
            }
        }
    }

    public void SetConnections()
    {
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                pipes[i, j].isConnected = false;

        Queue<Pipe> queue = new Queue<Pipe>();

        // first pipe
        if (pipes[0, 0].containsDirection('L'))
        {
            queue.Enqueue(pipes[0, 0]);
        }

        while (queue.Count > 0)
        {
            Pipe current = queue.Dequeue();
            current.isConnected = true;

            if (current.containsDirection('U') && isPositionValid(current.row - 1, current.column))
            {
                Pipe other = pipes[current.row - 1, current.column];
                if (!other.isConnected && other.containsDirection('D'))
                    queue.Enqueue(other);

            }
            if (current.containsDirection('D') && isPositionValid(current.row + 1, current.column))
            {
                Pipe other = pipes[current.row + 1, current.column];
                if (!other.isConnected && other.containsDirection('U'))
                    queue.Enqueue(other);

            }
            if (current.containsDirection('L') && isPositionValid(current.row, current.column - 1))
            {
                Pipe other = pipes[current.row, current.column - 1];
                if (!other.isConnected && other.containsDirection('R'))
                    queue.Enqueue(other);

            }
            if (current.containsDirection('R') && isPositionValid(current.row, current.column + 1))
            {
                Pipe other = pipes[current.row, current.column + 1];
                if (!other.isConnected && other.containsDirection('L'))
                    queue.Enqueue(other);
            }
        }

        if (pipes[0, 3].containsDirection('R') && pipes[0, 3].isConnected)
        {
            finalPipe.SetConnected();
            Debug.Log("OK");
            GameManager.instance.CompleteTask(4);
        }
    }

    bool isPositionValid(int row, int column)
    {
        return row >= 0 && row < 4 && column >= 0 && column < 4;
    }
}
