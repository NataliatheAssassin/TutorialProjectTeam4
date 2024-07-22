using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Strongest : Enemy
{
    private void Awake()
    {
        maxHp = 200;
    }

    public override void Start()
    {
        base.Start();
        StartCoroutine(UpdateDirection());
    }

    private void OnEnable() //StageElementController 때문에 SetActive(false)가 됐다가 true가 되는 경우에, coroutine이 끊길 수 있음.
    {
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
        for (int i=0; i<Random.Range(1, 6); i++)
        {
            GameObject temp = Instantiate(attack, transform.position, transform.rotation);
            temp.GetComponent<Attacks>().SetOwner("Enemy"); 
            yield return new WaitForSeconds(0.125f);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(UpdateDirection());
        yield break;
    }
}