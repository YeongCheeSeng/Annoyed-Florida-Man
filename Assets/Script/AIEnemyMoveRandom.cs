using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;

public class AIEnemyMoveRandom : MonoBehaviour
{
    public Transform RandomPoint;
    public float Speed = 300;
    public float nextWayPointDistance = 3;
    public float MoveCooldown = 3;

    public Transform EnemyGraphic;
    public EnemyAI FollowingTarget;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, MoveCooldown);
    }

    void UpdatePath()
    {
        if (RandomPoint != null && seeker.IsDone())
            seeker.StartPath(rb.position, RandomPoint.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null || FollowingTarget._isFollowingTarget == true || RandomPoint == null)
        {          
            return;
        }

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;

        Vector2 force = direction * Speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x = 1;
            gameObject.transform.localScale = currentScale;
        }

        if (rb.velocity.x <= -0.01f)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x = -1;
            gameObject.transform.localScale = currentScale;
        }
    }
}