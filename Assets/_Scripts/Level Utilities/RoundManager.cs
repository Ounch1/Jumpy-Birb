using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private static RoundManager instance;
    public static RoundManager Instance => instance;

    [SerializeField] private ObjectSpawner obstacleSpawner;
    [SerializeField] private Rigidbody2D playerRb;
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
    }

    private void Start()
    {
        playerRb.isKinematic = true;
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
        playerRb.isKinematic = false;
        obstacleSpawner.gameObject.SetActive(true);
        mainMenu.SetActive(false);
    }

    /// <summary>
    /// Disable the player movement and the obstacle spawner
    /// </summary>
    public void EndRound()
    {
        playerRb.isKinematic = true;
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
