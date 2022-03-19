using UnityEngine;
using Object = UnityEngine.Object;

namespace Creators
{
    /// <summary>
    /// Class responsible for object instantiation.
    /// </summary>
    /// <typeparam name="T">Instantiated object type.</typeparam>
    public class ObjectCreator<T> : MonoBehaviour where T : Object
    {
        /// <summary>
        /// Position of instantiated object.
        /// </summary>
        protected Vector3 Position;
        
        /// <summary>
        /// Rotation of instantiated object.
        /// </summary>
        protected Quaternion Rotation;
    
        [SerializeField]
        [Tooltip("Prefab of object to instantiate.")]
        private T prefab;

        /// <summary>
        /// Method that instantiates object on scene.
        /// </summary>
        public virtual T Instantiate()
        {
            T instance = GameObject.Instantiate(prefab, Position, Rotation);
            return instance;
        } 
    }
}