using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineFiller : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player != null && other.tag == "Player")
        {
            player.SetMagazine(player.GetMagazine() + 10);
            Instantiate(obtainEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
