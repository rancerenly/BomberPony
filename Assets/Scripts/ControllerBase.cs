using UnityEngine;

public abstract class ControllerBase : MonoBehaviour
{
    [SerializeField]
    protected float bombTimer;
    
    [SerializeField]
    protected ObjectSpawner bombSpawner;
    
    private Timer lastTimer;

    protected virtual void Bomb()
    {
        lastTimer ??= new Timer(this, 0);

        if (!lastTimer.IsRunning)
        {
            lastTimer.Restart(bombTimer);
            bombSpawner.Spawn();
        }
    }
}