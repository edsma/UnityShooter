using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager SharedInstance;

    [SerializeField]
    private int waves;

    public UnityEvent OnWaveChange;

    public int Waves
    {
        get => waves;
        set
        {
            waves = value;
            if (waves <= 0)
            {
                waves = 0;
            }
        }

    }

    private int maxWaves;

    public int TotalWaves
    {
        get => maxWaves;
    }

    public void RemoveWave()
    {
        Waves--;
        OnWaveChange.Invoke();
    }

    public void AddWave(int amountWaves)
    {
        maxWaves++;
        Waves += amountWaves;
    }

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
         
        }
        else
        {
            Destroy(this);
        }
    }
}
