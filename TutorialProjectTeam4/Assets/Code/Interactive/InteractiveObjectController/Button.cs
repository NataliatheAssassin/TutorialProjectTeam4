using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractiveObjectController
{
    private bool isStillPressed;
    [SerializeField] float timerDuration;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isTouchingMouse == true && isStillPressed == false)
        {
            StartCoroutine(KeepBeingPressed());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Mouse") { isTouchingMouse = true; }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Mouse") { isTouchingMouse = false; }
    }

    IEnumerator KeepBeingPressed()
    {
        isActivated = true; for (int i = 0; i < children.Length; i++) { children[i].StatusChanged(isActivated); }
        isStillPressed = true;
        yield return new WaitForSeconds(timerDuration);

        isActivated = false; for (int i = 0; i < children.Length; i++) { children[i].StatusChanged(isActivated); }
        isStillPressed = false;
        yield break;
    }
}