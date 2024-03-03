using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyMoveRandom : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance;

    Vector2 wayPoint;
    public EnemyFollowTarget FollowTarget;

    private bool _facingRight = true;

    private void Start()
    {
        FollowTarget = GetComponent<EnemyFollowTarget>();
        SetNewDestination();
    }

    private void Update()
    {
        if (FollowTarget._isFollowingTarget == true)
            return;

        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        Vector2 direction = (wayPoint - (Vector2)transform.position).normalized;

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (direction.x > 0)
            {
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x = 1;
                gameObject.transform.localScale = currentScale;
            }

            if (direction.x < 0)
            {
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x = -1;
                gameObject.transform.localScale = currentScale;
            }

            //transform.rotation = Quaternion.Euler(0,0,angle);
        }

        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    }
}
