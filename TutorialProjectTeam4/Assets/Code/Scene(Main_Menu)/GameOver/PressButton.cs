using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour

{
    [SerializeField] GameObject retryFade, quitFade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setRetry()
    {
        retryFade.SetActive(true);
    }

    public void setQuit()
    {
        quitFade.SetActive(true);
    }
}
