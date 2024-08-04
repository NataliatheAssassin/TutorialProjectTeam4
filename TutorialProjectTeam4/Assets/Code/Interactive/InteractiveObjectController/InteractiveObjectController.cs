using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveObjectController : MonoBehaviour
{
    //마우스 오른쪽 버튼으로 조작할 수 있는 Object를 의미함.
    protected InteractiveObject[] children { get => GetComponentsInChildren<InteractiveObject>(); }

    protected bool isActivated;
    protected bool isTouchingMouse;

    protected virtual void Start()
    {
        isActivated = false;
        isTouchingMouse = false;

        for (int i=0; i<children.Length; i++) { children[i].StatusChanged(isActivated); }
    }
}