using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Weakest : Enemy
{
    private void Awake()
    {
        maxHp = 50;
    }

    public override void Start()
    {
        base.Start();
        StartCoroutine(UpdateDirection());
    }

    IEnumerator UpdateDirection()
    {
        transform.right = player.transform.position - transform.position;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ShootPlayer());
        yield break;
    }

    IEnumerator ShootPlayer()
    {
        GameObject temp = Instantiate(attack, transform.position, transform.rotation);
        temp.GetComponent<Attacks>().SetOwner("Enemy");
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(UpdateDirection());
        yield break;
    }
}