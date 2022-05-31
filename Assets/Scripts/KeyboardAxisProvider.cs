using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardAxisProvider : AxisProvider
{
    public void OnMovementChanged(InputAction.CallbackContext callbackContext)
    {
        Axis = callbackContext.ReadValue<Vector2>();
    }
}