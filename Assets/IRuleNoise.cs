using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IRuleNoise : IRule
{
    public AudioSource note;

    void Start()
    {
        note.pitch = y / 12.5f;
    }
}
