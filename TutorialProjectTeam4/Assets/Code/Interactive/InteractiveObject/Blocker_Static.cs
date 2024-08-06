using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker_Static : InteractiveObject
{
    BoxCollider2D bc { get => GetComponent<BoxCollider2D>(); }
    SpriteRenderer sr { get => GetComponent<SpriteRenderer>(); }

    public override void StatusChanged(bool status)
    {
        if (status == true)
        {
            bc.enabled = false;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.25f);
        }
        else
        {
            bc.enabled = true;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }
}