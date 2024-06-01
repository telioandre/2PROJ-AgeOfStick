using UnityEngine;
using UnityEngine.UI;
public class OnlineButton : MonoBehaviour
{
    public static bool status;

    /*
     * This start method will get the button component where the script is attached to.
     * Then it will add a listener for the online status.
     */
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SetStatus);
    }
    
    /*
     * Setter to know if the player is playing online.
     */
    void SetStatus()
    {
        status = true;
    }
}