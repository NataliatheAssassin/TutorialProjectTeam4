using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Iron : Box
{
    private void Awake()
    {
        maxHp = Mathf.Infinity;
        mass = 3.0f;
    }

    protected override void Start()
    {
        base.Start();
    }
}