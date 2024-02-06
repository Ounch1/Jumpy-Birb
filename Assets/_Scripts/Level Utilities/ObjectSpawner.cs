using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [Space]
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private Transform spawnPos;

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnRate, 0);
    }
    /// <summary>
    /// Instantiates an object of choice at a defined position.
    /// </summary>
    private void SpawnObject()
    {
        Instantiate(gameObject, spawnPos.position, Quaternion.identity);
    }
}
