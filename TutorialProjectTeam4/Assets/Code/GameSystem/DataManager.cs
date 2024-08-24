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

    //�׽�Ʈ.
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
        if (inGameData.savedHp <= 0) //��� ����ٰ� "���۵� ������"���� �˻��ϴ� �ڵ带 ���� ���� ����.
        {
            InitializeInGameData();
            SaveToJson();
        }
    }

    private void OnApplicationQuit()
    {
        if (FindObjectOfType<Player>() != null) //���� �÷��� ���߿� ���� ���,
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
