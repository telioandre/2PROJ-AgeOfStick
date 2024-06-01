using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPauseLeave : MonoBehaviour
{
    /*
     * Method to go back to the main menu.
     */
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
}