using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public GameObject Spawn()
    {
        Vector2 pos = Vector2Int.FloorToInt(transform.position) + Vector2.one * 0.5f;
        return Instantiate(prefab, pos, Quaternion.identity);
    }
}