using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainRule : IRule
{
    int SUM_8;

    // 2 is dying; 1 is alive (this makes the math easier)
    override public float updateSelf(int[] inAr)
    {
        int center = inAr[0];
        SUM_8 = 0;
        SUM_8 += (inAr[1] == 1) ? 1 : 0;
        SUM_8 += (inAr[2] == 1) ? 1 : 0;
        SUM_8 += (inAr[3] == 1) ? 1 : 0;
        SUM_8 += (inAr[4] == 1) ? 1 : 0;
        SUM_8 += (inAr[5] == 1) ? 1 : 0;
        SUM_8 += (inAr[6] == 1) ? 1 : 0;
        SUM_8 += (inAr[7] == 1) ? 1 : 0;
        SUM_8 += (inAr[8] == 1) ? 1 : 0;

        if (center == 1)
        {
            return 2;
        } else if (center == 2)
        {
            return 0;
        } else if (center == 0 && SUM_8 == 2)
        {
            return 1;
        } else
        {
            return 0;
        }
    }
}
