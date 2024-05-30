using UnityEngine;
using UnityEngine.UI;
public class OnlineButton : MonoBehaviour
{
    public static bool status;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SetStatus);
    }
    void SetStatus()
    {
        status = true;
    }
}