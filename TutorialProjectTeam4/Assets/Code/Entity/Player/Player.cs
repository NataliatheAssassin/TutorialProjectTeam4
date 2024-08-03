using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    private Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }

    private Vector2 accDirection;
    private float speed = 150;
    private float magazine; //magazine == 탄창... 전 몰랐어요 ㅠㅠ
    public float GetMagazine() { return magazine; }
    public void SetMagazine(float value) { if (value <= 50) magazine = value; else { magazine = 50; } }

    [SerializeField] GameObject attack;

    private void Awake()
    {
        maxHp = 10f;

        magazine = 50;
    }

    protected override void Start()
    {
        base.Start();
        accDirection = Vector2.zero;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity * 0.5f;
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
        if (Input.GetMouseButtonDown(0) && magazine >= 1)
        {
            magazine -= 1;
            GameObject temp = Instantiate(attack);
            temp.transform.position = transform.position;
            temp.transform.right = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
            temp.GetComponent<Attacks>().SetOwner("Player");
        }
    }

    public override void Die()
    {
        hp = 0; //혹시 나중에 hp 바를 추가할 때를 대비해서, 추가함. 음수로 간 hp 바를 렌더링해봤자 이쁠 게 없음.
        Instantiate(deathEffect, transform.position, transform.rotation);
        SceneManager.LoadScene("In_Game");
        Destroy(gameObject);
    }
}
