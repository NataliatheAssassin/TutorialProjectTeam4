using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressSpaceToChangeScene : MonoBehaviour
{
    [SerializeField] GameObject sceneLoader;

    void Start()
    {
        StartCoroutine("WaitTillSpace");
        StartCoroutine("Blink");
    }

    IEnumerator WaitTillSpace()
    {
        yield return new WaitForSeconds(2.25f);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space)) { break; }
            yield return null;
        }
        sceneLoader.GetComponent<SceneLoader>().Load_NextScene(FindObjectOfType<DataManager>().inGameData.savedStageNumber);
        gameObject.SetActive(false);
        yield break;
    }

    IEnumerator Blink()
    {
        transform.position = new Vector2(0, 30);
        yield return new WaitForSeconds(2.25f);

        while (true)
        {
            transform.position = new Vector2(0, -2.5f);
            yield return new WaitForSeconds(0.5f);
            transform.position = new Vector2(0, 30);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
