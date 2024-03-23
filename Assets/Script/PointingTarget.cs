using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingTarget : MonoBehaviour
{
    public GameObject Target;
    private EnemyFollowTarget enemyFollowTarget;

    // Start is called before the first frame update
    void Start()
    {
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

            if (enemyFollowTarget._isFollowingTarget == true)
            {
                Vector2 direction = Target.transform.position - transform.position;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);                   
            }
        }
    }
}
