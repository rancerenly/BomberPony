using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Class that visualizes explosion rays.
    /// </summary>
    [RequireComponent(typeof(Timer))]
    public class RayExplosion : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Reference for all rays.")]
        private Transform[] rays;

        [SerializeField]
        [Tooltip("Max distance of an explosion.")]
        private float maxDistance;

        [SerializeField]
        [Tooltip("Explosion animation curve.")]
        private AnimationCurve explosionCurve;

        [SerializeField]
        [Tooltip("Layer mask for explodable objects.")]
        private LayerMask explosionMask;
        
        private Timer timer;
        private readonly Dictionary<Transform, float> rayDistances = new Dictionary<Transform, float>();

        private void Awake()
        {
            timer = GetComponent<Timer>();
        }

        private void Start()
        {
            foreach (Transform ray in rays)
            {
                RaycastHit2D hit = Physics2D.Raycast(ray.position, ray.right, maxDistance, explosionMask);
                rayDistances.Add(ray, hit ? hit.distance : float.PositiveInfinity);
            }
        }

        private void OnEnable()
        {
            timer.TimeChanged += OnTimeChanged;
        }

        private void OnDisable()
        {
            timer.TimeChanged -= OnTimeChanged;
        }

        private void OnTimeChanged(float t)
        {
            UpdateRays(1 - t);
        }

        private void UpdateRays(float t)
        {
            foreach (Transform ray in rays)
            {
                Vector3 scale = ray.localScale;
                float newSize = explosionCurve.Evaluate(t) * maxDistance;
                newSize = Mathf.Min(newSize, rayDistances[ray]);

                scale.x = newSize;
                ray.localScale = scale;
            }
        }
    }
}