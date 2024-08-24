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

    //이건 예외임
    public void Load_QuitGame() 
    {
        fadeEffectBox.GetComponent<FadeEffectBox>().Disappear("QuitGame"); 
    }

    //이것도 예외임
    public void Start_Or_Retry() 
    {
        fadeEffectBox.GetComponent<FadeEffectBox>().Disappear("Start_Or_Retry"); 
    }

    //이것도오오 예외임
    public void Load_NextScene(int num)
    {
        fadeEffectBox.GetComponent<FadeEffectBox>().Disappear(num.ToString()); 
    }
}