using UnityEngine;

[RequireComponent(typeof(ObjectSpawner))]
public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float fuseTime;
    
    private void Start()
    {
        Timer timer = new Timer(this, fuseTime);
        timer.TimerFinished += OnExplode;
    }

    private void OnExplode()
    {
        GetComponent<ObjectSpawner>().Spawn();
        Destroy(gameObject);
    }
}