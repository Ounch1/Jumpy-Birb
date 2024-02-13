using UnityEngine;

public class RoundStarter : MonoBehaviour
{
    [SerializeField] private ObjectSpawner obstacleSpawner;
    [SerializeField] private Rigidbody2D playerRb;

    private void Start()
    {
        playerRb.isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartRound();
        }
    }

    public void StartRound()
    {
        playerRb.isKinematic = false;
        obstacleSpawner.gameObject.SetActive(true);
        gameObject.SetActive(false); // Disable round starter
    }
}
