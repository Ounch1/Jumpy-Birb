using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private bool repeatedSpawnEnabled = false;
    [SerializeField] private float spawnRate = 3f;
    [Space]
    [SerializeField] private float randomXOffset = 0;
    [SerializeField] private float randomYOffset = 0.5f;

    private void Awake()
    {
        StartCoroutine(SpawnObjectCoroutine());
    }

    /// <summary>
    /// Coroutine to spawn objects repeatedly with a specified spawn rate.
    /// </summary>
    private IEnumerator SpawnObjectCoroutine()
    {
        // Spawn the first object immediately
        SpawnObject();

        while (true && repeatedSpawnEnabled)
        {
            // Wait for spawnRate seconds before spawning the next object
            yield return new WaitForSeconds(spawnRate);
            SpawnObject();
        }
    }

    /// <summary>
    /// Instantiates an object of choice at the spawner's position.
    /// </summary>
    public void SpawnObject()
    {
        Instantiate(objectToSpawn, new Vector3(transform.position.x + Random.Range(-randomXOffset, randomXOffset), 
                                               transform.position.y + Random.Range(-randomXOffset, randomXOffset), 
                                               0), Quaternion.identity);
    }
}
