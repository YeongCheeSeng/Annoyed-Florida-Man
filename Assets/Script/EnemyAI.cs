using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float Speed = 300;
    public float nextWayPointDistance = 3;
    public float ChaseCooldown = 3;
    public float distanceBetweenPlayer;

    public Transform EnemyGraphic;
    public bool _isFollowingTarget;

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
        _isFollowingTarget = false;

        InvokeRepeating("UpdatePath", 0f, ChaseCooldown);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
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
        if (path == null || target == null)
            return;

        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        float distanceBetween = Vector2.Distance(transform.position, target.transform.position);

        if (distanceBetween < distanceBetweenPlayer)
        {
            _isFollowingTarget = true;
            Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;

            Vector2 force = direction * Speed * Time.deltaTime;
            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

            if (distance < nextWayPointDistance)
            {
                currentWayPoint++;
            }
        }
        else if (distanceBetween > distanceBetweenPlayer) 
        {
            _isFollowingTarget = false;
            return;
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