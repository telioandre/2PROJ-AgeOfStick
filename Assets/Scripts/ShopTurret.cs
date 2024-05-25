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

    public Button button;  // R�f�rence au bouton


    // Fonction appel�e lors du clic sur le bouton
    void OnButtonClick()
    {
        Debug.Log("Clic sur le bouton");

        archiClass.switchToEnabled(1); // Inverser la visibilit� du sprite lors du clic sur le bouton

        if (gameObject.CompareTag("Turret Slow"))
        {
            archiClass.ChoiceType(1);
            archiClass.delete = 0;
            Debug.Log("Turret Slow cliqu�e");
        }
        else if (gameObject.CompareTag("Turret Medium"))
        {
            archiClass.ChoiceType(2);
            archiClass.delete = 0;
            Debug.Log("Turret Medium cliqu�e");
        }
        else if (gameObject.CompareTag("Turret Fast"))
        {
            archiClass.ChoiceType(3);
            archiClass.delete = 0;
            Debug.Log("Turret Fast cliqu�e");
        }
        else if (gameObject.CompareTag("Delete Turret"))
        {
            Debug.Log("Delete Turret cliqu�e");
            archiClass.delete = 1;
        }
    }

    // V�rifie si l'un des SpriteRenderers est activ�
    public bool IsSpriteEnabled()
    {
        return IsSpriteRendererEnabled(Position1_Id1) || IsSpriteRendererEnabled(Position2_Id2);
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
        archiClass = FindObjectOfType<Archi>();

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
        if (Position1_Id1 == null || Position2_Id1 == null || Position3_Id1 == null || Position4_Id1 == null ||
            Position1_Id2 == null || Position2_Id2 == null || Position3_Id2 == null || Position4_Id2 == null)
        {
            Debug.LogError("Veuillez attacher tous les GameObjects n�cessaires au script dans l'inspecteur Unity.");
        }
    }
}
