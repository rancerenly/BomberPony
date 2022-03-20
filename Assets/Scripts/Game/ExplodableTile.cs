using UnityEngine;

namespace Game
{
    /// <summary>
    /// Simple explodable object.
    /// </summary>
    public class ExplodableTile : MonoBehaviour, IExplodable
    {
        /// <inheritdoc/>
        public void Explode()
        {
            Destroy(gameObject);
        }
    }
}