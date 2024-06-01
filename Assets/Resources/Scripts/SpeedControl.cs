using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    /*
     * Method to speed up the game.
     */
    public void Accelerate()
    {
        Time.timeScale = 2f;
    }

    /*
     * Method to pause the game.
     */
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    /*
     * Method to put the default speed to the game.
     */
    public void Replay()
    {
        Time.timeScale = 1f;
    }
    
    /*
     * Method to slow down the game.
     */
    public void Slow()
    {
        Time.timeScale = 0.5f;
    }
}
