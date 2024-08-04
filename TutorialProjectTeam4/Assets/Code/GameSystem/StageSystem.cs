using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    // --> enemy[0]:Gunner / enemy[1]:Sniper / enemy[2]:Swordman / enemy[3]:Signalman
    // --> box[0]:Wooden / box[1]:Iron
    // --> item[0]:MagazineFiller / item[1]:HpFiller
 
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
            Instantiate(enemy[0], new Vector2(5f, 5f), transform.rotation);
            Instantiate(enemy[1], new Vector2(5f, 2f), transform.rotation);
            Instantiate(enemy[2], new Vector2(5f, -2f), transform.rotation);
            Instantiate(enemy[3], new Vector2(5f, -5f), transform.rotation);

            Instantiate(box[0], new Vector2(0f, 4f), transform.rotation);
            Instantiate(box[1], new Vector2(0f, -4f), transform.rotation);

            Instantiate(item[0], new Vector2(-5f, 3f), transform.rotation);
            Instantiate(item[1], new Vector2(-5f, -3f), transform.rotation);
        }
        else if (stageNumber == 2)
        {

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
