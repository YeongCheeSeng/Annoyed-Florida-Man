using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingTarget : MonoBehaviour
{
    public GameObject Target;
    public bool _isPointingTarget;

    public EnemyFollowTarget enemyFollowTarget;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
        {
            return;
        }

        if (enemyFollowTarget != null)
        {
            if (enemyFollowTarget._isFollowingTarget == false)
            {
                _isPointingTarget = false;                
                return;
            }

            if (enemyFollowTarget._isFollowingTarget == true)
            {
                Vector2 direction = Target.transform.position - transform.position;
                transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
                _isPointingTarget = true;
            }
        }
    }
}
