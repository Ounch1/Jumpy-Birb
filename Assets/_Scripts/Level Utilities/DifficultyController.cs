using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Controls the difficulty setting of the game. Can be switched with the number keys. The setting is saved between the game sessions.
/// </summary>
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
    [SerializeField] private SpawnSetting[] spawnSettings;

    private SpawnSetting currentSetting;
    public SpawnSetting GetCurrentSetting() { return currentSetting; }
    public UnityEvent OnDifficultyUpdate;

    private void Awake()
    {
        SwitchDifficulty(LoadDifficulty()); // Set initial difficulty getting difficulty ID from PlayerPrefs. Defaults to 0 if no ID's were found.
    }
    void Update()
    {
        if (RoundManager.Instance.RoundStarted) return; // If the round has started, player shouldnt be able to choose difficulty.

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchDifficulty(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchDifficulty(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchDifficulty(2);
        }
    }

    /// <summary>
    /// Switches the difficulty setting to the one specified by the setting ID.
    /// </summary>
    /// <param name="settingID">The ID of the difficulty setting to switch to.</param>
    private void SwitchDifficulty(int settingID)
    {
        if (spawnSettings[settingID] != null)
        {
            currentSetting = spawnSettings[settingID];
            spawner.SetSpawnSettings(currentSetting);
            SaveDifficulty(settingID);
            OnDifficultyUpdate?.Invoke();
            print("Switched difficulty to " + spawnSettings[settingID].name);
        }
        else
        {
            print("Invalid difficulty setting.");
        }
    }

    /// <summary>
    /// Saves the current difficulty setting to PlayerPrefs.
    /// </summary>
    /// <param name="settingID">The ID of the current difficulty setting.</param>
    private void SaveDifficulty(int settingID)
    {
        PlayerPrefs.SetInt("Difficulty", settingID);
    }

    /// <summary>
    /// Loads the difficulty setting from PlayerPrefs.
    /// </summary>
    /// <returns>The ID of the loaded difficulty setting.</returns>
    private int LoadDifficulty()
    { 
        return PlayerPrefs.GetInt("Difficulty", 0);
    }
}
