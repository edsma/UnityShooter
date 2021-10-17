using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        Life life = other.GetComponent<Life>();
        if(life != null)
        {
            life.Amount -= damage;
        }
    }
}
