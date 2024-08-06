using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAdjust : MonoBehaviour
{
    Rigidbody2D rb { get => GetComponent<Rigidbody2D>(); }

    private void Start()
    {
        StartCoroutine(StopIt());
    }

    IEnumerator StopIt()
    {
        yield return new WaitForSeconds(1.4f);
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        yield break;
    }
}
