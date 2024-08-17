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

    public static void Save()
    {
        GameObject player = GameObject.Find("Player");
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerX", position.x);
            PlayerPrefs.SetFloat("PlayerY", position.y);
        }

        Entity[] allEntyties = FindObjectsOfType<Entity>();
        for(int i = 0; i < allEntyties.Length; i++)
        {

        }

        PlayerPrefs.Save();
    }
}