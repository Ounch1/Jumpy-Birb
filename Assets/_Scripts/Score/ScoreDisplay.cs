using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contains methods to display highscore or current score on a UI text component.
/// </summary>
public class ScoreDisplay : MonoBehaviour
{
    public enum ScoreType // score type to display
    {
        CURRENTSCORE,
        HIGHSCORE
    }

    [SerializeField] public ScoreType scoreType;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();

        ScoreManager.Instance.OnScoreUpdate.AddListener(UpdateScore);

        UpdateScore(); // Update the text component when the game starts.
    }

    /// <summary>
    /// Update the text component with the current score or high score.
    /// </summary>
    private void UpdateScore()
    {
        if (scoreType == ScoreType.CURRENTSCORE)
        {
            text.text = ScoreManager.Instance.CurrentScore.ToString();
        }
        else if (scoreType == ScoreType.HIGHSCORE)
        {
            text.text = ScoreManager.Instance.HighScore.ToString();
        }
    }
}
