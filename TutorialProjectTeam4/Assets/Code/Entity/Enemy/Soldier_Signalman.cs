using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Signalman : Enemy
{
    private Animator anim { get => GetComponent<Animator>(); }

    private void Awake()
    {
        maxHp = 3;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable() //������ ��쿡 ���.
    {
        StartCoroutine(Status_1());
    }

    protected override void Update()
    {
        base.Update();
        if (player != null) transform.right = Vector2.Lerp(transform.right, (player.transform.position - transform.position).normalized, Time.deltaTime * 10);
    }

    IEnumerator Status_1()
    {
        while (true)
        {
            //Attack �׳� �������� �� �ֱ⸸ �ص� �÷��̾��� ��ġ�� �˾Ƴ�.
            anim.SetTrigger("Attack");
            Soldier_Gunner[] soldier_gunners = FindObjectsOfType<Soldier_Gunner>();
            Soldier_Sniper[] soldier_snipers = FindObjectsOfType<Soldier_Sniper>();
            foreach (var gunner in soldier_gunners) { gunner.gameObject.GetComponent<Soldier_Gunner>().InstaShootSignal(); }
            foreach (var sniper in soldier_snipers) { sniper.gameObject.GetComponent<Soldier_Sniper>().InstaShootSignal(); }
            yield return new WaitForSeconds(0.125f);
        }
    }
}