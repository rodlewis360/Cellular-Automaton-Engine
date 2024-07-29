using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSoundRule : IRule
{
    public AudioSource c_note;

    //1 is burning tree, 2 is tree, and 0 is dirt
    override public float updateSelf(int[] inAr)
    {
        c_note.Stop();
        int center = inAr[0];
        int SUM_8_Fire = 0;
        SUM_8_Fire += (inAr[1] == 1) ? 1 : 0;
        SUM_8_Fire += (inAr[2] == 1) ? 1 : 0;
        SUM_8_Fire += (inAr[3] == 1) ? 1 : 0;
        SUM_8_Fire += (inAr[4] == 1) ? 1 : 0;
        SUM_8_Fire += (inAr[5] == 1) ? 1 : 0;
        SUM_8_Fire += (inAr[6] == 1) ? 1 : 0;
        SUM_8_Fire += (inAr[7] == 1) ? 1 : 0;
        SUM_8_Fire += (inAr[8] == 1) ? 1 : 0;

        int SUM_8_Tree = 0;
        SUM_8_Tree += (inAr[1] == 2) ? 1 : 0;
        SUM_8_Tree += (inAr[2] == 2) ? 1 : 0;
        SUM_8_Tree += (inAr[3] == 2) ? 1 : 0;
        SUM_8_Tree += (inAr[4] == 2) ? 1 : 0;
        SUM_8_Tree += (inAr[5] == 2) ? 1 : 0;
        SUM_8_Tree += (inAr[6] == 2) ? 1 : 0;
        SUM_8_Tree += (inAr[7] == 2) ? 1 : 0;
        SUM_8_Tree += (inAr[8] == 2) ? 1 : 0;

        if (SUM_8_Tree > 0)
        {
            if (Random.value < 0.002)
            {
                return 2;
            }
        }
        if (Random.value < 0.001)
        {
            return 2;
        }

        if (center == 2)
        {
            if (Random.value < 0.00001)
            {
                c_note.pitch = y / 12.5f;
                c_note.Play();
                return 1;
            }
            else if (SUM_8_Fire > 0 && Random.value < 0.75)
            {
                c_note.pitch = y / 12.5f;
                c_note.Play();
                return 1;
            }
            else
            {
                return 2;
            }
        }
        else if (center == 1)
        {
            return 0;
        }
        else
        {
            return 0;
        }
    }
}
