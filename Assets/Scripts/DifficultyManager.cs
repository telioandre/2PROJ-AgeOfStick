using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager difficulty;

    public static void UpdateDifficulty(DifficultyManager newDifficulty)
    {
        difficulty = newDifficulty;
    }
}
