using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    public GameObject prefabBullet;
    public GameObject shootingPoint;
    [SerializeField]
    [Tooltip("Rango de la bala")]
    private float range;

    public List<GameObject> pooledObjects;

    public int amountToPool;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tpm;
        for (int i = 0; i < amountToPool; i++)
        {
            tpm = Instantiate(prefabBullet);
            tpm.SetActive(false);
            pooledObjects.Add(tpm);
        }
    }

    public GameObject GetFirstPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }


}
