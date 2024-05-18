using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTurret : MonoBehaviour
{
    private Archi archiClass;

    public SpriteRenderer spriteRenderer1_Id1;
    public SpriteRenderer spriteRenderer2_Id1;
    public SpriteRenderer spriteRenderer3_Id1; 
    public SpriteRenderer spriteRenderer4_Id1;

    public SpriteRenderer spriteRenderer1_Id2;
    public SpriteRenderer spriteRenderer2_Id2;
    public SpriteRenderer spriteRenderer3_Id2;
    public SpriteRenderer spriteRenderer4_Id2;// R�f�rence au SpriteRenderer du sprite que vous voulez afficher
    public Button button;  // R�f�rence au bouton1

    // Fonction appel�e lors du clic sur le bouton
    void OnButtonClick()
    {
        Debug.Log("clique");
        archiClass.switchToEnabled(1);// Inverser la visibilit� du sprite lors du clic sur le bouton

        if (gameObject.CompareTag("Turret Slow"))
        {
            archiClass.ChoiceType(1);
            Debug.Log("Turret Slow cliqu�e");
        }
        else if (gameObject.CompareTag("Turret Medium"))
        {
            archiClass.ChoiceType(2);
            Debug.Log("Turret Medium cliqu�e");
        }
        else if (gameObject.CompareTag("Turret Fast"))
        {
            archiClass.ChoiceType(3);
            Debug.Log("Turret Fast cliqu�e");
        }
    }

    public bool IsSpriteEnabled()
    {
        return spriteRenderer1_Id1.enabled || spriteRenderer2_Id2.enabled; // Retourne l'�tat actuel du SpriteRenderer
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

        // Assurez-vous que le spriteRenderer est non null
        if (spriteRenderer1_Id1 == null && spriteRenderer2_Id1 == null && spriteRenderer3_Id1 == null && spriteRenderer4_Id1 == null && spriteRenderer1_Id2 == null && spriteRenderer2_Id2 == null && spriteRenderer3_Id2 == null && spriteRenderer4_Id2 == null)
        {
            Debug.LogError("Veuillez attacher un SpriteRenderer au script dans l'inspecteur Unity.");
        }
    }
}
