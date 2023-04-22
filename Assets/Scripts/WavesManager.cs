using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WavesManager : MonoBehaviour
{

    public static WavesManager instance;

    private List<WaveSpawner> waveSpawners = new();

    public UnityEvent onChanged;

    public List<WaveSpawner> WaveSpawners { get => waveSpawners; set => waveSpawners = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Duplicated WaveManager, ignoring this one", gameObject);
        }
    }

    public void AddWave(WaveSpawner wave)
    {
        WaveSpawners.Add(wave);
        onChanged.Invoke();
    }

    public void RemoveWave(WaveSpawner wave)
    {
        WaveSpawners.Remove(wave);
        onChanged.Invoke();
    }


}
