using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    I_Groundable parentI_Groundable { get => GetComponentInParent<I_Groundable>(); }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground") parentI_Groundable.isGrounded = true;
    }
    //can be removed if the lag comes
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground") parentI_Groundable.isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground") parentI_Groundable.isGrounded = false;
    }
}