using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Cantidad de puntos que se obtienen al derrotar a un enemigo")]
    public int pointAmount;

    private void Start()
    {
        EnemyManager.SharedInstance.AddEnmy(1);
    }

    private void Awake()
    {
        Life life = GetComponent<Life>();
        life.onDeath.AddListener(AddPoint);
    }



    private void AddPoint()
    {
        EnemyManager.SharedInstance.RemoveEnemy();
        ScoreManager.SharedInstance.Amount += pointAmount;
        bool statusEnemies = EnemyManager.SharedInstance.Enemies == 0;
        if (statusEnemies)
        {
            WaveManager.SharedInstance.RemoveWave();
        }
    }



}
