using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponMovement : Movement
{
    public float maxRotation;
    public float minRotation;

    public Vector2 direction;
    public float angle;

    private FollowPlayer _isFacingLeft; // get from FollowPlayer

    protected override void HandleRotation()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        direction = (Vector2)(mousePos - transform.position);

        angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


    //private void RotationLimit()
    //{
    //    if (_isFacingLeft.fPFlipedX == true)
    //    {
    //        minRotation = 0f;
    //        maxRotation = 180f;
    //    }

    //    if (_isFacingLeft.fPFlipedX == false)
    //    {
    //        minRotation = -90f;
    //        maxRotation = 90f;
    //    }
    //}

    //protected override void HandleRotation()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);

    //    Vector2 direction = (Vector2)(mousePos - transform.position);

    //    float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;

    //    transform.rotation = Quaternion.Euler(0, 0, angle);
    //}
}
