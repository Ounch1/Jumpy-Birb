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
        text.text = "<" + diffController.GetCurrentSetting().name + ">";
    }
}
