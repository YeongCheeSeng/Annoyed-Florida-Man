using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 4f;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (rotationSpeed > 0)
        this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
