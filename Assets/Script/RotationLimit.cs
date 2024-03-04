using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLimit : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float maxRotation = 180f;
    public float minRotation = 0f;

    private WeaponMovement weapon;

    private void Update()
    {
        // Get user input for rotation
        float input = Input.GetAxis("Horizontal");

        // Calculate the target rotation based on user input and maximum rotation
        float targetRotation = input * maxRotation;
        targetRotation = Mathf.Clamp(targetRotation, minRotation, maxRotation);

        // Smoothly interpolate between the current rotation and the target rotation
        Quaternion targetQuaternion = Quaternion.Euler(0, 0, targetRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);
    }
}