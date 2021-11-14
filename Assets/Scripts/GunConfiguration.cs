using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunConfiguration : MonoBehaviour
{
    public int maxAmountBullet;

    public static GunConfiguration sharedInstance;
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }
}
