using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private bool repeatedSpawnEnabled = false;
    [SerializeField] private SpawnSetting spawnSettings;

    private void Awake()
    {
        StartCoroutine(SpawnObjectCoroutine());
    }

    /// <summary>
    /// Setter method to change spawn settings, can be used to adjust difficulty.
    /// </summary>
    public void SetSpawnSettings(SpawnSetting settings)
    {
        spawnSettings = settings;
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
            yield return new WaitForSeconds(spawnSettings.spawnRate);
            SpawnObject();
        }
    }

    /// <summary>
    /// Instantiates an object of choice at the spawner's position.
    /// </summary>
    public void SpawnObject()
    {
        Instantiate(objectToSpawn, new Vector3(transform.position.x + Random.Range(-spawnSettings.randomXOffset, spawnSettings.randomXOffset), 
                                               transform.position.y + Random.Range(-spawnSettings.randomYOffset, spawnSettings.randomYOffset), 
                                               0), Quaternion.identity);
    }
}
