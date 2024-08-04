using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Gunner : Enemy
{
    private Animator anim { get => GetComponent<Animator>(); }

    [SerializeField] protected GameObject attack;

    private void Awake()
    {
        maxHp = 2;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable() //만일의 경우에 대비.
    {
        StartCoroutine(Status_1());
    }

    protected override void Update()
    {
        base.Update();
        if (player != null && Vector2.Distance(transform.position, player.transform.position) < 5f) //사거리 제한이 있음
            transform.right = Vector2.Lerp(transform.right, (player.transform.position - transform.position).normalized, Time.deltaTime * 10);
    }

    IEnumerator Status_1()
    {
        while (true)
        {
            //Wait until the player steps into its range && player's not dead
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
        }
    }

    public void InstaShootSignal()
    {
        anim.SetTrigger("Attack");
        GameObject temp = Instantiate(attack, transform.position, transform.rotation);
        temp.GetComponent<Attacks>().SetOwner("Enemy");
    }
}