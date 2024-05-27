using UnityEngine;
using UnityEngine.Serialization;

public class OnPauseMenu : MonoBehaviour
{
    [FormerlySerializedAs("ObjectToActiveAndDeactivate")] public GameObject objectToActiveAndDeactivate;

    private void Start()
    {

    }

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

    public void pauseStop()
    {
        Time.timeScale = 1f;
    }
}
