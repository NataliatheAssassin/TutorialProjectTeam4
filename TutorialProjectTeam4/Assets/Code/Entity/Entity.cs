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
        hp = 0; //혹시 나중에 hp 바를 추가할 때를 대비해서, 추가함. 음수로 간 hp 바를 렌더링해봤자 이쁠 게 없음.
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
