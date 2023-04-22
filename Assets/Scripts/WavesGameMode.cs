using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{

    [SerializeField]
    private Life playerLife;

    [SerializeField]
    private Life playerBaseLife;


    private void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerLifeChanged);
        playerBaseLife.onDeath.AddListener(OnPlayerBaseLifeChanged);
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    private void CheckWinCondition()
    {
        if (EnemiesManager.instance.enemies.Count <= 0 && WavesManager.instance.WaveSpawners.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }

        
    }

    private void OnPlayerLifeChanged()
    {
        if (playerLife.Amount <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    private void OnPlayerBaseLifeChanged()
    {
        if (playerBaseLife.Amount <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    private void OnDestroy()
    {
        playerLife.onDeath.RemoveListener(OnPlayerLifeChanged);
        playerBaseLife.onDeath.RemoveListener(OnPlayerBaseLifeChanged);
    }

}
