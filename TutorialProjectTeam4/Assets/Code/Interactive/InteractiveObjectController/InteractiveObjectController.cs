using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveObjectController : MonoBehaviour
{
    //���콺 ������ ��ư���� ������ �� �ִ� Object�� �ǹ���.
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