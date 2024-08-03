using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatusDisplay : MonoBehaviour
{
    TextMeshPro tmp { get => GetComponent<TextMeshPro>(); }
    Player player { get => FindObjectOfType<Player>(); }

    [SerializeField] string displayType;

    private void Update()
    {
        if (displayType == "Hp")
        {
            if (player == null) { tmp.text = 0.ToString(); }
            else { tmp.text = player.GetHp().ToString(); }
        }
        else if (displayType == "Magazine")
        {
            if (player != null) { tmp.text = player.GetMagazine().ToString(); }
        }
    }
}