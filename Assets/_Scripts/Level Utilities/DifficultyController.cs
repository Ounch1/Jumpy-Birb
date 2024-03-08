using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    void Update()
    {
        if (RoundManager.Instance.RoundStarted) return; // If the round has started, player shouldnt be able to choose difficulty.

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchDifficulty(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchDifficulty(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchDifficulty(3);
        }
    }

    private void SwitchDifficulty(int difficultyID)
    {
        print("Difficulty switched to " + difficultyID);
    }
}
