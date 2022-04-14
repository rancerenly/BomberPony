using System;
using System.Collections;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GraphUpdater : MonoBehaviour
{
    [SerializeField]
    private bool processOnUpdate;
    
    private new Collider2D collider;
    private Bounds bounds;
    
    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        bounds = collider.bounds;
    }

    private void Update()
    {
        if (!processOnUpdate)
        {
            return;
        }
        
        Recalc(false);
        bounds = collider.bounds;
        Recalc(true);
    }

    private void Recalc(bool walkable)
    {
        GraphUpdateObject guo = new GraphUpdateObject(bounds)
        {
            modifyWalkability = true,
            setWalkability = !walkable
        };
        
        AstarPath path = AstarPath.active;
        if (path != null)
        {
            path.UpdateGraphs(guo);
            path.FlushGraphUpdates();
        }
    }

    private void OnEnable()
    {
        Recalc(true);
    }

    private void OnDisable()
    {
        Recalc(false);
    }
}
