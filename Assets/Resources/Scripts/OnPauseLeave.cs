using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPauseLeave : MonoBehaviour
{
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
}