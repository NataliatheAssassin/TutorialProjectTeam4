using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Durian : Attacks
{
    private Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }
    private SpriteRenderer sr { get => GetComponent<SpriteRenderer>(); }

    private float speed;

    private void Awake()
    {
        damage = 2;
        speed = 15f;
    }

    private void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(DieAfter16Seconds());
    }

    private void Update()
    {
        transform.right = rb.velocity;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            if (Mathf.Abs(transform.position.x) >= 14.75f) rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            if (Mathf.Abs(transform.position.y) >=  6.75f) rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
        else if (other.GetComponent<Attacks>() != null && other.GetComponent<Attacks>().GetOwner() != owner)
        {
            other.GetComponent<Attacks>().Die();
            Die();
        }
        else if (other.GetComponent<Entity>() != null && other.tag != owner)
        {
            other.GetComponent<Entity>().TakeDamage(damage);
        }
    }

    IEnumerator DieAfter16Seconds()
    {
        for (float i = 0; i < 64; i++)
        {
            sr.color = new Color(i/64, sr.color.g-(i/256), sr.color.b-(i/256), 1);
            yield return new WaitForSeconds(0.25f);
        }
        Die();
        yield break;
    }

    public override void Die()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2.5f, LayerMask.GetMask("Player") | LayerMask.GetMask("Enemy"));
        foreach (var hit in hits)
        {
            if (hit.GetComponent<Entity>() != null) { hit.GetComponent<Entity>().TakeDamage(5); }
        }
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
