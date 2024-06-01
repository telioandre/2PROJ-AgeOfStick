using UnityEngine;

public class ScreenController : MonoBehaviour
{
    /*
     * This start method is used to set a default resolution.
     */
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    /*
     * This method is used to set a 1280x720 resolution.
     */
    public void Resolution1()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }

    /*
     * This method is used to set a 1920x1080 resolution.
     */
    public void Resolution2()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    /*
     * This method is used to set a 2560x1440 resolution.
     */
    public void Resolution3()
    {
        Screen.SetResolution(2560, 1440, FullScreenMode.Windowed);
    }

    /*
     * This method is used to set a 3440x1440 resolution.
     */
    public void Resolution4()
    {
        Screen.SetResolution(3440, 1440, FullScreenMode.Windowed);
    }

    /*
     * This method is used to set a full screen resolution.
     */
    public void SetFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

}
