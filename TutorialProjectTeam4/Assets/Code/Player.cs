using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }
    private SpriteRenderer sr { get => GetComponent<SpriteRenderer>(); }
    //private Animator anim {  get => GetComponent<Animator>(); }

    [SerializeField] float speed, smoothingMulti; //0.5f ~ 0.85f is fine
    private Vector2 accDirection;

    private void Start()
    {
        accDirection = Vector2.zero;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity * smoothingMulti;
        rb.velocity += accDirection * speed * Time.deltaTime;
    }

    private void Update()
    {
        Move();
        //Animate();
    }

    private void Move()
    {
        float moveX = 0; float moveY = 0;
        if      (Input.GetKey(KeyCode.D)) { moveX = 1; moveY = 0; }
        else if (Input.GetKey(KeyCode.A)) { moveX =-1; moveY = 0; }
        else if (Input.GetKey(KeyCode.W)) { moveX = 0; moveY = 1; }
        else if (Input.GetKey(KeyCode.S)) { moveX = 0; moveY =-1; }
        else                              { moveX = 0; moveY = 0; }

        accDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Animate()
    {
        //anim.SetFloat("X_velocity", rb.velocity.x);
        //anim.SetFloat("Y_velocity", rb.velocity.y);
        //later add state with Finite State Machine structure!!!
    }
}
