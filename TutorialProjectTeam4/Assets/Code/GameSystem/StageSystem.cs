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

    private void Start()
    {
        stageNumber = 1;
        SetStage();
    }

    public void SetStage()
    {
        //여기 밑에 있는 것들은 일단 테스트용... ㅎㅎ
        if (stageNumber == 1) //tutorail 1
        {
            Instantiate(box[0], new Vector2(0f, 0f), transform.rotation);
            Instantiate(item[0], new Vector2(12f, -4.5f), transform.rotation);
            Instantiate(item[1], new Vector2(12f, 4.5f), transform.rotation);
        }
        else if (stageNumber == 2) //tutorial 2
        {
            Instantiate(box[0], new Vector2(23f, -7f), transform.rotation);

            Instantiate(enemy[0], new Vector2(29.5f, -3.5f), transform.rotation);
            Instantiate(enemy[0], new Vector2(43f, 3.5f), transform.rotation);
            Instantiate(enemy[2], new Vector2(29f, 4f), transform.rotation);

            Instantiate(enemy[0], new Vector2(40f, -4f), transform.rotation);
            Instantiate(enemy[3], new Vector2(46f, -4f), transform.rotation);
        }
        else if (stageNumber == 3) //stage 1
        {
        }
        else if (stageNumber == 4) //stage 2
        {
            Instantiate(box[2], new Vector2(105f, 0f), transform.rotation);
        }
        else if (stageNumber == 5)
        {

        }
    }

    public void loadStage()
    {
        
    }
}
