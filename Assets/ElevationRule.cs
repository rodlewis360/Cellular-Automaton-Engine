using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationRule : IRule
{
    // Uses BigEvaluator - creates lava underneath the ground and changes the ground's elevation based on the lava's height
    // The first two bits are the lava value and the second two bits are the elevation
    override public float updateSelf(int[] inAr)
    {
        int SUM_8 = 0;
        int center = inAr[0];
        int lava = center & 3;
        int elev = (center >> 2) & 3;
        SUM_8 += inAr[2] & 3;
        SUM_8 += inAr[4] & 3;
        SUM_8 += inAr[5] & 3;
        SUM_8 += inAr[7] & 3;

        float avg = (SUM_8 - 2) / 2;

        if (avg >= lava)
        {
            lava += (lava < 3) ? 1 : 0;
        } else
        {
            lava -= (lava > 0) ? 1 : 0;
        }

        if (elev < lava)
        {
            elev = lava & 3;
        }

        return lava + (elev << 2);
    }
}
