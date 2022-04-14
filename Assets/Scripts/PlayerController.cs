using UnityEngine.InputSystem;

public class PlayerController : ControllerBase
{
    public void OnBombPressed(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.ReadValueAsButton())
        {
            Bomb();
        }
    }
}