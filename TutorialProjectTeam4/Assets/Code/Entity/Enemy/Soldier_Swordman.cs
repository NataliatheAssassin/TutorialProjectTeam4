using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Swordman : Enemy
{
    private Animator anim { get => GetComponent<Animator>(); }

    private void Awake()
    {
        maxHp = 3;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable() //만일의 경우에 대비.
    {
        StartCoroutine(Status_1());
    }

    private void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.transform.position) < 2f)
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
            yield return new WaitForSeconds(0.25f);

            //Attack
            anim.SetTrigger("Attack");
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + transform.right, 0.5f, LayerMask.GetMask("Player"));
            foreach (var hit in hits)
            {
                if (hit.gameObject.tag == "Player")
                {
                    hit.gameObject.GetComponent<Entity>().TakeDamage(1);
                    break;
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}