using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float amount;

    public float Amount {
        get => amount;
        set
        {
            amount = value;
            if (amount <= 0 )
            {
                Destroy(gameObject);
            }
        }

    }
}
