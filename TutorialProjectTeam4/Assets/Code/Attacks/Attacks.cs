using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    protected string owner; public void SetOwner(string value) { owner = value; } public string GetOwner() { return owner; }
    protected float damage; //set with awake(inherit)

    [SerializeField] protected GameObject deathEffect;

    public virtual void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Entity>() != null && other.tag != owner)
        {
            other.GetComponent<Entity>().TakeDamage(damage);
            Die();
        }
        else if (other.tag == "Ground" || other.tag == "Interactive Object")
        {
            Die();
        }
    }
}
