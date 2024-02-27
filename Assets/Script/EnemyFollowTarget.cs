using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTarget : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float distanceBetween;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)     
            return;

        distance = Vector2.Distance(transform.position, target.transform.position);
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        direction.z = 0f;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
            Vector3 newRotation = new Vector3(0, 0, angle);
            transform.rotation = Quaternion.Euler(newRotation);
        }
    }
}
