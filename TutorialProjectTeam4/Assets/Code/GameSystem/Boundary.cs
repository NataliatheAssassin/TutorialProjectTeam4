using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : StageSystem
{
    //다음 스테이지로 넘어가거나, 이전 스테이지로 돌아갈 수 있도록 해주는 "선형 콜라이더" 형태의 경계를 위한 코드.

    Player player { get => FindObjectOfType<Player>(); }
    CameraController cameraController { get => FindObjectOfType<CameraController>(); }
    StageElementController stageElementController { get => FindObjectOfType<StageElementController>(); }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (player.X_VelocityOfPlayer() > 0) 
            { 
                player.transform.position = new Vector2(transform.position.x + 0.75f, player.transform.position.y); 
                cameraController.MoveToNextStage();
                stageElementController.ChangeStage(true);
            }
            else if (player.X_VelocityOfPlayer() < 0) 
            {
                player.transform.position = new Vector2(transform.position.x - 0.75f, player.transform.position.y);
                cameraController.MoveToPreviousStage(); 
                stageElementController.ChangeStage(false);
            }
            else return;
        }
    }
}
