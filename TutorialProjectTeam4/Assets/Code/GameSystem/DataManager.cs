using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class DataManager : MonoBehaviour
{
    public InGameData inGameData = new InGameData();

    public void SaveToJson()
    {
        string filePath = Application.persistentDataPath + "/InGameData.json";
        File.WriteAllText(filePath, JsonUtility.ToJson(inGameData));
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/InGameData.json";
        inGameData = JsonUtility.FromJson<InGameData>(File.ReadAllText(filePath));
    }

    //테스트.
    public void InitializeInGameData()
    {
        inGameData.savedHp = 10;
        inGameData.savedMagazine = 50;
        inGameData.savedStageNumber = 1;
        SaveToJson();
    }

    private void Awake()
    {
        LoadFromJson();
        if (inGameData.savedHp <= 0) //사실 여기다가 "조작된 데이터"인지 검사하는 코드를 넣을 수도 있음.
        {
            InitializeInGameData();
            SaveToJson();
        }
    }

    private void OnApplicationQuit()
    {
        if (FindObjectOfType<Player>() != null) //게임 플레이 도중에 나간 경우,
            FindObjectOfType<Player>().GetCurrentPlayerData();
        SaveToJson();
    }
}

//[System.Serializable] <-- to makethis visible
public class InGameData
{
    public float savedHp;
    public float savedMagazine;
    public int savedStageNumber;
}
