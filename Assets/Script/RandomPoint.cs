using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomPoint : MonoBehaviour
{
    public GameObject Character;
    public GameObject WayPoint;
    public float Timer;
    public float maxDistance;
    public LayerMask TargetLayerMask;
    public LayerMask ObstacleLayerMask;

    private Coroutine waitCoroutine;
    private Vector2 randomPos;

    private void Start()
    {
        randomPos = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
        WayPoint.transform.position = randomPos;
    }

    private void Update()
    {
        if (Character == null)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
        {
            if (waitCoroutine != null) 
            { StopCoroutine(waitCoroutine); }

            waitCoroutine = StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(Timer);

        randomPos = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
        WayPoint.transform.position = randomPos;

        waitCoroutine = null;
    }

    private Vector2 GetRandomPositionWithoutObstacles()
    {
        bool positionFound = false;
        int maxAttempts = 10;

        for (int i = 0; i < maxAttempts; i++)
        {
            randomPos = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));

            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPos, 0.5f, ObstacleLayerMask);

            if (colliders.Length == 0)
            {
                positionFound = true;
                break;
            }
        }

        if (!positionFound)
        {
            Debug.LogWarning("Could not find a valid position without obstacles.");
        }

        return randomPos;
    }
}

    
