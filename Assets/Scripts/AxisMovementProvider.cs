using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AxisProvider))]
public class AxisMovementProvider : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private new Rigidbody2D rigidbody2D;
    private AxisProvider axisProvider;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        axisProvider = GetComponent<AxisProvider>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = axisProvider.Axis * speed;
    }
}