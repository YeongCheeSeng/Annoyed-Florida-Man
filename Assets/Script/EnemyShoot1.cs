using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShoot1 : MonoBehaviour
{
    public GameObject Target;
    public GameObject Projectile;
    public GameObject[] ShootFeedback;
    public float ShootInterval;

    private Transform FeedbackSpawnPos;
    private bool CanShoot;
    private EnemyFollowTarget enemyFollowTarget;

    // Start is called before the first frame update
    void Start()
    {
        FeedbackSpawnPos = GetComponent<Transform>();
        StartCoroutine(Wait());

        GameObject enemy = GameObject.FindWithTag("Enemy");

        if (enemy != null)
        {
            enemyFollowTarget = enemy.GetComponent<EnemyFollowTarget>();

            if (enemyFollowTarget == null)
                return;
        }

        if (enemy == null)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
            return;

        if (enemyFollowTarget != null)
        {
            if (enemyFollowTarget._isFollowingTarget == false)
                return;
        }

        ShootTarget();
    }

    private void ShootTarget()
    {
        if (Target == null)
            return;

        Vector2 direction = Target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

        if (CanShoot)
        {
            StartCoroutine(Shoot());
            SpawnShootFeedback();
        }
    }

    IEnumerator Shoot()
    {
        GameObject.Instantiate(Projectile, transform.position, transform.rotation);
        CanShoot = false;
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