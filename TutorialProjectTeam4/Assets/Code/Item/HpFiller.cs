using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpFiller : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player != null && other.tag == "Player")
        {
            player.Recover(2f);
            Instantiate(obtainEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
