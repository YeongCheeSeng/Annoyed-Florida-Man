using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class movement : MonoBehaviour
{
    public float movespeed = 1f;
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private float lr;
    private float ud;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        lr = 0; ud = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lr = Input.GetAxis("Horizontal");
        ud = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2 (lr * movespeed, ud * movespeed);
        
    }
}
