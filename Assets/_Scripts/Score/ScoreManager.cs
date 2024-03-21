using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Singleton class created to manage the player's score and high score.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("ScoreManager");
                    instance = obj.AddComponent<ScoreManager>();
                }
            }
            return instance;
        }
    }
    private ScoreManager()
    {
        OnScoreUpdate = new UnityEvent();
    }


    private int currentScore = 0;
    public int CurrentScore => currentScore;
    private int highScore = 0;
    public int HighScore => highScore;

    public UnityEvent OnScoreUpdate; // Invoked whenever the score is updated

    DifficultyController diffController;

    private void Start()
    {
        diffController = DifficultyController.Instance;
        highScore = PlayerPrefs.GetInt(diffController.GetCurrentSetting().name, 0);
        diffController.OnDifficultyUpdate.AddListener(UpdateHighScore);
        UpdateHighScore();
    }

    /// <summary>
    /// Update when switching difficulty.
    /// </summary>
    private void UpdateHighScore()
    {
        highScore = PlayerPrefs.GetInt(diffController.GetCurrentSetting().name, 0);
        OnScoreUpdate?.Invoke();
    }

    /// <summary>
    /// Adds the specified score to the current score and updates the high score if necessary.
    /// </summary>
    public void AddScore(int score)
    {
         currentScore += score*100;  
        
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(diffController.GetCurrentSetting().name, highScore);
            PlayerPrefs.Save();
        }

        OnScoreUpdate?.Invoke();
    }
}
