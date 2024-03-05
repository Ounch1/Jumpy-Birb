using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private static RoundManager instance;
    public static RoundManager Instance => instance;

    [SerializeField] private ObjectSpawner obstacleSpawner;
    [Space]
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject mainMenu;

    private bool roundStarted = false;
    private bool roundEnded = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        Time.timeScale = 0f; // Stop the game at the start
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !roundStarted || Input.GetKeyDown(KeyCode.Mouse0) && !roundStarted)
        {
            StartRound();
        }

        if (Input.GetKeyDown(KeyCode.Space) && roundEnded || Input.GetKeyDown(KeyCode.Mouse0) && roundEnded)
        {
            RestartRound();
        }
    }

    /// <summary>
    /// Enable the player movement and the obstacle spawner
    /// </summary>
    public void StartRound()
    {
        Time.timeScale = 1f; // Start the game
        obstacleSpawner.gameObject.SetActive(true);
        mainMenu.SetActive(false);
        roundStarted = true;
    }

    /// <summary>
    /// Disable the player movement and the obstacle spawner, allow restart
    /// </summary>
    public IEnumerator EndRound()
    {
        Time.timeScale = 0f; // Stop the game
        obstacleSpawner.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f); // Wait before allowing the player to restart the round, to prevent a missclick.
        roundEnded = true;
    }

    /// <summary>
    /// Reloads the scene
    /// </summary>
    public void RestartRound()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // hello
    // hi
}
