using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractiveObjectController
{
    private bool isStillPressed;
    [SerializeField] float timerDuration;
    //public float x;
    //public float y;

    Animator anim { get => GetComponent<Animator>(); }

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isTouchingMouse == true && isStillPressed == false)
        {
            anim.SetTrigger("Pressed");
            StartCoroutine(KeepBeingPressed());
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
    
    IEnumerator KeepBeingPressed()
    {
        isActivated = true; for (int i = 0; i < children.Length; i++) { children[i].StatusChanged(isActivated); }
        isStillPressed = true;
        yield return new WaitForSeconds(timerDuration);

        isActivated = false; for (int i = 0; i < children.Length; i++) { children[i].StatusChanged(isActivated); }
        isStillPressed = false;
        anim.SetTrigger("Idle");
        yield break;
    }
}