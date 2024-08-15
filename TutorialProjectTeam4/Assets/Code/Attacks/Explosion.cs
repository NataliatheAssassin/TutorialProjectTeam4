using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Attacks
{
    private float damage;
    private float explosionRadius = 2f;

    [SerializeField] private GameObject DeathEffect;

    private void Awake()
    {
        damage = 4f;
    }

    private void Start()
    {
        Explode();
    }

    private void Explode()
    {
        
        if (DeathEffect != null)
        {
            Instantiate(DeathEffect, transform.position, transform.rotation);
        }

        
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var hitCollider in hitColliders)
        {
            Player player = hitCollider.GetComponent<Player>();

            
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }

        
        Destroy(gameObject);
    }
}
