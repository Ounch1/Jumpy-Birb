using UnityEngine;
using UnityEngine.UI;

public class DifficultyDisplay : MonoBehaviour
{
    private Text text;
    private DifficultyController diffController;
    private void Awake()
    {
        text = GetComponent<Text>();
        diffController = DifficultyController.Instance;
        diffController.OnDifficultyUpdate?.AddListener(UpdateDifficultyText);
    }

    private void Start()
    {
        UpdateDifficultyText();
    }

    private void UpdateDifficultyText()
    {
        text.text = "Choose difficulty(1-3)\nCurrent Difficulty: " + diffController.GetCurrentSetting().name;
    }
}
