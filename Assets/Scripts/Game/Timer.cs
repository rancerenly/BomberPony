using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Class that implements basic timer.
    /// </summary>
    public class Timer : MonoBehaviour
    {
        /// <summary>
        /// Event that fires upon timeout.
        /// </summary>
        public event Action TimeElapsed;
        
        /// <summary>
        /// Event that fires when time changed.
        /// </summary>
        public event Action<float> TimeChanged;

        /// <summary>
        /// Property that identifies if timer has stopped.
        /// </summary>
        public bool Stopped => t <= 0;
        
        [SerializeField]
        [Tooltip("Timer time.")]
        private float time;

        [SerializeField]
        [Tooltip("Destroy this object after timeout.")]
        private bool destroyAfterwards;

        [SerializeField]
        [Tooltip("Restart timer on timeout.")]
        private bool restart;

        private float t;

        /// <summary>
        /// Method used to restart the timer.
        /// </summary>
        public void Restart()
        {
            StopAllCoroutines();
            StartCoroutine(Start());
        }
        
        private IEnumerator Start()
        {
            do
            {
                t = time;

                while (t > 0)
                {
                    t -= Time.deltaTime;
                    TimeChanged?.Invoke(t / time);
                    yield return null;
                }

                TimeElapsed?.Invoke();
            } while (restart);
            
            if (destroyAfterwards)
            {
                Destroy(gameObject);
            }
        }
    }
}