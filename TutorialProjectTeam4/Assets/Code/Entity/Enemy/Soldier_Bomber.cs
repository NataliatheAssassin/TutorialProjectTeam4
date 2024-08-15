using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Bomber : Enemy
{
    private Animator anim { get => GetComponent<Animator>(); }
    [SerializeField] protected GameObject Explosion; // ÀÚÆøÇÒ ¶§ »ç¿ëÇÒ Æø¹ß ÇÁ¸®ÆÕ

    private void Awake()
    {
        maxHp = 4;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        StartCoroutine(Status_1());
    }

    protected override void Update()
    {
        base.Update();
        if (player != null && Vector2.Distance(transform.position, player.transform.position) < 3f) // ÀÚÆø °Å¸® ¼³Á¤
            transform.right = Vector2.Lerp(transform.right, (player.transform.position - transform.position).normalized, Time.deltaTime * 10);
    }

    IEnumerator Status_1()
    {
        while (true)
        {
            //Wait until the player steps into its range && player's not dead
            while (true)
            {
                if (player != null && Vector2.Distance(transform.position, player.transform.position) < 2f) { break; }
                yield return null;
            }
            yield return new WaitForSeconds(1f);

            // ÀÚÆø
            anim.SetTrigger("Attack");
            GameObject explosion = Instantiate(Explosion, transform.position, transform.rotation);
            explosion.GetComponent<Explosion>().SetOwner("Enemy");
            yield return new WaitForSeconds(1f);
        }
    }

    public void InstaExplodeSignal()
    {
        anim.SetTrigger("Attack");
        GameObject explosion = Instantiate(Explosion, transform.position, transform.rotation);
        explosion.GetComponent<Explosion>().SetOwner("Enemy");
    }
}
