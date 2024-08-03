using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageNumberDisplay : MonoBehaviour
{
    TextMeshPro tmp { get => GetComponent<TextMeshPro>(); }

    private void Update()
    {
        tmp.text = "Stage " + StageSystem.stageNumber.ToString();
    }
}