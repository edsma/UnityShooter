using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField]
    [Range(0,100)]
    private float amount;
    public UnityEvent onDeath;

    public float maximounLife = 100f;

    private void Awake()
    {
        amount = maximounLife;
    }

    public float Amount {
        get => amount;
        set
        {
            amount = value;
            if (amount <= 0 )
            {
                onDeath.Invoke();
                Destroy(gameObject);
            }
        }

    }
}
