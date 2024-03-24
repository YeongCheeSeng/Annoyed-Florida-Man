using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GraphicFixed : MonoBehaviour
{
    private PlayerMovement _playermovement;
    private SpriteRenderer _spriteRenderer;
    private bool flipedX = false;
    // Start is called before the first frame update
    void Start()
    {
        _playermovement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, upwards: (Vector3)_targetVelocity);
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("look left");
            flipedX = true;
           _spriteRenderer.flipX = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("look right");
            flipedX = false;
            _spriteRenderer.flipX = false;   
        }

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
            return;
    }
}
