using UnityEngine;
using System.Collections;

public class OnPauseMenu : MonoBehaviour
{
    public GameObject ObjectToActiveAndDeactivate;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ObjectToActiveAndDeactivate != null)
            {
                bool isActive = ObjectToActiveAndDeactivate.activeSelf;
                ObjectToActiveAndDeactivate.SetActive(!isActive);

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
}
