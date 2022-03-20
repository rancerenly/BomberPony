using UnityEngine;

namespace Game
{
    /// <summary>
    /// Class that explodes explodables.
    /// </summary>
    [RequireComponent(typeof(Collider2D))]
    public class ExploderTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IExplodable explodable))
            {
                explodable.Explode();
            }
        }
    }
}