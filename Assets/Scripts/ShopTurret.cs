using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTurret : MonoBehaviour
{
    private Archi archiClass;

    public GameObject Position1_Id1;
    public GameObject Position2_Id1;
    public GameObject Position3_Id1;
    public GameObject Position4_Id1;

    public GameObject Position1_Id2;
    public GameObject Position2_Id2;
    public GameObject Position3_Id2;
    public GameObject Position4_Id2;

    public Button button;  // Référence au bouton


    // Fonction appelée lors du clic sur le bouton
    void OnButtonClick()
    {
        Debug.Log("Clic sur le bouton");

        archiClass.switchToEnabled(1); // Inverser la visibilité du sprite lors du clic sur le bouton

        if (gameObject.CompareTag("Turret Slow"))
        {
            archiClass.ChoiceType(1);
            archiClass.delete = 0;
            Debug.Log("Turret Slow cliquée");
        }
        else if (gameObject.CompareTag("Turret Medium"))
        {
            archiClass.ChoiceType(2);
            archiClass.delete = 0;
            Debug.Log("Turret Medium cliquée");
        }
        else if (gameObject.CompareTag("Turret Fast"))
        {
            archiClass.ChoiceType(3);
            archiClass.delete = 0;
            Debug.Log("Turret Fast cliquée");
        }
        else if (gameObject.CompareTag("Delete Turret"))
        {
            Debug.Log("Delete Turret cliquée");
            archiClass.delete = 1;
        }
    }

    // Vérifie si l'un des SpriteRenderers est activé
    public bool IsSpriteEnabled()
    {
        return IsSpriteRendererEnabled(Position1_Id1) || IsSpriteRendererEnabled(Position2_Id2);
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
        archiClass = FindObjectOfType<Archi>();

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
        if (Position1_Id1 == null || Position2_Id1 == null || Position3_Id1 == null || Position4_Id1 == null ||
            Position1_Id2 == null || Position2_Id2 == null || Position3_Id2 == null || Position4_Id2 == null)
        {
            Debug.LogError("Veuillez attacher tous les GameObjects nécessaires au script dans l'inspecteur Unity.");
        }
    }
}
