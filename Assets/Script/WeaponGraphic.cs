using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponGraphic : MonoBehaviour
{
    //[SerializeField] private bool wmflipedX = false;
    private FollowPlayer _isFacingLeft;
    private float angle;
    private Vector2 direction;

    private void Start()
    {
    }

    private void Update()
    {
        if (_isFacingLeft == null)
            return;

        if (_isFacingLeft.fPFlipedX == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);

            direction = (Vector2)(mousePos - transform.position);

            angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        if (_isFacingLeft.fPFlipedX == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);

            direction = (Vector2)(mousePos - transform.position);

            angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180f);

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    wmflipedX = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    wmflipedX = false;
        //}

        //if (wmflipedX == false)
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        //    Vector2 direction = (Vector2)(mousePos - transform.position);

        //    angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) ;

        //    transform.rotation = Quaternion.Euler(0, 0, angle);
        //}

        //if (wmflipedX == true)
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        //    Vector2 direction = (Vector2)(mousePos - transform.position);

        //    angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180f) ;

        //    transform.rotation = Quaternion.Euler(0, 0, angle);
        //}
    }
}
