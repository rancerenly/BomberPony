using Game;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Creators
{
    /// <summary>
    /// Class used to create objects by command with a delay.
    /// </summary>
    public class CommandTimerCreator<T> : CommandCreator<T> where T : Object
    {
        [SerializeField]
        [Tooltip("Timer reference.")]
        private Timer timer;

        /// <inheritdoc/>
        public override void OnCommand(InputAction.CallbackContext callbackContext)
        {
            if (timer.Stopped && callbackContext.performed)
            {
                Create();
                timer.Restart();
            }
        }
    }
}