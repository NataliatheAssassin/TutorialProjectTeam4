using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressSpaceToChangeScene : MonoBehaviour
{
    [SerializeField] GameObject mainMenuFade;

    void Start()
    {
        StartCoroutine("WaitTillSpace");
        StartCoroutine("Blink");
    }

    IEnumerator WaitTillSpace()
    {
        yield return new WaitForSeconds(1.75f);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space)) { break; }
            yield return null;
        }
        mainMenuFade.SetActive(true);
        yield break;
    }

    IEnumerator Blink()
    {
        transform.position = new Vector2(0, 30);
        yield return new WaitForSeconds(1.5f);

        while (true)
        {
            transform.position = new Vector2(0, -2.5f);
            yield return new WaitForSeconds(0.5f);
            transform.position = new Vector2(0, 30);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
