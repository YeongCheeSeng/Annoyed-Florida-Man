using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Projectile;
    public Transform SpawnPos;

    public float ShootInterval;
    public float BurstInterval;
    public FireModes FireMode;
    public int BurstFireBulletAmount; // BurstFire not done yet
    public int BulletAmount;
    public float ReloadTime;


    private float ShootCooldown; // link with shoot interval
    private bool CanShoot;
    private int CurrentBullet;

    public enum FireModes
    {
        SingleFire, // =0
        Auto,   // =1
        BurstFire   // =2
    }

    private void Start()
    {
        ShootCooldown = 0;
        CanShoot = true;

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
                if (!CanShoot)
                    return;

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
                if (!CanShoot)
                    return;

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
                if (!CanShoot)
                    return;

                if (Input.GetButtonDown("Fire1") && ShootCooldown <= 0 && CurrentBullet > 0)
                {
                    Debug.Log("BurstFire");
                    int BurstFireBulletLeft = BurstFireBulletAmount;
                    while (BurstFireBulletLeft > 0)
                    {
                        StartCoroutine(BurstShoot());
                        BurstFireBulletLeft--;
                    }
                }
                break;
            }
        }
    }

    IEnumerator BurstShoot()
    {
        GameObject.Instantiate(Projectile, transform.position, transform.rotation);
        CurrentBullet--;
        yield return new WaitForSeconds(BurstInterval);
    }

    private void Reload()
    {
        if (CurrentBullet == BulletAmount)
            return;

        if (Input.GetKeyDown(KeyCode.R) || CurrentBullet <= 0)
        {           
            CurrentBullet = BulletAmount;
            StartCoroutine(reload());
        }
    }

    IEnumerator reload()
    {
        CanShoot = false;
        yield return new WaitForSeconds(ReloadTime);
        CanShoot = true;
    }
}
