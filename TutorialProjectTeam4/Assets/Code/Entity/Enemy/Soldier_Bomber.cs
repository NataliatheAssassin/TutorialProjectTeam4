using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Bomber : Enemy
{
    private Animator anim { get => GetComponent<Animator>(); }
    private bool youCanOnlyDieOnce = false;

    private void Awake()
    {
        maxHp = 2;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        StartCoroutine(Status_1());
    }

    protected override void Update()
    {
        base.Update();
        if (player != null)
            transform.right = Vector2.Lerp(transform.right, (player.transform.position - transform.position).normalized, Time.deltaTime * 10);
    }

    IEnumerator Status_1()
    {
        while (true)
        {
            //Wait until the player steps into its range && player's not dead
            while (true)
            {
                if (player != null && Vector2.Distance(transform.position, player.transform.position) < 2f) { break; }
                yield return null;
            }

            // ÀÚÆø
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(0.1f);
            Die();
            yield break;
        }
    }

    public override void Die()
    {
        if (!youCanOnlyDieOnce)
        {
            youCanOnlyDieOnce = true;
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2.5f, LayerMask.GetMask("Player") | LayerMask.GetMask("Box") | LayerMask.GetMask("Enemy"));
            foreach (var hit in hits) { if (hit.GetComponent<Entity>() != null) { hit.GetComponent<Entity>().TakeDamage(5); } }

            Collider2D[] hits2 = Physics2D.OverlapCircleAll(transform.position, 2.5f, LayerMask.GetMask("Attack"));
            foreach (var hit in hits2) { if (hit.GetComponent<Attacks>() != null) { hit.GetComponent<Attacks>().Die(); } }

            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
