using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject fadeEffectBox;

    public void Load_MainMenu_Scene() 
    { 
        fadeEffectBox.GetComponent<FadeEffectBox>().Disappear("Main_Menu");
    }
    public void Load_GameOver_Scene() 
    { 
        fadeEffectBox.GetComponent<FadeEffectBox>().Disappear("Game_Over"); 
    }
    public void Load_Ending_Scene()
    {
        fadeEffectBox.GetComponent<FadeEffectBox>().Disappear("Ending_Scene"); 
    }

    //�̰� ������
    public void Load_QuitGame() 
    {
        fadeEffectBox.GetComponent<FadeEffectBox>().Disappear("QuitGame"); 
    }

    //�̰͵� ������
    public void Start_Or_Retry() 
    {
        fadeEffectBox.GetComponent<FadeEffectBox>().Disappear("Start_Or_Retry"); 
    }

    //�̰͵����� ������
    public void Load_NextScene(int num)
    {
        fadeEffectBox.GetComponent<FadeEffectBox>().Disappear(num.ToString()); 
    }
}