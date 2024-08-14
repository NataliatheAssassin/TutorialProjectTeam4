using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    private Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }

    private Vector2 accDirection;
    private float speed;
    private float magazine; //magazine == źâ... �� ������� �Ф�
    public float GetMagazine() { return magazine; }
    public void SetMagazine(float value) { if (value <= 50) magazine = value; else { magazine = 50; } }

    [SerializeField] GameObject attack;

    private void Awake()
    {
        maxHp = 10f;

        speed = 150;
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
        hp = 0; //Ȥ�� ���߿� hp �ٸ� �߰��� ���� ����ؼ�, �߰���. ������ �� hp �ٸ� �������غ��� �̻� �� ����.
        Instantiate(deathEffect, transform.position, transform.rotation);
        SceneManager.LoadScene("Game_Over");
        Destroy(gameObject);
    }

    public void Recover(float amount)
    {
        if (hp + amount <= maxHp) { hp += amount; }
        else { hp = maxHp; }
    }
}
