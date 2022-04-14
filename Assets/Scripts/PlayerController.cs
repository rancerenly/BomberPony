using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float bombTimer;

    [SerializeField]
    private ObjectSpawner bombSpawner;

    private Timer lastTimer;
    
    public void OnBombPressed(InputAction.CallbackContext callbackContext)
    {
        lastTimer ??= new Timer(this, 0);

        if (callbackContext.ReadValueAsButton() && !lastTimer.IsRunning)
        {
            lastTimer.Restart(bombTimer);
            bombSpawner.Spawn();
        }
    }
}