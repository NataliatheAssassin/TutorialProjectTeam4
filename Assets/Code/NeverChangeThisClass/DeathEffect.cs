using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.125f);
    }
}
