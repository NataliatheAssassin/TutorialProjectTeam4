using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractiveObjectController
{
    Animator anim { get => GetComponent<Animator>(); }

    protected override void Start()
    {
        base.Start();
        if (isActivated) { anim.SetTrigger("Pressed"); }
        else { anim.SetTrigger("Idle"); }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isTouchingMouse == true)
        {
            isActivated = !isActivated;

            if (isActivated) { anim.SetTrigger("Pressed"); }
            else             { anim.SetTrigger("Idle"); }

            for (int i = 0; i < children.Length; i++) { children[i].StatusChanged(isActivated); }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Mouse") { isTouchingMouse = true; }
        /*
        if (other.tag == "Box")
        {
            for (int i = 0; i < children.Length; i++) { children[i].StatusChanged(!isActivated); }
        }
        */
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Mouse") { isTouchingMouse = false; }
        /*
        if (other.tag == "Box")
        {
            for (int i = 0; i < children.Length; i++) { children[i].StatusChanged(isActivated); }
        }
        */
    }
}