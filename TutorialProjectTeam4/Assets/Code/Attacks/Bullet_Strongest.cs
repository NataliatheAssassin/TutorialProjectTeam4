using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Strongest : Attacks
{
    private float explosionRadius;

    private void Awake()
    {
        damage = 10;
        speed = 30f;
        isPiercing = false;

        explosionRadius = 3;
    }

    public override void Start()
    {
        base.Start();
    }
}
