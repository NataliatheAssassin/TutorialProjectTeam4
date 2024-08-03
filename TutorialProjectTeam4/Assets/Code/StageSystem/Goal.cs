using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private CameraController cameraController { get => FindObjectOfType<CameraController>(); }
    private Player player { get => FindObjectOfType<Player>(); }
    private StageSystem stageSystem { get => FindObjectOfType<StageSystem>();}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Move the Camera & Player
            cameraController.NextStage();
            player.transform.position = new Vector2(transform.position.x + 4.5f, player.transform.position.y);

            //Tidy up the previous scene
            Attacks[] allAttacks = FindObjectsOfType<Attacks>();
            for (int i=0; i<allAttacks.Length; i++) { Destroy(allAttacks[i].gameObject); }
            Entity[] allEntyties = FindObjectsOfType<Entity>();
            for (int i=0; i<allEntyties.Length; i++) { if (allEntyties[i].tag != "Player") { Destroy(allEntyties[i].gameObject);} }

            //Set up the next stage
            StageSystem.stageNumber++;
            stageSystem.SetStage();

            //Tidy up yourself too!!!
            Destroy(gameObject);
        }
    }
}
