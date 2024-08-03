using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Gunner : Enemy
{
    private Animator anim { get => GetComponent<Animator>(); }

    private void Awake()
    {
        maxHp = 2;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable() //StageElementController 때문에 SetActive(false)가 됐다가 true가 되는 경우에, coroutine이 끊길 수 있음.
    {
        StartCoroutine(Status_1());
    }

    private void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.transform.position) < 5f)
            transform.right = Vector2.Lerp(transform.right, (player.transform.position - transform.position).normalized, Time.deltaTime * 10);
    }

    IEnumerator Status_1()
    {
        //Wait until the player steps into its range
        while (true)
        {
            if (player != null && Vector2.Distance(transform.position, player.transform.position) < 5f) { break; }
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        //Attack
        anim.SetTrigger("Attack");
        GameObject temp = Instantiate(attack, transform.position, transform.rotation);
        temp.GetComponent<Attacks>().SetOwner("Enemy");
        yield return new WaitForSeconds(1f);
        StartCoroutine(Status_1());
        yield break;
    }
}