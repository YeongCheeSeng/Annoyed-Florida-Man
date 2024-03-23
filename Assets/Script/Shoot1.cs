using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot1 : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject[] ShootFeedback;
    public GameObject[] ReloadFeedback;
    private Transform FeedbackSpawnPos;

    public string WeaponName;
    public TMP_Text CurrentWeapon;
    public TMP_Text RemainingBulletLeft;

    public float ShootInterval;
    //public float BurstInterval;
    public FireModes FireMode;
    //public int BurstFireBulletAmount; // BurstFire not done yet
    public int BulletAmount;
    public float ReloadTime;
    public Animator animator;


    private float ShootCooldown; // link with shoot interval
    private bool CanShoot;
    private int CurrentBullet;
    private bool CanReload;
    private bool isShooting;

    public enum FireModes
    {
        SingleFire, // =0
        Auto,   // =1
        //BurstFire   // =2
    }

    private void Start()
    {
        ShootCooldown = 0;
        CanShoot = true;
        CanReload = true;

        CurrentBullet = BulletAmount;
        FeedbackSpawnPos = GetComponent<Transform>();
        isShooting = false;
    }


    // Update is called once per frame
    void Update()
    {
        PlayerShoot();
        Reload();
        UIReload();
        UICurrentWeapon();
        Animation();
    }


    //Fire
    public void PlayerShoot()
    {
        switch (FireMode)
        {
            case FireModes.SingleFire:
                {
                    if (!CanShoot)
                        return;

                    if (Input.GetButtonDown("Fire1") && CurrentBullet > 0)
                    {
                        Debug.Log("SingleFire");
                        StartCoroutine(IShoot());
                    }
                    break;
                }

            case FireModes.Auto:
                {
                    if (!CanShoot)
                        return;

                    //if (Input.GetButton("Fire1") && ShootCooldown <= 0 && CurrentBullet > 0)
                    if (Input.GetButton("Fire1") && CurrentBullet > 0)
                    {
                        Debug.Log("AutoFire");
                        StartCoroutine(IShoot());
                    }
                    break;
                }

                //case FireModes.BurstFire:
                //{
                //    if (!CanShoot)
                //        return;

                //    if (Input.GetButtonDown("Fire1") && ShootCooldown <= 0 && CurrentBullet > 0)
                //    {
                //        Debug.Log("BurstFire");
                //        int BurstFireBulletLeft = BurstFireBulletAmount;
                //        while (BurstFireBulletLeft > 0)
                //        {
                //            StartCoroutine(BurstShoot());
                //            BurstFireBulletLeft--;
                //        }
                //    }
                //    break;
                //}
        }
    }

    private void ShootProjectile()
    {
        GameObject.Instantiate(Projectile, transform.position, transform.rotation);
        SpawnShootFeedback();
    }

    IEnumerator IShoot()
    {
        isShooting = true;
        ShootProjectile();
        CurrentBullet--;
        CanShoot = false;
        yield return new WaitForSeconds(ShootInterval);
        isShooting = false;
        CanShoot = true;
    }

    //IEnumerator BurstShoot()
    //{
    //    GameObject.Instantiate(Projectile, transform.position, transform.rotation);
    //    CurrentBullet--;
    //    SpawnShootFeedback();
    //    yield return new WaitForSeconds(BurstInterval);
    //}


    //Reload
    private void Reload()
    {
        if (CurrentBullet == BulletAmount)
            return;

        if ((Input.GetKeyDown(KeyCode.R) && CanReload == true) || (CurrentBullet == 0 && CanReload == true))
        {
            SpawnReloadFeedback();
            StartCoroutine(reload());
        }
    }

    IEnumerator reload()
    {
        CanShoot = false;
        CanReload = false;
        yield return new WaitForSeconds(ReloadTime);
        CurrentBullet = BulletAmount;
        CanShoot = true;
        CanReload = true;
    }

    //Spawn Feedback
    void SpawnShootFeedback()
    {
        foreach (var ShootFeedback in ShootFeedback)
        {
            GameObject spawnfeedback = GameObject.Instantiate(ShootFeedback, FeedbackSpawnPos.position, FeedbackSpawnPos.rotation);
            Destroy(spawnfeedback, 1f);
        }
    }

    void SpawnReloadFeedback()
    {
        foreach (var ReloadFeedback in ReloadFeedback)
        {
            GameObject spawnfeedback = GameObject.Instantiate(ReloadFeedback, FeedbackSpawnPos.position, FeedbackSpawnPos.rotation);
            Destroy(spawnfeedback, 1f);
        }
    }

    //UI
    void UIReload()
    {
        if (RemainingBulletLeft == null)
            return;

        if (CurrentBullet > 0)
        {
            RemainingBulletLeft.text = "Bullet: " + CurrentBullet;
        }

        if (CanShoot == false && CanReload == false)
        {
            RemainingBulletLeft.text = "Bullet: Reloading";
        }
    }

    void UICurrentWeapon()
    {
        if (CurrentWeapon == null)
            return;

        CurrentWeapon.text = "Weapon: " + WeaponName;

    }

    //Animation
    private void Animation()
    {
        if (animator == null)
            return;

        if (isShooting == true)
            animator.SetBool("_isShooting", true);

        if (isShooting == false)
            animator.SetBool("_isShooting", false);
    }
}
