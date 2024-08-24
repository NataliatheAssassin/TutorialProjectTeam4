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

    private void OnEnable() //������ ��쿡 ���.
    {
        StartCoroutine(Status_1());
    }

    protected override void Update()
    {
        base.Update();
        if (player != null) transform.right = Vector2.Lerp(transform.right, (player.transform.position - transform.position).normalized, Time.deltaTime * 10);
    }
    //������� ��ġ��!

    IEnumerator Status_1()
    {
        //ó���� ��¦ ��ٷ��ֱ�
        yield return new WaitForSeconds(2f);

        while (true)
        {
            //�θ��� ����(?) --> ƨ��� ��ź ���� --> źâ�� ���� ��츦 �����, �̸� ���߽�ų �� �ֺ��� 5�������� �ְ� ��������.
            for (int i=0; i<6; i++)
            {
                anim.SetTrigger("Attack");
                yield return new WaitForSeconds(0.125f);
                GameObject temp = Instantiate(attacks[0], transform.position, transform.rotation);
                temp.GetComponent<Attacks>().SetOwner("Enemy");
                yield return new WaitForSeconds(2f);
            }

            //���� ���̻��̿� ��ٷ��ִ� �ð�.
            yield return new WaitForSeconds(2f);

            //�Ѿ� ���� ����
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

            //���� ���̻��̿� ��ٷ��ִ� �ð�.
            yield return new WaitForSeconds(4f);
        }
    }

    public override void Die()
    {
        DataManager dataManager = FindObjectOfType<DataManager>();
        dataManager.InitializeInGameData();
        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.Load_Ending_Scene();
        hp = 0; //Ȥ�� ���߿� hp �ٸ� �߰��� ���� ����ؼ�, �߰���. ������ �� hp �ٸ� �������غ��� �̻� �� ����.
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}