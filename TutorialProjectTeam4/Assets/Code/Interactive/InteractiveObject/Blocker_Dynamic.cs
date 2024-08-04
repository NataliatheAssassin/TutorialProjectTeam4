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

    //만일 나중에 Instantiate를 통해 배치하게 된다면 사용. 그러나 지금은 그냥 스테이지 상에 직접 배치할 예정임.
    public void SetSPEP(Vector2 startPos, Vector2 endPos) //set startPos and endPos
    {
        this.startPos = startPos;
        this.endPos = endPos;
    }
}