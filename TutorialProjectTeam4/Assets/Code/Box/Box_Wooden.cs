using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Wooden : Box
{
    private void Awake()
    {
        maxHp = 50;
        mass = 1.0f;
    }

    public override void Start()
    {
        base.Start();
    }
}