using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject character;
    public Animator animator;

    private Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null || character == null)
            return;

        Animation();
        previousPosition = character.transform.position;
    }

    private void Animation()
    {
        if (previousPosition != character.transform.position)
            animator.SetBool("_isMoving", true);
        else
            animator.SetBool("_isMoving", false);
    }
}
