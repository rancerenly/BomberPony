using System.Collections.Generic;
using UnityEngine;

public class RayExplosion : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer right;
    
    [SerializeField]
    private SpriteRenderer up;
    
    [SerializeField]
    private SpriteRenderer left;
    
    [SerializeField]
    private SpriteRenderer down;
    
    [SerializeField]
    private float animationTime;

    [SerializeField]
    private AnimationCurve xCurve;

    [SerializeField]
    private AnimationCurve yCurve;

    [SerializeField]
    private LayerMask layerMask;

    private readonly Dictionary<SpriteRenderer, float> maxLength = new Dictionary<SpriteRenderer, float>();
    private readonly Dictionary<SpriteRenderer, Vector2> directions = new Dictionary<SpriteRenderer, Vector2>();

    private readonly Dictionary<SpriteRenderer, BoxCollider2D> colliders =
        new Dictionary<SpriteRenderer, BoxCollider2D>();

    private SpriteRenderer[] Rays => new[] { right, up, left, down };
    
    private void Start()
    {
        float d = xCurve.Evaluate(1);
        foreach (SpriteRenderer ray in Rays)
        {
            maxLength.Add(ray, d);
            colliders.Add(ray, ray.GetComponent<BoxCollider2D>());
        }
        
        directions.Add(right, Vector2.right);
        directions.Add(up, Vector2.up);
        directions.Add(left, Vector2.left);
        directions.Add(down, Vector2.down);

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
        foreach (SpriteRenderer ray in Rays)
        {
            Vector2 size = ray.size;
            size.x = xCurve.Evaluate(t);
            size.y = yCurve.Evaluate(t);

            RaycastHit2D hit = Physics2D.Raycast(pos, directions[ray], maxLength[ray], layerMask);
            if (hit)
            {
                maxLength[ray] = Mathf.Max(Mathf.Min(maxLength[ray], Vector2.Distance(pos, hit.point) - 1), 0);

                if (hit.collider.TryGetComponent(out IExplodable explodable))
                {
                    explodable.Explode();
                }
            }

            size.x = Mathf.Min(size.x, maxLength[ray]);

            colliders[ray].size = ray.size = size;
            colliders[ray].offset = new Vector2(size.x / 2, 0);
        }
    }
}