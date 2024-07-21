using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }
    private SpriteRenderer sr { get => GetComponent<SpriteRenderer>(); }

    private float smoothingMulti = 0.5f; //0.5f ~ 0.85f is fine
    private Vector2 accDirection;

    [SerializeField] float speed;
    [SerializeField] GameObject attack;

    private void Awake()
    {
        maxHp = 100;
    }

    public override void Start()
    {
        base.Start();
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
        Attack();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        accDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Attack()
    {
        //아마 나중에 결정되면? 쿨다운이나 탄창 등의 요소를 넣을 것.
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 attackDirection = (worldMousePos-(Vector2)transform.position).normalized;
            GameObject temp = Instantiate(attack);
            temp.transform.position = transform.position;
            temp.transform.right = attackDirection;
            temp.GetComponent<Attacks>().SetOwner("Player");
        }
    }
}
