using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Weakest : Attacks
{
    private void Awake()
    {
        damage = 5;
        speed = 15f;
        isPiercing = false;
    }

    public override void Start()
    {
        base.Start();
    }
}
