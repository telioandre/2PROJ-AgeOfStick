using UnityEngine;

public class ScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    public void Resolution1()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }

    public void Resolution2()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    public void Resolution3()
    {
        Screen.SetResolution(2560, 1440, FullScreenMode.Windowed);
    }

    public void Resolution4()
    {
        Screen.SetResolution(3440, 1440, FullScreenMode.Windowed);
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

}
