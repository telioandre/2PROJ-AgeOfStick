using UnityEngine;
using UnityEngine.UI;

public class TourelleLente : MonoBehaviour
{
    private Archi archiClass;

    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;// R�f�rence au SpriteRenderer du sprite que vous voulez afficher
    public Button button;  // R�f�rence au bouton

    // Fonction appel�e lors du clic sur le bouton
    void OnButtonClick()
    {
        Debug.Log("clique");
        spriteRenderer1.enabled = !spriteRenderer1.enabled;
        spriteRenderer2.enabled = !spriteRenderer2.enabled;
        spriteRenderer3.enabled = !spriteRenderer3.enabled;// Inverser la visibilit� du sprite lors du clic sur le bouton

        if (gameObject.CompareTag("Turret Slow"))
        {
            Debug.Log("Turret Slow cliqu�e");
            archiClass.ChoiceType(1);
        }
        else if (gameObject.CompareTag("Turret Medium"))
        {
            Debug.Log("Turret Medium cliqu�e");
            archiClass.ChoiceType(2);
        }
        else if (gameObject.CompareTag("Turret Fast"))
        {
            Debug.Log("Turret Fast cliqu�e");
            archiClass.ChoiceType(3);
        }
    }

    public bool IsSpriteEnabled()
    {
        return spriteRenderer1.enabled; // Retourne l'�tat actuel du SpriteRenderer
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
        if (spriteRenderer1 == null && spriteRenderer2 == null && spriteRenderer3 == null)
        {
            Debug.LogError("Veuillez attacher un SpriteRenderer au script dans l'inspecteur Unity.");
        }
        else
        {            
            // D�sactivez le sprite au d�marrage
            spriteRenderer1.enabled = false;
            spriteRenderer2.enabled = false;
            spriteRenderer3.enabled = false;
        }
    }
}
