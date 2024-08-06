using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker_Dynamic : InteractiveObject
{
    [SerializeField] Vector2 startPos, endPos;
    private Vector2 destination;

    public override void StatusChanged(bool status)
    {
        if (status == true) { destination = endPos; }
        else                { destination = startPos; }
    }

    private void Update()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, destination, Time.deltaTime*10);
    }
}