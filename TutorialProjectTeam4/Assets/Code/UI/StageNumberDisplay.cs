using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageNumberDisplay : MonoBehaviour
{
    TextMeshPro tmp { get => GetComponent<TextMeshPro>(); }
    int stageNumber { get => FindObjectOfType<DataManager>().inGameData.savedStageNumber; }

    private void Start()
    {
        tmp.text = "Stage " + stageNumber.ToString();
    }
}