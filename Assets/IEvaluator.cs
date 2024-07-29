using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEvaluator : MonoBehaviour
{
    bool wrap;
    public GameObject defaultCell;

    public void updateGrid(GameObject[,] grid)
    {
        int sizex = grid.GetLength(0);
        int sizey = grid.GetLength(1);
        List<int> gridStates = new List<int>();

        for (int x = 0; x < sizex; x++)
        {
            for (int y = 0; y < sizey; y++) {
                Cell cell = grid[x,y].GetComponent<Cell>();
                IRule rule = grid[x,y].GetComponent<IRule>();
                gridStates.Add((int)rule.updateSelf(evalIn(x, y, cell, grid))); // Run the rule with the info the evaluator feeds it
            }
        }

        int n = 0;
        foreach (GameObject a in grid)
        {
            Cell cell = a.GetComponent<Cell>();
            cell.setState(gridStates[n]);
            n++;
        }
    }

    public void setWrap(bool wrap)
    {
        this.wrap = wrap;
    }

    public bool getWrap()
    {
        return this.wrap;
    }

    public GameObject[,] newGrid(int sizex, int sizey, float cellSize, GameObject ruleCell, bool random)
    {
        return newGrid(sizex, sizey, cellSize, ruleCell, random, 1, 50);
    }

    public GameObject[,] newGrid(int sizex, int sizey, float cellSize, GameObject ruleCell, bool random, int stateRange, float density)
    {
        GameObject[,] newGrid = new GameObject[sizex, sizey];
        for (int y = 0; y < sizey; y++)
        {
            for (int x = 0; x < sizex; x++)
            {
                GameObject newCell = GameObject.Instantiate(ruleCell, transform);
                newCell.transform.position = new Vector2(transform.position.x + (x * cellSize), transform.position.y + (y * cellSize));
                newCell.transform.localScale = new Vector2(cellSize, cellSize);
                newGrid[x, y] = newCell;
                IRule cellRule = newCell.GetComponent<IRule>();
                cellRule.x = x;
                cellRule.GetComponent<IRule>().y = y;
                if (random)
                {
                    float randVal = UnityEngine.Random.value;
                    if (randVal < (density / 100))
                    {
                        newCell.GetComponent<Cell>().state = UnityEngine.Random.Range(1, stateRange);
                    } else
                    {
                        newCell.GetComponent<Cell>().state = 0;
                    }
                }
            }
        }
        return newGrid;
    }

    public Cell safeGet(GameObject[,] grid, int x, int y)
    {
        if (wrap)
        {
            if (x > grid.GetLength(0) - 1)
            {
                if (y > grid.GetLength(1) - 1)
                {
                    return grid[0, 0].GetComponent<Cell>();
                }
                else if (y < 0)
                {
                    return grid[0, grid.GetLength(1) - 1].GetComponent<Cell>();
                }
                else
                {
                    return grid[0, y].GetComponent<Cell>();
                }
            }
            else if (x < 0)
            {
                if (y > grid.GetLength(1) - 1)
                {
                    return grid[grid.GetLength(0) - 1, 0].GetComponent<Cell>();
                }
                else if (y < 0)
                {
                    return grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1].GetComponent<Cell>();
                }
                else
                {
                    return grid[grid.GetLength(0) - 1, y].GetComponent<Cell>();
                }
            }
            else
            {
                if (y > grid.GetLength(1) - 1)
                {
                    return grid[x, 0].GetComponent<Cell>();
                }
                else if (y < 0)
                {
                    return grid[x, grid.GetLength(1) - 1].GetComponent<Cell>();
                }
                else
                {
                    return grid[x, y].GetComponent<Cell>();
                }
            }
        } else
        {
            try
            {
                return grid[x, y].GetComponent<Cell>();
            } catch (IndexOutOfRangeException e)
            {
                return defaultCell.GetComponent<Cell>();
            }
        }
    }

    public abstract int[] evalIn (int x, int y, Cell cell, GameObject[,] grid);
}
