using UnityEngine;

public class ExplodableTile : MonoBehaviour, IExplodable
{
    public void Explode()
    {
        Destroy(gameObject);
    }
}
