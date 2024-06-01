using UnityEngine;

public class OnPauseMenu : MonoBehaviour
{
    public GameObject objectToActiveAndDeactivate;

    /*
     * Method to escape the pause menu when it's activated.
     */
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (objectToActiveAndDeactivate != null)
            {
                bool isActive = objectToActiveAndDeactivate.activeSelf;
                objectToActiveAndDeactivate.SetActive(!isActive);

                if (!isActive)
                {
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }
        }
    }

    /*
     * Method to deliver the game after it was on pause.
     */
    public void PauseStop()
    {
        Time.timeScale = 1f;
    }
}
