using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehavior : MonoBehaviour
{
    //NOTE - IMPLEMENT REWIND AND DO IT ON A FIVE MINUTE TIMER THEN SEND NOTE TO DAD ON DISCORD
    public GameObject[,] grid;

    public GameObject ruleCell;

    public string resetGridButton;
    public string nextGenButton;
    public string toggleAutoButton;

    public IEvaluator eval;

    public float genTime;
    public float cellSize;
    public float genDensity = 50f;
    private float lastUpdate;

    public int gridSizeX;
    public int gridSizeY;
    public int stateRange;

    public bool makeGridOnStart = true;
    public bool randomGrid = true;
    public bool wrap = true;
    private bool play = false;
    public bool playOnStart = false;

    // Start is called before the first frame update
    void Start()
    {
        if (makeGridOnStart)
        {
            grid = eval.newGrid(gridSizeX, gridSizeY, cellSize, ruleCell, randomGrid, stateRange, genDensity);
            eval.setWrap(wrap);
            eval.defaultCell = ruleCell;
            foreach (GameObject a in grid) {
                Cell cell = a.GetComponent<Cell>();
                cell.sp.color = cell.pallette[cell.state];
            }
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetButtonDown(nextGenButton))
        {
            eval.updateGrid(grid);
        }

        //if (Input.GetButtonDown(resetGridButton)) // reset grid
        //{
        //    foreach (GameObject a in grid)
        //    {
        //        Destroy(a);
        //        grid = eval.newGrid(gridSizeX, gridSizeY, cellSize, ruleCell, randomGrid, stateRange);
        //    }
        //}

        if (Input.GetButtonDown(toggleAutoButton))
        {
            play = !play;
        }

        if (play && Time.fixedUnscaledTime - lastUpdate > genTime)
        {
            lastUpdate = Time.fixedUnscaledTime;
            eval.updateGrid(grid);
        }

        if (playOnStart)
        {
            play = true;
        }
    }
}
