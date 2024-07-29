using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeRule : IRule
{
    override public float updateSelf(int[] evalIn)
    {
        int self = evalIn[8] & 1;  // Limit to only 1 bit of info because we only need to know if the cell
        int nw   = evalIn[7] & 1;  // was 1 or 0 last time
        int n = evalIn[6] & 1;
        int ne = evalIn[5] & 1;
        int w = evalIn[4] & 1;
        int e = evalIn[3] & 1;
        int sw = evalIn[2] & 1;
        int s = evalIn[1] & 1;
        int se = evalIn[0] & 1;

        int SUM_8 = nw + n + ne + w + e + sw + s + se;

        switch (self)
        {
            case 0:
                switch (SUM_8)
                {
                    case 3:
                        return 1;
                    default:
                        return 0;
                }
            case 1:
                switch (SUM_8)
                {
                    case 2:
                    case 3:
                        return 1;
                    default:
                        return 0;
                }
            default:
                return 0;
        }
    }
}
