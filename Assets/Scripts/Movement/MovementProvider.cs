using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    /// <summary>
    /// Class used for movement handling.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class MovementProvider : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Movement speed.")]
        protected float Speed;
    
        /// <summary>
        /// Rigidbody2D reference.
        /// </summary>
        protected Rigidbody2D Rigidbody2D;

        /// <summary>
        /// Current input axis.
        /// </summary>
        protected Vector2 Axis { get; private set; }

        protected virtual void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Method that updates axis on input.
        /// </summary>
        public void OnMovementChanged(InputAction.CallbackContext callbackContext)
        {
            Axis = callbackContext.ReadValue<Vector2>();
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }
    
        /// <summary>
        /// Method responsible for movement.
        /// </summary>
        public abstract void Move();
    }
}