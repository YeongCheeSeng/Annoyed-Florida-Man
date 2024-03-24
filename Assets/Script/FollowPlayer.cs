using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class FollowPlayer : MonoBehaviour
{
    //private Transform _transform; 
    public float Offset_X; 
    public float Offset_Y;

    private Transform Player;
    private float transformX;
    private float transformY;
    private Transform currentPos;
    [SerializeField] public bool fPFlipedX;

    //private PlayerMovement facing;
    //private GraphicFixed _graphicFixed;

    //private Transform localTrans;

    //public float maxYRot = 90f;
    //public float minYPot = -90f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        if (Player == null ) { return; }

        currentPos = Player;

        //_transform = GetComponent<Transform>();
        //_graphicFixed = GetComponent<GraphicFixed>();

        //transformX = Player.position.x / 2;
        //transformY = Player.position.y / 2;
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
            return;

        Vector3 moveDirection = Player.GetComponent<PlayerMovement>().movement;

        if (moveDirection.x > 0 && fPFlipedX == false)
        {
            fPFlipedX = true;
        }
        else if (moveDirection.x < 0 && fPFlipedX == true)
        {
            fPFlipedX = false;
        }

        if (fPFlipedX == false)
        {
            transformX = currentPos.position.x - (Offset_X);
        }
        else if (fPFlipedX == true)
        {
            transformX = currentPos.position.x + (Offset_X);
        }

        transformY = currentPos.position.y + (Offset_Y);
        transform.position = new Vector3(transformX, transformY, transform.position.z);


        //if (_transform.rotation.z == MinZRotation)
        //{
        //    _transform.rotation.z = MinZRotation;
        //}



        //LimitRot();
    }



    //private void LimitRot()
    //{
    //    Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;

    //    playerEulerAngles.y = (playerEulerAngles.y > 180)? playerEulerAngles.y - 360 : playerEulerAngles.y;
    //    playerEulerAngles.y = Mathf.Clamp(playerEulerAngles.y, minYPot, maxYRot);

    //    localTrans.rotation = Quaternion.Euler(playerEulerAngles);
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        gameObject.transform.position = 
    //    }
    //}
}
