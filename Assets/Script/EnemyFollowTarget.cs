using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTarget : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float distanceBetween;

    private float distance;
    public bool _isFollowingTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        _isFollowingTarget = true;
        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        if (distance < distanceBetween)
        {
            _isFollowingTarget = true;
            transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);

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

            //Vector3 newRotation = new Vector3(0, 0, angle);
            //transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
