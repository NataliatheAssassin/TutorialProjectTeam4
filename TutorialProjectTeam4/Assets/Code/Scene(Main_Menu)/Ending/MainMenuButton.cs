using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
        //Debug.Log("mainmenu button clicked");
    }
}
