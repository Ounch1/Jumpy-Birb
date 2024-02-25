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

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    /// <summary>
    /// Adds the specified score to the current score and updates the high score if necessary.
    /// </summary>
    public void AddScore(int score)
    {
        currentScore += score;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        OnScoreUpdate?.Invoke();
    }
}
