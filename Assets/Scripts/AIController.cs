using UnityEngine;

public class AIController : ControllerBase
{
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IExplodable explodable))
        {
            Bomb();
        }
    }
}
