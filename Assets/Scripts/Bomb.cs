using UnityEngine;

[RequireComponent(typeof(ObjectSpawner))]
public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float fuseTime;

    private Timer timer;
    
    private void Start()
    {
        timer = new Timer(this, fuseTime);
        timer.TimerFinished += OnExplode;
    }

    private void OnExplode()
    {
        GetComponent<ObjectSpawner>().Spawn();
        Destroy(gameObject);
    }
}