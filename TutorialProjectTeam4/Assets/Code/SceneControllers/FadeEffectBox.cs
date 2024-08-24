using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeEffectBox : MonoBehaviour
{
    Animator anim { get => GetComponent<Animator>(); }
    private bool onceClicked = false; //���� �޼��尡 1�� �̳��� �� �� �ҷ��� �ø� �����. �������������� �÷��̾�� ������ ���ÿ� �׾��� ���� ���.

    private void Start()
    {
        StartCoroutine(DisableClick());
    }

    IEnumerator DisableClick()
    {
        GetComponent<CanvasGroup>().interactable = true; GetComponent<CanvasGroup>().blocksRaycasts = true;
        yield return new WaitForSeconds(1f);
        GetComponent<CanvasGroup>().interactable = false; GetComponent<CanvasGroup>().blocksRaycasts = false;
        yield break;
    }

    public void Disappear(string where)
    {
        if (!onceClicked)
        {
            onceClicked = true;
            anim.SetTrigger("Disappear");
            StartCoroutine(ChangeScene(where));
        }
    }

    IEnumerator ChangeScene(string where)
    {
        yield return new WaitForSeconds(1f);

        if (where == "QuitGame") { Application.Quit(); }
        else if (where == "Start_Or_Retry")
        {
            SceneManager.LoadScene(FindObjectOfType<DataManager>().inGameData.savedStageNumber.ToString());
        }
        else { SceneManager.LoadScene(where); }
        yield break;
    }
}