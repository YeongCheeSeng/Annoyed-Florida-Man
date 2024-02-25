using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : Movement
{

    protected override void HandleInput()
    {
        _inputDirection = new Vector2(x: Input.GetAxis("Horizontal"), y: Input.GetAxis("Vertical"));
    }

}
