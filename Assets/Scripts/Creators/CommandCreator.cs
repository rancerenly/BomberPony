using UnityEngine;
using UnityEngine.InputSystem;

namespace Creators
{
    /// <summary>
    /// Class that creates objects on command.
    /// </summary>
    public class CommandCreator<T> : ObjectCreator<T> where T : Object
    {
        [SerializeField]
        [Tooltip("Name of a command")]
        private string commandName;

        /// <summary>
        /// Method that invokes on input event.
        /// </summary>
        public virtual void OnCommand(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.performed)
            {
                Create();
            }
        }
    }
}