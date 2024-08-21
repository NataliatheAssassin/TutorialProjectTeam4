using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private static Vector3 position;

    private void Start()
    {
        PlayerPrefs.SetInt("StageNum", 1);
        PlayerPrefs.SetFloat("PlayerX", 0.0f);
        PlayerPrefs.SetFloat("PlayerY", 0.0f);
        position = new Vector3(0, 0, 0);
    }

    public static void ManualSave()
    {
        //�������� �ѹ� ����
        PlayerPrefs.SetInt("StageNumber", StageSystem.stageNumber);

        //�÷��̾� ���� ����
        Player player = GameObject.FindObjectOfType<Player>();
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        }
        PlayerPrefs.SetFloat("PlayerHp", player.GetHp());
        PlayerPrefs.SetFloat("PlayerMag", player.GetMagazine());

        //��� Enitities ���� ����
        Entity[] allEntities = FindObjectsOfType<Entity>();
        for(int i = 0; i < allEntities.Length; i++)
        {
            if (allEntities[i].tag != "Player")
            {
            PlayerPrefs.SetFloat(allEntities[i].ToString() + "X", allEntities[i].transform.position.x);
            PlayerPrefs.SetFloat(allEntities[i].ToString() + "Y", allEntities[i].transform.position.y);
            }
        }

        PlayerPrefs.Save();
    }

    /*
    public static void AutoSave()
    {

    }
    */
}