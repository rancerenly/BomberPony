using System.Collections.Generic;
using UnityEngine;

public class RayExplosion : MonoBehaviour
{
    [SerializeField]
    private Transform[] rays;

    [SerializeField]
    private float animationTime;

    [SerializeField]
    private AnimationCurve xCurve;
    
    [SerializeField]
    private AnimationCurve yCurve;

    [SerializeField]
    private LayerMask layerMask;

    private readonly Dictionary<Transform,float> maxLength = new Dictionary<Transform, float>();
    
    private void Start()
    {
        float d = xCurve.Evaluate(1);
        foreach (Transform ray in rays)
        {
            maxLength.Add(ray, d);
        }

        Timer timer = new Timer(this, animationTime);
        timer.TimeChanged += OnTimeChanged;
        timer.TimerFinished += OnTimerFinished;
    }

    private void OnTimerFinished()
    {
        Destroy(gameObject); 
    }

    private void OnTimeChanged(float time)
    {
        Vector2 pos = transform.position;
        
        float t = 1 - time / animationTime;
        foreach (Transform ray in rays)
        {
            Vector3 scale = ray.localScale;
            scale.x = xCurve.Evaluate(t);
            scale.y = yCurve.Evaluate(t);

            RaycastHit2D hit = Physics2D.Raycast(pos, ray.right, maxLength[ray], layerMask);
            if (hit)
            {
                maxLength[ray] = Mathf.Min(maxLength[ray], Vector2.Distance(pos, hit.point));

                if (hit.collider.TryGetComponent(out IExplodable explodable))
                {
                    explodable.Explode();
                }
            }

            scale.x = Mathf.Min(scale.x, maxLength[ray]);

            ray.localScale = scale;
        }
    }
}