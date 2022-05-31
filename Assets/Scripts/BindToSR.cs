using UnityEngine;

public class BindToSR : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Update()
    {
        Vector3 pos = transform.localPosition;
        pos.x = spriteRenderer.size.x;
        transform.localPosition = pos;
    }
}
