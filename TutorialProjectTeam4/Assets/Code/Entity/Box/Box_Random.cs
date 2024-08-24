using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Random : Box
{
    [SerializeField] GameObject bomb, food, magazine;
    private bool youCanOnlyDieOnce = false;

    private void Awake()
    {
        maxHp = 5;
        mass = 0.5f;
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void Die()
    {
        if (!youCanOnlyDieOnce && deathEffect != null)
        {
            youCanOnlyDieOnce = true;

            int randomInt = Random.Range(0, 3); //0~2 (0�̻�, 3�̸���)
            if (randomInt == 0)
            {
                Instantiate(bomb, transform.position, transform.rotation);
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2.5f, LayerMask.GetMask("Player") | LayerMask.GetMask("Box") | LayerMask.GetMask("Enemy"));
                foreach (var hit in hits) { if (hit.GetComponent<Entity>() != null) { hit.GetComponent<Entity>().TakeDamage(5); } }

                Collider2D[] hits2 = Physics2D.OverlapCircleAll(transform.position, 2.5f, LayerMask.GetMask("Attack"));
                foreach (var hit in hits2) { if (hit.GetComponent<Attacks>() != null) { hit.GetComponent<Attacks>().Die(); } }
            }
            else if (randomInt == 1)
            {
                Instantiate(food, transform.position, transform.rotation);
                Instantiate(deathEffect, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(magazine, transform.position, transform.rotation);
                Instantiate(deathEffect, transform.position, transform.rotation);
            }

            hp = 0; //Ȥ�� ���߿� hp �ٸ� �߰��� ���� ����ؼ�, �߰���. ������ �� hp �ٸ� �������غ��� �̻� �� ����.
            Destroy(gameObject);
        }
    }
}
