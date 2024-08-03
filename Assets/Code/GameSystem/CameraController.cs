using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : StageSystem
{
    //스테이지가 넘어감에 따라 바뀌는 카메라의 움직임을 제어하기 위한 코드.

    public void MoveToNextStage()
    {
        transform.position = new Vector3(transform.position.x + 36, transform.position.y, transform.position.z);
    }

    public void MoveToPreviousStage()
    {
        transform.position = new Vector3(transform.position.x - 36, transform.position.y, transform.position.z);
    }
}
