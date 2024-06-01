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
        _archiClass.SwitchToEnabled(1); // Invert sprite visibility when button is clicked

        if (gameObject.CompareTag("Turret Slow")) // If the button is the slow turret button
        {
            _archiClass.ChoiceType(1); // Function that sends the turret selection made
            _archiClass.delete = 0; // Initialize delete to 0 to build a turret
            Debug.Log("Turret Slow clicked");
        }
        else if (gameObject.CompareTag("Turret Medium"))
        {
            _archiClass.ChoiceType(2); // Function that sends the turret selection made
            _archiClass.delete = 0; // Initialize delete to 0 to build a turret
            Debug.Log("Turret Medium clicked");
        }
        else if (gameObject.CompareTag("Turret Fast"))
        {
            _archiClass.ChoiceType(3); // Function that sends the turret selection made
            _archiClass.delete = 0; // Initialize delete to 0 to build a turret
            Debug.Log("Turret Fast clicked");
        }
        else if (gameObject.CompareTag("Delete Turret"))
        {
            _archiClass.delete = 1; // Initialize delete to 0 to delete the selected turret 
            Debug.Log("Delete Turret clicked");
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
        _archiClass = FindObjectOfType<Archi>(); // Retrieving the Archi class

        // Make sure the button is non-null
        if (button != null)
        {
            // Add event listener to detect button click
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Attach a button to the script in the Unity inspector.");
        }

        // Check that the necessary GameObjects are attached
        if (position1Id1 == null || position2Id1 == null || position3Id1 == null || position4Id1 == null ||
            position1Id2 == null || position2Id2 == null || position3Id2 == null || position4Id2 == null)
        {
            Debug.LogError("Please attach all the GameObjects required for the script in the Unity inspector.");
        }
    }
}
