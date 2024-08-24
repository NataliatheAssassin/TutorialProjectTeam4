using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private Animator anim { get => GetComponent<Animator>(); }

    [SerializeField] GameObject[] attacks;

    private void Awake()
    {
        maxHp = 50;
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
        if (player != null) transform.right = Vector2.Lerp(transform.right, (player.transform.position - transform.position).normalized, Time.deltaTime * 10);
    }
    //여기부터 고치기!

    IEnumerator Status_1()
    {
        //처음엔 살짝 기다려주기
        yield return new WaitForSeconds(2f);

        while (true)
        {
            //두리안 공격(?) --> 튕기는 폭탄 공격 --> 탄창이 없을 경우를 대비해, 이를 폭발시킬 시 주변에 5데미지를 주게 만들어놓음.
            for (int i=0; i<6; i++)
            {
                anim.SetTrigger("Attack");
                yield return new WaitForSeconds(0.125f);
                GameObject temp = Instantiate(attacks[0], transform.position, transform.rotation);
                temp.GetComponent<Attacks>().SetOwner("Enemy");
                yield return new WaitForSeconds(2f);
            }

            //패턴 사이사이에 기다려주는 시간.
            yield return new WaitForSeconds(2f);

            //총알 난사 공격
            anim.SetTrigger("Bullet_Rampage");
            for (int i=0; i<160; i++)
            {
                GameObject temp = Instantiate(attacks[1]);
                temp.transform.position = transform.position;
                temp.transform.right = new Vector2(Random.Range(-1f, 0f), Random.Range(-1f, 1f));
                temp.GetComponent<Attacks>().SetOwner("Enemy");
                yield return new WaitForSeconds(0.0625f);
            }
            anim.SetTrigger("Bullet_Rampage_Done");

            //패턴 사이사이에 기다려주는 시간.
            yield return new WaitForSeconds(4f);
        }
    }

    public override void Die()
    {
        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.InitializeInGameData();
        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.Load_Ending_Scene();
        hp = 0; //혹시 나중에 hp 바를 추가할 때를 대비해서, 추가함. 음수로 간 hp 바를 렌더링해봤자 이쁠 게 없음.
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}