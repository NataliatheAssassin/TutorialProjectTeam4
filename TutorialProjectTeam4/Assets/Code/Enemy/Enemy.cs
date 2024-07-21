using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }
    protected Player player { get => FindObjectOfType<Player>(); }

    protected float smoothingMulti = 0.5f;

    [SerializeField] protected GameObject attack;

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity * smoothingMulti;
    }
}
