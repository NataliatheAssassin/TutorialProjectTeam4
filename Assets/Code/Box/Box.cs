using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Entity
{
    protected Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }

    protected float mass;
    protected float smoothingMulti = 0.5f;

    public override void Start()
    {
        base.Start();
        rb.mass = mass;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity * smoothingMulti;
    }
}
