using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IRule : MonoBehaviour
{
    public int x;
    public int y;

    public abstract float updateSelf(int[] evalIn);  // You can input many things to evin through the evaluator by packing bits
                                                // - the number would not make sense in the abstract though
}
