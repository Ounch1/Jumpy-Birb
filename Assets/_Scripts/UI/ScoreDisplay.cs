using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Score))]
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text highScoreText;

    private Score scoreComponent;

    private void Update()
    {
        currentScoreText.text = scoreComponent.GetScore().ToString();
        highScoreText.text = scoreComponent.GetHighscore().ToString();
    }

    private void Start()
    {
        scoreComponent = GetComponent<Score>();
    }
}

