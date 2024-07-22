using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageElementController : StageSystem
{
    [SerializeField] private GameObject[] elementsOfStages = new GameObject[5];

    public void ChangeStage(bool isGoingToNext)
    {
        Attacks[] bulletsOfPreviousStage = FindObjectsOfType<Attacks>();
        for (int i = 0; i < bulletsOfPreviousStage.Length; i++)
        {
            Destroy(bulletsOfPreviousStage[i].gameObject);
        }

        elementsOfStages[currentStageNumber].SetActive(false);
        if (isGoingToNext)
        {
            elementsOfStages[currentStageNumber + 1].SetActive(true);
            currentStageNumber++;
        }
        else
        {
            elementsOfStages[currentStageNumber - 1].SetActive(true);
            currentStageNumber--;
        }
    }
}
