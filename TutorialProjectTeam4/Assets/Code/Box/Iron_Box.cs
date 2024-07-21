using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron_Box : Box
{
    private void Awake()
    {
        maxHp = 200;
        mass = 5.0f;
    }

    public override void Start()
    {
        base.Start();
    }
}