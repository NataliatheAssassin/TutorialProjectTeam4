using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Wooden : Box
{
    private void Awake()
    {
        maxHp = 1;
        mass = 1.0f;
    }

    protected override void Start()
    {
        base.Start();
    }
}