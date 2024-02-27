using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPos : MonoBehaviour
{
    public Transform FlipedBulletPosR;
    public Transform FlipedBulletPosL;
    [SerializeField] private bool flipedX = false;

    //public float x;
    //public float y;
    //private float transformX;
    //private float transformY;

    // Start is called before the first frame update
    void Start()
    {
       //FlipedBulletPosR = GetComponent<Transform>();
       //FlipedBulletPosL = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        { flipedX = false; }
        else if (Input.GetKeyDown(KeyCode.A))
        { flipedX = true; }

        if (flipedX == false)
        { 
            transform.position = FlipedBulletPosR.position;
        }
        else if (flipedX == true)
        {
            transform.position = FlipedBulletPosL.position;
        }

        //if (Input.GetKeyDown(KeyCode.D))
        //{ flipedX = false ; }
        //else if (Input.GetKeyDown(KeyCode.A))
        //{ flipedX = true ; }

        //if (flipedX == false)
        //{ transformX = transform.position.x + x; }

        //else if (flipedX == true) 
        //{ transformX = transform.position.x - x; }

        //transform.position = new Vector3(transformX, transformY, 0);

    }
}
