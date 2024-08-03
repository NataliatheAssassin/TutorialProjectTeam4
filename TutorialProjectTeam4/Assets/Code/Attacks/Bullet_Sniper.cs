using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Sniper : Attacks
{
    protected Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }

    private float speed;

    private void Awake()
    {
        damage = 2;
        speed = 30f;
    }

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }
}
