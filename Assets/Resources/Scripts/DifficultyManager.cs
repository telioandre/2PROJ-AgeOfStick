using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager difficulty;

    /*
     * This method will set up the difficulty depending on the pressed button.
     */
    public static void UpdateDifficulty(DifficultyManager newDifficulty)
    {
        difficulty = newDifficulty;
    }
}
