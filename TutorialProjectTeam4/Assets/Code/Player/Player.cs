using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, I_Groundable
{
    //I_Groundable interface
    bool isGrounded; bool I_Groundable.isGrounded { get => isGrounded; set => isGrounded = value; }

    private Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }
    private SpriteRenderer sr { get => GetComponent<SpriteRenderer>(); }
    private Animator anim {  get => GetComponent<Animator>(); }

    [SerializeField] float speed, jumpForce;
    Vector2 direction, accDirection;

    //temp --> later let's decide the number for the player's reversed-inertia
    [SerializeField] float smoothingMulti; //0.5f~0.85f is nice

    private void Start()
    {
        isGrounded = false;
        direction = accDirection = Vector2.right;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x * smoothingMulti, rb.velocity.y);
        rb.velocity += accDirection * speed * Time.deltaTime;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        //add input system later perhaps... (unity input system)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            direction = accDirection = Vector2.right; //normalized
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            direction = accDirection = Vector2.left;
        }
        else
        {
            accDirection = Vector2.zero;
        }
    }

    private void Jump()
    {
        //add input system later perhaps... (unity input system)
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
}
