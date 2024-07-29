using UnityEngine;

public class Pipe : MonoBehaviour
{
    public bool isConnected = false;
    public int isCurved;
    public Animator animator;

    public int row, column;
    public char direction1, direction2;
    private PipeGrid pipeGrid;

    void Start()
    {
        pipeGrid = GameObject.Find("PipeGrid").GetComponent<PipeGrid>();
        UpdateDirections();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

    }

    void Update()
    {
        //isConnected = CheckConnection();

        if (isConnected)
        {
            animator.SetBool("isConnected", true);
        }
        else
        {
            animator.SetBool("isConnected", false);
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, -90));
        UpdateDirections();
    }

    void UpdateDirections()
    {
        int angle = (int)transform.localRotation.eulerAngles.z;
        if (isCurved == 1)
        {
            if (angle == 0) SetDirections('D', 'R');
            else if (angle == 90) SetDirections('U', 'R');
            else if (angle == 180) SetDirections('U', 'L');
            else if (angle == 270) SetDirections('D', 'L');
        }
        else
        {
            if (angle == 0 || angle == 180) SetDirections('L', 'R');
            else SetDirections('U', 'D');
        }

        pipeGrid.SetConnections();
    }

    void SetDirections(char d1, char d2)
    {
        direction1 = d1;
        direction2 = d2;
    }

    public bool containsDirection(char direction)
    {
        return direction1 == direction || direction2 == direction;
    }

    /*
    bool CheckConnection(){
        Pipe p;

        // first pipe
        if (row == 0 && column == 0 && containsDirection('R')){
            return true;
        }

        if (containsDirection('U') && isPositionValid(row-1, column)){
            p = pipeGrid.pipes[row-1, column];
            if (p.containsDirection('D') && p.isConnected)
                return true;
        }
        if (containsDirection('D') && isPositionValid(row+1, column)){
            p = pipeGrid.pipes[row+1, column];
            if (p.containsDirection('U') && p.isConnected)
                return true;
        }
        if (containsDirection('L') && isPositionValid(row, column-1)){
            p = pipeGrid.pipes[row, column-1];
            if (p.containsDirection('R') && p.isConnected)
                return true;
        }
        if (containsDirection('R') && isPositionValid(row, column+1)){
            p = pipeGrid.pipes[row, column+1];
            if (p.containsDirection('L') && p.isConnected)
                return true;
        }
        return false;
    }

    bool isPositionValid(int row, int column){
        return row >= 0 && row < 4 && column >= 0 && column < 4;
    }
    */
}
