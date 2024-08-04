using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected Player player { get => FindObjectOfType<Player>(); }
    protected Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }

    protected override void Start()
    {
        base.Start();
        rb.angularDrag = 1000000f;
    }

    protected virtual void Update()
    {
        rb.velocity = rb.velocity * 0.5f;
    }
}
