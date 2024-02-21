using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Projectile;
    public Transform SpawnPos;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire");
            GameObject.Instantiate(Projectile,transform.position, transform.rotation);
        }
    }
}
