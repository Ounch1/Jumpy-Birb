using UnityEngine;

/// <summary>
/// Class that keeps track of the player's score and highscore.
/// </summary>
public class Score : MonoBehaviour
{
    private int score = 0;
    public int GetScore() => score;
    private int highscore;
    public int GetHighscore() => highscore;

    /// <summary>
    /// Add a point to the score and update the high score if necessary.
    /// </summary>
    public void AddScore(int amount)
    {
        score += amount;

        if (score > highscore)
        {
            highscore = score;
        }
    }

    /// <summary>
    /// Reset the score at the start of a new game.
    /// </summary>
    public void ResetScore()
    {
        score = 0;
    }
}