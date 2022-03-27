using UnityEngine;

namespace Game
{
    /// <summary>
    /// Class that destroys object upon death.
    /// </summary>
    public class HealthDestroyer : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Health reference.")]
        private Health health;

        private void OnEnable()
        {
            health.Death += OnDeath;
        }

        private void OnDisable()
        {
            health.Death -= OnDeath;
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}