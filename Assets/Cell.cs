using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public SpriteRenderer sp;

    public int state;

    public Color[] pallette = new Color[256];

    public void setState(int newState)
    {
        sp.color = pallette[newState];
        state = newState;
    }

    public Cell()
    {
    }
}
