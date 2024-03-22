using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Experimental.GraphView;
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
    [SerializeField]
    float waitTime;

    Vector2 wayPoint;
    private EnemyFollowTarget followTarget;
    private bool _facingRight = true;
    private Vector2 direction;
    private bool isWaiting;

    private void Start()
    {
        followTarget = GetComponent<EnemyFollowTarget>();
        SetNewDestination();
    }

    private void Update()
    {

        if (followTarget._isFollowingTarget == true)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        direction = (wayPoint - (Vector2)transform.position).normalized;

        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //if (direction.x > 0)
        //{
        //    Vector3 currentScale = gameObject.transform.localScale;
        //    currentScale.x = 1;
        //    gameObject.transform.localScale = currentScale;
        //}

        //if (direction.x < 0)
        //{
        //    Vector3 currentScale = gameObject.transform.localScale;
        //    currentScale.x = -1;
        //    gameObject.transform.localScale = currentScale;
        //}

        //transform.rotation = Quaternion.Euler(0,0,angle);

        //if (direction.x > 0 && !_facingRight)
        //    Flip();
        //else if (direction.x < 0 && _facingRight)
        //    Flip();

        Flip();

        if (Vector2.Distance(transform.position, wayPoint) < range && isWaiting == false)
        {
            StartCoroutine(Wait());
        }

    }

    private void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }

    //private void Flip()
    //{
    //    _facingRight = !_facingRight;
    //    Vector3 currentScale = transform.localScale;
    //    currentScale.x *= -1;
    //    transform.localScale = currentScale;
    //}
    private void Flip()
    {
        if (direction.x > 0)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x = 1;
            transform.localScale = currentScale;           
        }

        if (direction.x < 0)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x = -1;
            transform.localScale = currentScale;
        }
    }
    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        SetNewDestination();
        isWaiting = false;
    }
}
