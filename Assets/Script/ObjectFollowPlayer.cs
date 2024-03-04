using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowPlayer : MonoBehaviour
{
    public Transform Player;
    public float Offset_X;
    public float Offset_Y;
    public bool fPFlipedX = false;
    public float RightLimitRotation = 180f;
    public float LeftLimitRotation = -180f;

    private float lastZRotation;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    fPFlipedX = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    fPFlipedX = false;
        //}

        float newTransformX = fPFlipedX ? Player.position.x - (Offset_X / 2) : Player.position.x + (Offset_X / 2);
        float newTransformY = Player.position.y + (Offset_Y / 2);

        transform.position = new Vector3(newTransformX, newTransformY, transform.position.z);

        float minZRotation = fPFlipedX ? LeftLimitRotation : -180f;  
        float maxZRotation = fPFlipedX ? 180f : RightLimitRotation;

        float zRotation = Mathf.Clamp(transform.rotation.eulerAngles.z, minZRotation, maxZRotation);


        if (Mathf.Approximately(zRotation, minZRotation) || Mathf.Approximately(zRotation, maxZRotation))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, lastZRotation);
        }
        else
        {
            lastZRotation = zRotation;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zRotation);
        }
    }
}
