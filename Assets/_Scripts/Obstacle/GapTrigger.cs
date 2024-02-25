using UnityEngine;

/// <summary>
/// A class representing a trigger between two pillars, which player is supposed to go through.
/// </summary>
public class GapTrigger : MonoBehaviour
{
    // It triggers on exit so that the score is added only once when the player goes through the gap.
    private void OnTriggerExit2D(Collider2D collision)
    {
        ScoreManager.Instance.AddScore(1);
    }
}
