using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Turret : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public string name1 = "none";
    public string age = "none";
    public int type = 0;
    public int placement = 0;


    // Constructeur de la classe
    public void Initialize(string nameTurret, string ageTurret, int typeTurret, int placementTurret)
    {
        name1 = nameTurret;
        age = ageTurret;
        type = typeTurret;
        placement = placementTurret;
        // Obtenez le composant SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Assurez-vous que le composant SpriteRenderer existe
        if (spriteRenderer == null)
        {
            // Si le SpriteRenderer n'est pas trouvé sur cet objet, ajoutez-le
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
    }

    public void SetPosition()
    {
        if (placement == 1)
        {
            transform.position = new Vector3(118, 757, 244);
        }
        else if(placement == 2){
            transform.position = new Vector3(118, 882, 244);
        }
        else if (placement == 3)
        {
            transform.position = new Vector3(118, 1005, 244);
        }
    }

    public void SetSprite()
    {
        if (type == 1)
        {
            Sprite newSprite = Resources.Load<Sprite>("HexagonFlat");
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
                Debug.Log("Sprite HexagonFlat chargé avec succès.");
            }
            else
            {
                Debug.LogError("Le sprite HexagonFlat n'a pas été trouvé dans les ressources.");
            }
        }
        else if (type == 2)
        {
            Sprite newSprite = Resources.Load<Sprite>("IsometricDiamond");
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
                Debug.Log("Sprite IsometricDiamond chargé avec succès.");
            }
            else
            {
                Debug.LogError("Le sprite IsometricDiamond n'a pas été trouvé dans les ressources.");
            }
        }
        else if (type == 3)
        {
            Sprite newSprite = Resources.Load<Sprite>("Circle");
            if (newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
                Debug.Log("Sprite Circle chargé avec succès.");
            }
            else
            {
                Debug.LogError("Le sprite Circle n'a pas été trouvé dans les ressources.");
            }
        }

    }
}
