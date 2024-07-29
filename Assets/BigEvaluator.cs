using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEvaluator : IEvaluator
{
    //4 bits of info about all moore neighbors including self
    override public int[] evalIn(int x, int y, Cell self, GameObject[,] grid)
    {
        int nw = safeGet(grid, x - 1, y + 1).state & 0xF;
        int n  = safeGet(grid, x,     y + 1).state & 0xF;
        int ne = safeGet(grid, x + 1, y + 1).state & 0xF;
        int w  = safeGet(grid, x - 1, y    ).state & 0xF;
        int e  = safeGet(grid, x + 1, y    ).state & 0xF;
        int sw = safeGet(grid, x - 1, y - 1).state & 0xF;
        int s  = safeGet(grid, x,     y - 1).state & 0xF;
        int se = safeGet(grid, x + 1, y - 1).state & 0xF;

        int center = self.state & 0xF;

        int[] outarr = { center, nw, n, ne, w, e, sw, s, se };

        return outarr;
    }
}
