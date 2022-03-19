using UnityEngine;

namespace Movement
{
    /// <summary>
    /// Class that moves object by axis.
    /// </summary>
    public class AxisMovementProvider : MovementProvider
    {
        /// <inheritdoc/>
        public override void Move()
        {
            Rigidbody2D.position += Axis * Speed * Time.deltaTime;
        }
    }
}