using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Tooltip("Cantidad de puntos en la partida actual")]
    private int amount = 0;

    public static ScoreManager SharedInstance;

    public int Amount 
    {
        get => 0;
        set => amount = value;
    
    }

    private void Awake()
    {
        amount = 0;
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
