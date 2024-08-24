using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    SceneLoader sceneLoader { get => FindObjectOfType<SceneLoader>(); }
    [SerializeField] int nextSceneNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DataManager dataManager = FindObjectOfType<DataManager>();
            dataManager.inGameData.savedStageNumber++;
            FindObjectOfType<Player>().WhenTouchingGoal();
            FindObjectOfType<Player>().GetCurrentPlayerData();
            sceneLoader.Load_NextScene(nextSceneNumber);
        }
    }
}
