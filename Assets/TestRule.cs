using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRule : IRule
{ 
    override public float updateSelf(int[] evalIn)
    {
        return evalIn[8];
    }
}
