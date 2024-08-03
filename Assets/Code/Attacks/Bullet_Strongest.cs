using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Strongest : Attacks
{
    private void Awake()
    {
        damage = 10;
        speed = 30f;
    }

    public override void Start()
    {
        base.Start();
    }
}
