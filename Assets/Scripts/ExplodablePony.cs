using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodablePony : MonoBehaviour, IExplodable
{
    public void Explode()
    {
        Destroy(gameObject);
    }
}
