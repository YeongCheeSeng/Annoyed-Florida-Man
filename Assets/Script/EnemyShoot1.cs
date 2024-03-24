using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
    public GameObject Target;
    public GameObject Projectile;
    public GameObject[] ShootFeedback;
    public float ShootInterval;

    private Transform FeedbackSpawnPos;
    private bool CanShoot;
    public PointingTarget pointingTarget;

    // Start is called before the first frame update
    void Start()
    {
        FeedbackSpawnPos = GetComponent<Transform>();
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
            return;

        if (Target != null && pointingTarget._isPointingTarget)
        {
            ShootTarget();
        }
    }

    private void ShootTarget()
    {
        if (CanShoot == false)
            return;

        Vector2 direction = Target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        StartCoroutine(Shoot());
        SpawnShootFeedback();    
    }

    IEnumerator Shoot()
    {
        CanShoot = false;
        GameObject.Instantiate(Projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(ShootInterval);
        CanShoot = true;
    }

    IEnumerator Wait()
    {
        CanShoot = false;
        yield return new WaitForSeconds(ShootInterval);
        CanShoot = true;
    }

    void SpawnShootFeedback()
    {
        foreach (var ShootFeedback in ShootFeedback)
        {
            GameObject spawnfeedback = GameObject.Instantiate(ShootFeedback, FeedbackSpawnPos.position, FeedbackSpawnPos.rotation);
            Destroy(spawnfeedback, 1f);
        }
    }
}