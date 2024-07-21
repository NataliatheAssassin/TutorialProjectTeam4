using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float hp;
    public float maxHp;

    [SerializeField] protected GameObject deathEffect;

    public virtual void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(float damage)
    {
        if (hp - damage > 0) { hp -= damage; }
        else { Die(); }
    }

    public void Die()
    {
        hp = 0;
        GameObject temp = Instantiate(deathEffect);
        temp.transform.position = transform.position;
        Destroy(gameObject);
    }
}
