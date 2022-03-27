using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Class for health manipulation and events.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// Event that fires upon health change.
        /// </summary>
        public event Action<int> HealthChanged;
        
        /// <summary>
        /// Event that fires upon health reaches 0.
        /// </summary>
        public event Action Death; 

        [SerializeField]
        [Tooltip("Maximum health.")]
        private int maxHealth;

        private int health;

        private void Awake()
        {
            health = maxHealth;
        }

        /// <summary>
        /// Method used to apply damage.
        /// </summary>
        public void Damage(int value)
        {
            if (value <= 0)
            {
                return;
            }
            
            health = Mathf.Max(0, health - value);
            HealthChanged?.Invoke(health);
            
            if (health <= 0)
            {
                Death?.Invoke();
            }
        }
    }
}
