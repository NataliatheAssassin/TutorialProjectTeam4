using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    private Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }
    private Animator anim { get => GetComponent<Animator>(); }

    private Vector2 accDirection;
    private float speed;
    private float magazine; //magazine == źâ... �� ������� �Ф�
    public float GetMagazine() { return magazine; }
    public void SetMagazine(float value) { if (value <= 50) magazine = value; else { magazine = 50; } }
    private bool isControlable;

    [SerializeField] GameObject attack, mouse;

    private void Awake()
    {
        maxHp = 10f;

        speed = 150;
        isControlable = true;
    }

    protected override void Start()
    {
        //base.Start(); <-- ���� �ý��� ������ �ٸ��� ��, �׷��Ƿ� ��ȿȭ.
        hp = FindObjectOfType<DataManager>().inGameData.savedHp;
        magazine = FindObjectOfType<DataManager>().inGameData.savedMagazine;
        accDirection = Vector2.zero;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity * 0.5f;
        rb.velocity += accDirection * speed * Time.deltaTime;
    }

    private void Update()
    {
        if (isControlable)
        {
            Move();
            Attack();
            SeeMouseCursor();
            PressEsc();
        }
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
            anim.SetTrigger("Attack");
            magazine -= 1;
            GameObject temp = Instantiate(attack);
            temp.transform.position = transform.position;
            temp.transform.right = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
            temp.GetComponent<Attacks>().SetOwner("Player");
        }
    }

    private void SeeMouseCursor()
    {
        transform.right = (mouse.transform.position - transform.position).normalized;
    }

    public override void Die()
    {
        hp = 0; //Ȥ�� ���߿� hp �ٸ� �߰��� ���� ����ؼ�, �߰���. ������ �� hp �ٸ� �������غ��� �̻� �� ����.
        Instantiate(deathEffect, transform.position, transform.rotation);
        FindObjectOfType<SceneLoader>().Load_GameOver_Scene();
        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.InitializeInGameData(); //������ ������ �ʱ�ȭ.
        Destroy(gameObject);
    }

    public void Recover(float amount)
    {
        if (hp + amount <= maxHp) { hp += amount; }
        else { hp = maxHp; }
    }

    public void WhenTouchingGoal()
    {
        isControlable = false;
        rb.velocity = new Vector2(10, 0);
    }

    public void GetCurrentPlayerData()
    {
        DataManager dataManager = FindObjectOfType<DataManager>();

        dataManager.inGameData.savedHp = hp;
        dataManager.inGameData.savedMagazine = magazine;
        dataManager.SaveToJson();
    }

    private void PressEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Die();
        }
    }
}
