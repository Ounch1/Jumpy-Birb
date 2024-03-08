using System;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    [SerializeField] ObjectSpawner spawner;
    [Space]
    [SerializeField] private SpawnSetting easySetting;
    [SerializeField] private SpawnSetting mediumSetting;
    [SerializeField] private SpawnSetting hardSetting;

    void Update()
    {
        if (RoundManager.Instance.RoundStarted) return; // If the round has started, player shouldnt be able to choose difficulty.

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchDifficulty(easySetting);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchDifficulty(mediumSetting);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchDifficulty(hardSetting);
        }
    }

    private void SwitchDifficulty(SpawnSetting setting)
    {
        if (setting != null)
        {
            spawner.SetSpawnSettings(setting);
            print("Switched difficulty to " + setting.name);
        }
    }
}
