using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Player : Attacks
{
    protected Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }

    private float speed;

    private void Awake()
    {
        damage = 1;
        speed = 15f;
    }

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }
}
