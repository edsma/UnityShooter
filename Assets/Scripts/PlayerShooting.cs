using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Animator _animator;
    public int bulletsAmount;
    public ParticleSystem fireEffect;
    private AudioSource shootSound;
    private float lastShootTime;
    private float fireRate = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale > 0)
        {
            Invoke(Constantes.metodos.Shoot,0.05f);
            //Shoot();
        }
    }

    private void Start()
    {
        bulletsAmount = ObjectPool.sharedInstance.amountToPool;
        shootSound = GetComponent<AudioSource>();
    }

    void Awake()
    {
        _animator =  GetComponent<Animator>();
    }

    private void Shoot()
    {
        GameObject Firstbullet = ObjectPool.sharedInstance.GetFirstPooledObject();
        float timeSinceLastShoot = Time.time - lastShootTime;
        if(timeSinceLastShoot < fireRate)
        {
            return;
        }

        lastShootTime = Time.time;

        if (Firstbullet != null)
        {
            Firstbullet.SetActive(true);
            fireEffect.Play();
            shootSound.Play();
            Vector3 mousePosition = this.GetComponent<PlayerMovementScript>().getMousePosition();
            Vector3 dir = (mousePosition - ObjectPool.sharedInstance.shootingPoint.transform.position).normalized;
            _animator.SetTrigger(Constantes.Animations.animacionDisparo);
            GameObject bullet = Instantiate(Firstbullet, ObjectPool.sharedInstance.shootingPoint.transform.position, Quaternion.LookRotation(dir, Vector3.up));
            Destroy(bullet, 2);
            bulletsAmount--;
        }
       
    }
}
