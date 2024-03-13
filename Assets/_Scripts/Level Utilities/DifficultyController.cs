using System;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyController : MonoBehaviour
{
    private static DifficultyController instance;

    public static DifficultyController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DifficultyController>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("Difficulty Controller");
                    instance = obj.AddComponent<DifficultyController>();
                }
            }
            return instance;
        }
    }
    private DifficultyController()
    {
        OnDifficultyUpdate = new UnityEvent();
    }

    [SerializeField] ObjectSpawner spawner;
    [Space]
    [SerializeField] private SpawnSetting easySetting;
    [SerializeField] private SpawnSetting mediumSetting;
    [SerializeField] private SpawnSetting hardSetting;
    private SpawnSetting currentSetting;
    public SpawnSetting GetCurrentSetting() { return currentSetting; }
    public UnityEvent OnDifficultyUpdate;

    private void Awake()
    {
        currentSetting = easySetting; // Default to easy
        spawner.SetSpawnSettings(currentSetting);
    }
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
            currentSetting = setting;
            spawner.SetSpawnSettings(setting);
            OnDifficultyUpdate?.Invoke();
            print("Switched difficulty to " + setting.name);
        }
    }
}
