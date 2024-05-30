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

    public Button button;  // Référence au bouton


    // Fonction appelée lors du clic sur le bouton
    void OnButtonClick()
    {
        Debug.Log("Clic sur le bouton");

        _archiClass.SwitchToEnabled(1); // Inverser la visibilité du sprite lors du clic sur le bouton

        if (gameObject.CompareTag("Turret Slow"))
        {
            _archiClass.ChoiceType(1);
            _archiClass.delete = 0;
            Debug.Log("Turret Slow cliquée");
        }
        else if (gameObject.CompareTag("Turret Medium"))
        {
            _archiClass.ChoiceType(2);
            _archiClass.delete = 0;
            Debug.Log("Turret Medium cliquée");
        }
        else if (gameObject.CompareTag("Turret Fast"))
        {
            _archiClass.ChoiceType(3);
            _archiClass.delete = 0;
            Debug.Log("Turret Fast cliquée");
        }
        else if (gameObject.CompareTag("Delete Turret"))
        {
            Debug.Log("Delete Turret cliquée");
            _archiClass.delete = 1;
        }
    }

    // Vérifie si l'un des SpriteRenderers est activé
    public bool IsSpriteEnabled()
    {
        return IsSpriteRendererEnabled(position1Id1) || IsSpriteRendererEnabled(position2Id2);
    }

    // Fonction auxiliaire pour vérifier si un SpriteRenderer est activé
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
            // Ajoutez un écouteur d'événements pour détecter le clic sur le bouton
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Veuillez attacher un bouton au script dans l'inspecteur Unity.");
        }

        // Vérifiez que les GameObjects nécessaires sont attachés
        if (position1Id1 == null || position2Id1 == null || position3Id1 == null || position4Id1 == null ||
            position1Id2 == null || position2Id2 == null || position3Id2 == null || position4Id2 == null)
        {
            Debug.LogError("Veuillez attacher tous les GameObjects nécessaires au script dans l'inspecteur Unity.");
        }
    }
}
