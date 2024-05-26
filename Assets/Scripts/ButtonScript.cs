using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public DifficultyManager difficulty;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        DifficultyManager.UpdateDifficulty(difficulty);
    }
}
