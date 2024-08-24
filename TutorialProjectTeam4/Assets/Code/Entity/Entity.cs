using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected float hp, maxHp; public float GetHp() { return hp; }
    [SerializeField] protected GameObject deathEffect;

    protected virtual void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(float damage)
    {
        if (hp - damage > 0) { hp -= damage; }
        else { Die(); }
    }

    public virtual void Die()
    {
        if (deathEffect != null)
        {
            hp = 0; //Ȥ�� ���߿� hp �ٸ� �߰��� ���� ����ؼ�, �߰���. ������ �� hp �ٸ� �������غ��� �̻� �� ����.
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
