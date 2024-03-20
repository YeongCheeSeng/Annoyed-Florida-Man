using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShoot : MonoBehaviour
{
    public GameObject Target;
    public GameObject Projectile;
    public GameObject[] ShootFeedback;
    public GameObject[] ReloadFeedback;
    public float ShootInterval;

    private Transform FeedbackSpawnPos;
    private float ShootCooldown; // link with shoot interval
    private bool CanShoot;
    private EnemyMoveRandom enemy;

    // Start is called before the first frame update
    void Start()
    {
        ShootCooldown = ShootInterval;
        CanShoot = true;

        FeedbackSpawnPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootCooldown -= Time.deltaTime;

        if (ShootCooldown <= 0)
        {
            ShootCooldown = 0;
        }

        ShootTarget();
    }

    private void ShootTarget() 
    {
        if (Target == null)
            return;

        Vector2 direction = Target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        if (CanShoot && ShootCooldown <= 0) 
        {
            GameObject.Instantiate(Projectile, transform.position, transform.rotation);
            ShootCooldown = ShootInterval;
            SpawnShootFeedback();
        }
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
