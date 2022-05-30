using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class AStarAxisProvider : AxisProvider
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float bombRadius;
    
    private readonly List<Vector3> path = new List<Vector3>();

    private void Start()
    {
        StartCoroutine(ProcessPath());
    }

    private IEnumerator ProcessPath()
    {
        do
        {
            yield return GetPathToTarget();
        } while (gameObject.activeSelf);
    }

    private IEnumerator GetPathToTarget()
    {
        if (target != null)
            yield return GetPath(target.position, path);
        if (path.Count > 1)
        {
            Axis = (path[1] - transform.position).normalized;
        }
        else
        {
            Axis = Vector2.zero;
        }
    }

    private IEnumerator GetPath(Vector3 target, List<Vector3> vectorPath)
    {
        ABPath path = ABPath.Construct(transform.position, target);
        AstarPath.StartPath(path, true);

        yield return new WaitUntil(() => path.CompleteState == PathCompleteState.Complete);
        
        vectorPath.Clear();
        vectorPath.AddRange(path.vectorPath);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, bombRadius);
    }
}
