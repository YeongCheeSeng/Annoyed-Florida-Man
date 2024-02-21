using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickUp : MonoBehaviour
{
    private bool weararmor = false;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weararmor == true)
        {
            transform.position = new Vector3(player.position.x, player.position.y, -1);

            //copy & paste from PlayerMovement.HandleRotation
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);
            Vector2 direction = (Vector2)(mousePos - transform.position);
            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    //check if player is wearing armor
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            weararmor = true;
        }
    }
}
