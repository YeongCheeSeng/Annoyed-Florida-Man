using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Projectile;
    public Transform SpawnPos;

    public float ShootInterval;
    public FireModes FireMode;
    public int BurstFireBulletAmount; // BurstFire not done yet
    public int BulletAmount;
    public float ReloadTime;


    private float ShootCooldown;
    private bool CanShoot;
    private int BurstFireBulletAmountLeft;
    private int CurrentBullet;
    private float ReloadTimeLeft;

    public enum FireModes
    {
        SingleFire, // =0
        Auto,   // =1
        BurstFire   // =2
    }

    private void Start()
    {
        ShootCooldown = 0;
        ReloadTimeLeft = 0;

        BurstFireBulletAmountLeft = BurstFireBulletAmount;

        CurrentBullet = BulletAmount;
    }


    // Update is called once per frame
    void Update()
    {
        ShootCooldown -= Time.deltaTime;


        if (ShootCooldown <= 0)
        {
            ShootCooldown = 0;
        }

        PlayerShoot();
        Reload();

        //Debug.Log("Shoot CoolDown: " + ShootCooldown);
    }


    public void PlayerShoot()
    {
        switch (FireMode)
        {
            case FireModes.SingleFire:
            {
                if (Input.GetButtonDown("Fire1") && ShootCooldown <= 0 && CurrentBullet > 0)
                {
                    Debug.Log("SingleFire");
                    GameObject.Instantiate(Projectile, transform.position, transform.rotation);
                    CurrentBullet--;
                    ShootCooldown = ShootInterval;
                }
                break;
            }

            case FireModes.Auto:
            {
                if (Input.GetButton("Fire1") && ShootCooldown <= 0 && CurrentBullet > 0)
                {
                    Debug.Log("AutoFire");
                    GameObject.Instantiate(Projectile, transform.position, transform.rotation);
                    CurrentBullet--; 
                    ShootCooldown = ShootInterval;
                }
                break;  
            }

            case FireModes.BurstFire:
            {
                if (Input.GetButtonDown("Fire1") && ShootCooldown <= 0 && CurrentBullet > 0)
                {
                    Debug.Log("BurstFire");
                    BurstShoot();
                }
                break;
            }
        }
    }

    public void BurstShoot() 
    {
        for (BurstFireBulletAmountLeft = BurstFireBulletAmount; BurstFireBulletAmountLeft > 0; BurstFireBulletAmountLeft--)
        {
            if (ShootCooldown <= 0)
            {
                GameObject.Instantiate(Projectile, transform.position, transform.rotation);
                CurrentBullet--;
            }
            Debug.Log("BurstFireAmountLeft: " + BurstFireBulletAmountLeft);
        }
        //BurstFireBulletAmountLeft = BurstFireBulletAmount;
    }

    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {           
            CurrentBullet = BulletAmount;
        }
    }
}
