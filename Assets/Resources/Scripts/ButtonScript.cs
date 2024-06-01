using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public DifficultyManager difficulty;

    /*
     * This start method will get the button component where the script is attached to.
     * Then it will add a listener for the difficulty choice.
     */
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    /*
     * Setter to let the player choose the difficulty depending on the DifficultyManager script usage.
     */
    void SetDifficulty()
    {
        DifficultyManager.UpdateDifficulty(difficulty);
    }
}
