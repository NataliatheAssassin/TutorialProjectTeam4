using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Sniper : Enemy
{
    private Animator anim { get => GetComponent<Animator>(); }

    [SerializeField] GameObject attack;

    private void Awake()
    {
        maxHp = 1;
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
        if (player != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized, 100f, LayerMask.GetMask("Player") | LayerMask.GetMask("Ground") | LayerMask.GetMask("Box") | LayerMask.GetMask("Interactive Object"));
            if (hit.collider != null && hit.collider.tag == "Player") transform.right = Vector2.Lerp(transform.right, (player.transform.position - transform.position).normalized, Time.deltaTime * 10);
        }
    }

    IEnumerator Status_1()
    {
        while (true)
        {
            //Wait until the player steps into its range && player's not dead
            while (true)
            {
                if (player != null)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position - transform.position).normalized, 100f, LayerMask.GetMask("Player") | LayerMask.GetMask("Ground") | LayerMask.GetMask("Box") | LayerMask.GetMask("Interactive Object"));
                    if (hit.collider != null && hit.collider.tag == "Player") { break; }
                }
                yield return null;
            }

            //Attack
            anim.SetTrigger("Attack");
            GameObject temp = Instantiate(attack, transform.position, transform.rotation);
            temp.GetComponent<Attacks>().SetOwner("Enemy");
            yield return new WaitForSeconds(3f);
        }
    }

    public void InstaShootSignal()
    {
        if (player != null)
        {
            transform.right = (player.transform.position - transform.position).normalized;
            anim.SetTrigger("Attack");
            GameObject temp = Instantiate(attack, transform.position, transform.rotation);
            temp.GetComponent<Attacks>().SetOwner("Enemy");
        }
    }
}