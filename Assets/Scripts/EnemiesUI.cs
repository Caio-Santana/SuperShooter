using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesUI : MonoBehaviour
{

    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        EnemiesManager.instance.onChanged.AddListener(RefreshText);
    }

    void RefreshText()
    {
        text.text = "Remaining Enemies: " + EnemiesManager.instance.enemies.Count;
    }

}
