using UnityEngine;

namespace Creators
{
    /// <summary>
    /// Class responsible for spawning bombs.
    /// </summary>
    public class BombCreator : CommandCreator<GameObject>
    {
        private new Transform transform;

        private void Awake()
        {
            transform = base.transform;
        }

        /// <inheritdoc/>
        public override GameObject Instantiate()
        {
            Position = transform.position;
            Rotation = transform.rotation;
            
            return base.Instantiate();
        }
    }
}