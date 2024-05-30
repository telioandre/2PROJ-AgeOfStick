using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopTurret : MonoBehaviour
{
    private Archi _archiClass;

    [FormerlySerializedAs("Position1_Id1")] public GameObject position1Id1;
    [FormerlySerializedAs("Position2_Id1")] public GameObject position2Id1;
    [FormerlySerializedAs("Position3_Id1")] public GameObject position3Id1;
    [FormerlySerializedAs("Position4_Id1")] public GameObject position4Id1;

    [FormerlySerializedAs("Position1_Id2")] public GameObject position1Id2;
    [FormerlySerializedAs("Position2_Id2")] public GameObject position2Id2;
    [FormerlySerializedAs("Position3_Id2")] public GameObject position3Id2;
    [FormerlySerializedAs("Position4_Id2")] public GameObject position4Id2;

    public Button button;  // R�f�rence au bouton


    // Fonction appel�e lors du clic sur le bouton
    void OnButtonClick()
    {
        Debug.Log("Clic sur le bouton");

        _archiClass.SwitchToEnabled(1); // Inverser la visibilit� du sprite lors du clic sur le bouton

        if (gameObject.CompareTag("Turret Slow"))
        {
            _archiClass.ChoiceType(1);
            _archiClass.delete = 0;
            Debug.Log("Turret Slow cliqu�e");
        }
        else if (gameObject.CompareTag("Turret Medium"))
        {
            _archiClass.ChoiceType(2);
            _archiClass.delete = 0;
            Debug.Log("Turret Medium cliqu�e");
        }
        else if (gameObject.CompareTag("Turret Fast"))
        {
            _archiClass.ChoiceType(3);
            _archiClass.delete = 0;
            Debug.Log("Turret Fast cliqu�e");
        }
        else if (gameObject.CompareTag("Delete Turret"))
        {
            Debug.Log("Delete Turret cliqu�e");
            _archiClass.delete = 1;
        }
    }

    // V�rifie si l'un des SpriteRenderers est activ�
    public bool IsSpriteEnabled()
    {
        return IsSpriteRendererEnabled(position1Id1) || IsSpriteRendererEnabled(position2Id2);
    }

    // Fonction auxiliaire pour v�rifier si un SpriteRenderer est activ�
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

    void Start()
    {
        _archiClass = FindObjectOfType<Archi>();

        // Assurez-vous que le bouton est non null
        if (button != null)
        {
            // Ajoutez un �couteur d'�v�nements pour d�tecter le clic sur le bouton
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Veuillez attacher un bouton au script dans l'inspecteur Unity.");
        }

        // V�rifiez que les GameObjects n�cessaires sont attach�s
        if (position1Id1 == null || position2Id1 == null || position3Id1 == null || position4Id1 == null ||
            position1Id2 == null || position2Id2 == null || position3Id2 == null || position4Id2 == null)
        {
            Debug.LogError("Veuillez attacher tous les GameObjects n�cessaires au script dans l'inspecteur Unity.");
        }
    }
}
