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
        if (roundStarted) return; // If the round has already started, don't check for input

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartRound();
            roundStarted = true;
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
    }

    /// <summary>
    /// Disable the player movement and the obstacle spawner
    /// </summary>
    public void EndRound()
    {
        Time.timeScale = 0f; // Stop the game
        obstacleSpawner.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    /// <summary>
    /// Reloads the scene
    /// </summary>
    public void RestartRound()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
