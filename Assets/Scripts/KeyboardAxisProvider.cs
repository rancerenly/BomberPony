using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class KeyboardAxisProvider : AxisProvider
{
    [SerializeField]
    private Joystick joystick;

    public void FixedUpdate()
    {
        Axis = joystick.Direction;
    }
    /*public void OnMovementChanged(InputAction.CallbackContext callbackContext)
    {
        Axis = callbackContext.ReadValue<Vector2>();
    }*/
}