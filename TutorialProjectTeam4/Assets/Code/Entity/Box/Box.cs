using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Entity
{
    protected Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }
    protected float mass;
    protected override void Start()
    {
        base.Start();
        rb.mass = mass;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity * 0.5f;
    }
}
