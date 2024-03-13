using UnityEngine;

[CreateAssetMenu(fileName = "Spawn Setting", menuName = "Spawn Settings")]
public class SpawnSetting : ScriptableObject
{
    public float spawnRate = 3f;
    public float randomXOffset = 0;
    public float randomYOffset = 0.5f;
}