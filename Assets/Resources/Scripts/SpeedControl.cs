using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    public void Accelerate()
    {
        Time.timeScale = 2f;
        
    }public void AccelerateFaster()
    {
        Time.timeScale = 3f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Reset()
    {
        Time.timeScale = 1f;
    }
    public void Slow()
    {
        Time.timeScale = 0.5f;
    }
}
