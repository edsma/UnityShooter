using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject Firstbullet = ObjectPool.sharedInstance.GetFirstPooledObject();
        if (Firstbullet != null)
        {
            Firstbullet.SetActive(true);
            Vector3 mousePosition = this.GetComponent<PlayerMovementScript>().getMousePosition();
            Vector3 dir = (mousePosition - ObjectPool.sharedInstance.shootingPoint.transform.position).normalized;
            GameObject bullet = Instantiate(Firstbullet, ObjectPool.sharedInstance.shootingPoint.transform.position, Quaternion.LookRotation(dir, Vector3.up));
            Destroy(bullet, 2);
        }
       
    }
}
