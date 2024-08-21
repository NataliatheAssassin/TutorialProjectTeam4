using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player != null && other.tag == "Player")
        {
            other.GetComponent<Entity>().TakeDamage(3f);
            Instantiate(obtainEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
