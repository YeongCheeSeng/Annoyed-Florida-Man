using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    public Rigidbody2D rb;
    //public SpriteRenderer spriteRenderer;
    public Vector2 movement;

    private bool _facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0 && !_facingRight)
        {
            Flip();
        }

        if (movement.x < 0 && _facingRight)
        {
            Flip();
        }

        Animation();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Animation()
    {
        if (movement.magnitude > 0.01f)
            animator.SetBool("_isMoving", true);
        else
            animator.SetBool("_isMoving", false);        
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }
}
