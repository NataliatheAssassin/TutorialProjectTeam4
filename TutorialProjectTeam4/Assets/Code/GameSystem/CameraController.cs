using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void NextStage()
    {
        transform.position = new Vector3(transform.position.x + 36, transform.position.y, transform.position.z);
    }
}
