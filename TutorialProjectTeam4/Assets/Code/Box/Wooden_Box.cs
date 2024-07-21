using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wooden_Box : Box
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