using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwarMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Velocidad de la bala")]
    private float speed;


    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, speed * Time.deltaTime);   

    }
}
