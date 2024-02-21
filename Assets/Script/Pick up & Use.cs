using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public int item = 0;
    [SerializeField] private Text itemtext;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //which button is to ues item
        if (Input.GetKeyDown("1"))
        {
           UseItem();
        }
    }

    //pick up item code (+ item)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            Destroy(collision.gameObject);
            item++;
            itemtext.text = item.ToString();
        }
    }
    
    //use item code (- item)
    public void UseItem() 
    {
        Debug.Log("item uesd");
        item--;
        if (item <= 0)
        {
            item = 0;
            itemtext.text = item.ToString();
        }
    }
}
