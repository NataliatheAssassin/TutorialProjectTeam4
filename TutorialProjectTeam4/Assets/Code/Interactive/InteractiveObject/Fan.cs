using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : InteractiveObject
{
    AreaEffector2D ae { get => GetComponent<AreaEffector2D>(); }
    SpriteRenderer sr { get => GetComponent<SpriteRenderer>(); }

    [SerializeField] float windStrength, windAngle;

    private void Start()
    {
        ae.forceMagnitude = windStrength;
        ae.forceAngle = windAngle;
    }

    public override void StatusChanged(bool status)
    {
        if (status == false)
        {
            ae.enabled = true;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
        else
        {
            ae.enabled = false;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
        }
    }
}