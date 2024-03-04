using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;
    //private Transform _transform; 
    public float Offset_X; 
    public float Offset_Y; 
    public float transformX;
    public float transformY;
    public float MinZRotation;
    public float MaxZRotation;

    private Transform PlayerCurrentTF;
    //private PlayerMovement facing;
    [SerializeField] private bool fPFlipedX = false;
    //private GraphicFixed _graphicFixed;

    //private Transform localTrans;

    //public float maxYRot = 90f;
    //public float minYPot = -90f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        PlayerCurrentTF = Player;
        //_transform = GetComponent<Transform>();
        //_graphicFixed = GetComponent<GraphicFixed>();

        //transformX = Player.position.x / 2;
        //transformY = Player.position.y / 2;
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A) && fPFlipedX == false)
        {
            fPFlipedX = true;
        }
        else if (Input.GetKey(KeyCode.D) && fPFlipedX == true)
        {
            fPFlipedX = false;
        }

        if (fPFlipedX == false)
        {
            transformX = PlayerCurrentTF.position.x + (Offset_X / 2);
        }
        else if (fPFlipedX == true)
        {
            transformX = PlayerCurrentTF.position.x - (Offset_X / 2);
        }
        transformY = PlayerCurrentTF.position.y + (Offset_Y / 2);
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
