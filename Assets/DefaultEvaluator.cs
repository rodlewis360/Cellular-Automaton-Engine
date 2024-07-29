using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEvaluator : IEvaluator
{
    /* Default Evaluator - gives one bit of info about each of the cells neighbors and 4 of itself 
       12 bits total of info - This is basically a Moore neighborhood */

    override public int[] evalIn(int x, int y, Cell self, GameObject[,] grid)
    {
        int nw = safeGet(grid, x - 1, y + 1).state & 1;
        int n  = safeGet(grid, x,     y + 1).state & 1;
        int ne = safeGet(grid, x + 1, y + 1).state & 1;
        int w  = safeGet(grid, x - 1, y    ).state & 1;
        int e  = safeGet(grid, x + 1, y    ).state & 1;
        int sw = safeGet(grid, x - 1, y - 1).state & 1;
        int s  = safeGet(grid, x,     y - 1).state & 1;
        int se = safeGet(grid, x + 1, y - 1).state & 1;
    
        int center = self.state & 0xF;

        int[] outarr = { center, nw, n, ne, w, e, sw, s, se };

        return outarr;
    }

}
