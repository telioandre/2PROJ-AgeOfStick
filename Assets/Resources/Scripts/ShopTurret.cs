// This script manages the turret shop in a castle defense game.
// It handles turret selection and placement, as well as UI interactions with buttons.

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopTurret : MonoBehaviour
{
    private Archi _archiClass;

    // Initialization of the 4 turret slots for each player 
    [FormerlySerializedAs("Position1_Id1")] public GameObject position1Id1;
    [FormerlySerializedAs("Position2_Id1")] public GameObject position2Id1;
    [FormerlySerializedAs("Position3_Id1")] public GameObject position3Id1;
    [FormerlySerializedAs("Position4_Id1")] public GameObject position4Id1;

    [FormerlySerializedAs("Position1_Id2")] public GameObject position1Id2;
    [FormerlySerializedAs("Position2_Id2")] public GameObject position2Id2;
    [FormerlySerializedAs("Position3_Id2")] public GameObject position3Id2;
    [FormerlySerializedAs("Position4_Id2")] public GameObject position4Id2;

    public Button button;  // Reference to the button (itself)

    // Function called when button is clicked
    void OnButtonClick()
    {
        _archiClass.SwitchToEnabled(1);

        if (gameObject.CompareTag("Turret Slow"))
        {
            _archiClass.ChoiceType(1);
            _archiClass.delete = 0;
        }
        else if (gameObject.CompareTag("Turret Medium"))
        {
            _archiClass.ChoiceType(2);
            _archiClass.delete = 0;
        }
        else if (gameObject.CompareTag("Turret Fast"))
        {
            _archiClass.ChoiceType(3);
            _archiClass.delete = 0;
        }
        else if (gameObject.CompareTag("Delete Turret"))
        {
            _archiClass.delete = 1;
        }
    }

    // Checks if one of the SpriteRenderers is activated
    public bool IsSpriteEnabled()
    {
        return IsSpriteRendererEnabled(position1Id1) || IsSpriteRendererEnabled(position2Id2);
    }

    // Auxiliary function to check whether a SpriteRenderer is activated
    private bool IsSpriteRendererEnabled(GameObject obj)
    {
        if (obj != null)
        {
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                return sr.enabled;
            }
        }
        return false;
    }

    // Start-up function 
    void Start()
    {
        _archiClass = FindObjectOfType<Archi>();

        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }
}