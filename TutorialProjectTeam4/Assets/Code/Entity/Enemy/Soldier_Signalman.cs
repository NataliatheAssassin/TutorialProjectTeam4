using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Signalman : Enemy
{
    private Animator anim { get => GetComponent<Animator>(); }

    private void Awake()
    {
        maxHp = 5;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable() //만일의 경우에 대비.
    {
        StartCoroutine(Status_1());
    }

    private void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.transform.position) < 7.5f)
            transform.right = Vector2.Lerp(transform.right, (player.transform.position - transform.position).normalized, Time.deltaTime * 10);
    }

    IEnumerator Status_1()
    {
        while (true)
        {
            //Wait until the player steps into its range && player's not dead
            while (true)
            {
                if (player != null && Vector2.Distance(transform.position, player.transform.position) < 7.5f) { break; }
                yield return null;
            }
            yield return new WaitForSeconds(0.25f);

            //Attack
            anim.SetTrigger("Attack");
            Soldier_Gunner[] soldier_gunners = FindObjectsOfType<Soldier_Gunner>();
            Soldier_Sniper[] soldier_snipers = FindObjectsOfType<Soldier_Sniper>();
            foreach (var gunner in soldier_gunners) { gunner.gameObject.GetComponent<Soldier_Gunner>().InstaShootSignal(); }
            foreach (var sniper in soldier_snipers) { sniper.gameObject.GetComponent<Soldier_Sniper>().InstaShootSignal(); }
            yield return new WaitForSeconds(0.25f);
        }
    }
}