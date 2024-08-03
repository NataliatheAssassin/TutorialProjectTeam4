using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public static int stageNumber = 1;

    [SerializeField] GameObject[] enemy, box, item;

    private void OnEnable()
    {
        SetStage();
    }

    public void SetStage()
    {
        //여기 밑에 있는 것들은 일단 테스트용... ㅎㅎ
        if (stageNumber == 1)
        {
            Instantiate(enemy[0], new Vector2(-5f, 0f), transform.rotation);
            Instantiate(enemy[1], new Vector2(5f, 0f), transform.rotation);
            Instantiate(enemy[2], new Vector2(0f, 5f), transform.rotation);
            Instantiate(enemy[3], new Vector2(0f, -5f), transform.rotation);
        }
        else if (stageNumber == 2)
        {
            Instantiate(box[0], new Vector2(36f, 5f), transform.rotation);
            Instantiate(box[1], new Vector2(36f, -5f), transform.rotation);
            Instantiate(item[0], new Vector2(36f, 7f), transform.rotation);
        }
        else if (stageNumber == 3)
        {

        }
        else if (stageNumber == 4)
        {

        }
        else if (stageNumber == 5)
        {

        }
    }
}
