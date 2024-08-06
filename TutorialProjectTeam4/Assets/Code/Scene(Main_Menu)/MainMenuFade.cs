using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFade : MonoBehaviour
{
    SpriteRenderer sr { get => GetComponent<SpriteRenderer>(); }

    private void OnEnable()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        for (float i=0; i<=1; i += 0.03125f)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, i);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("In_Game");
        yield break;
    }
}
