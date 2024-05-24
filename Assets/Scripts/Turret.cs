using PlayFab.DataModels;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private EnemyShooting enemyShooting;

    public string name1 = "none";
    public int age = 1;
    public int type;
    public int placement;
    public int IdTurret;


    // Constructeur de la classe
    public void Initialize(string nameTurret, int ageTurret, int typeTurret, int placementTurret, int ID)
    {
        name1 = nameTurret;
        age = ageTurret;
        type = typeTurret;
        placement = placementTurret;
        IdTurret = ID;
        // Obtenez le composant SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyShooting = GetComponent<EnemyShooting>();
        // Assurez-vous que le composant SpriteRenderer existe
        if (spriteRenderer == null)
        {
            // Si le SpriteRenderer n'est pas trouvé sur cet objet, ajoutez-le
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
    }

    public int getIdTurret()
    {
        return IdTurret;
    }

    public void SetPosition(int ID)
    {
        if (ID == 1)
        {
            if (placement == 1)
            {
                transform.position = new Vector3(138, 690, 239);
                transform.localScale = new Vector3(60, 60, 5);
            }
            else if(placement == 2){
                transform.position = new Vector3(138, 775, 239);
                transform.localScale = new Vector3(60, 60, 5);
            }
            else if (placement == 3)
            {
                transform.position = new Vector3(138, 861, 239);
                transform.localScale = new Vector3(60, 60, 5);
            }
            else if (placement == 4)
            {
                transform.position = new Vector3(138, 948, 239);
                transform.localScale = new Vector3(60, 60, 5);
            }
        }else if (ID == 2)
        {
            if (placement == 1)
            {
                transform.position = new Vector3(6195, 690, 238);
                transform.localScale = new Vector3(60, 60, 5);
            }
            else if (placement == 2)
            {
                transform.position = new Vector3(6195, 773, 238);
                transform.localScale = new Vector3(60, 60, 5);
            }
            else if (placement == 3)
            {
                transform.position = new Vector3(6195, 860, 238);
                transform.localScale = new Vector3(60, 60, 5);
            }
            else if (placement == 4)
            {
                transform.position = new Vector3(6195, 946, 238);
                transform.localScale = new Vector3(60, 60, 5);
            }
        }
        
    }
    public void Setup()
    {
        if (age == 1)
        {
            if (type == 1)
            {
                Debug.Log("SetSprite 1");
                Sprite newSprite = Resources.Load<Sprite>("HexagonFlat");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    enemyShooting.damage = 40;
                    enemyShooting.delay = 1.2f;
                    Debug.Log("Sprite HexagonFlat chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite HexagonFlat n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 2)
            {
                Debug.Log("SetSprite 2");
                Sprite newSprite = Resources.Load<Sprite>("IsometricDiamond");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    enemyShooting.damage = 30;
                    enemyShooting.delay = 0.3f;
                    Debug.Log("Sprite IsometricDiamond chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite IsometricDiamond n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 3)
            {
                Debug.Log("SetSprite 3");
                Sprite newSprite = Resources.Load<Sprite>("Circle");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    enemyShooting.damage = 20;
                    enemyShooting.delay = 0.8f;
                    Debug.Log("Sprite Circle chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite Circle n'a pas été trouvé dans les ressources.");
                }
            }
            else
            {
                Debug.Log("Pas de SetSprite");
            }
        }
        else if (age == 2)
        {
            if (type == 1)
            {
                Debug.Log("SetSprite 1");
                Sprite newSprite = Resources.Load<Sprite>("HexagonFlat");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.red;
                    enemyShooting.damage = 60;
                    enemyShooting.delay = 1.2f;
                    Debug.Log("Sprite HexagonFlat chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite HexagonFlat n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 2)
            {
                Debug.Log("SetSprite 2");
                Sprite newSprite = Resources.Load<Sprite>("IsometricDiamond");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.red;
                    enemyShooting.damage = 45;
                    enemyShooting.delay = 0.3f;
                    Debug.Log("Sprite IsometricDiamond chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite IsometricDiamond n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 3)
            {
                Debug.Log("SetSprite 3");
                Sprite newSprite = Resources.Load<Sprite>("Circle");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.red;
                    enemyShooting.damage = 30;
                    enemyShooting.delay = 0.8f;
                    Debug.Log("Sprite Circle chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite Circle n'a pas été trouvé dans les ressources.");
                }
            }
            else
            {
                Debug.Log("Pas de SetSprite");
            }
        }else if (age == 3)
        {
            if (type == 1)
            {
                Debug.Log("SetSprite 1");
                Sprite newSprite = Resources.Load<Sprite>("HexagonFlat");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.blue;
                    enemyShooting.damage = 85;
                    enemyShooting.delay = 1.2f;
                    Debug.Log("Sprite HexagonFlat chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite HexagonFlat n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 2)
            {
                Debug.Log("SetSprite 2");
                Sprite newSprite = Resources.Load<Sprite>("IsometricDiamond");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.blue;
                    enemyShooting.damage = 67;
                    enemyShooting.delay = 0.3f;
                    Debug.Log("Sprite IsometricDiamond chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite IsometricDiamond n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 3)
            {
                Debug.Log("SetSprite 3");
                Sprite newSprite = Resources.Load<Sprite>("Circle");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.blue;
                    enemyShooting.damage = 48;
                    enemyShooting.delay = 0.8f;
                    Debug.Log("Sprite Circle chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite Circle n'a pas été trouvé dans les ressources.");
                }
            }
            else
            {
                Debug.Log("Pas de SetSprite");
            }
        }else if (age == 4)
        {
            if (type == 1)
            {
                Debug.Log("SetSprite 1");
                Sprite newSprite = Resources.Load<Sprite>("HexagonFlat");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.yellow;
                    enemyShooting.damage = 135;
                    enemyShooting.delay = 1.2f;
                    Debug.Log("Sprite HexagonFlat chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite HexagonFlat n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 2)
            {
                Debug.Log("SetSprite 2");
                Sprite newSprite = Resources.Load<Sprite>("IsometricDiamond");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.yellow;
                    enemyShooting.damage = 100;
                    enemyShooting.delay = 0.3f;
                    Debug.Log("Sprite IsometricDiamond chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite IsometricDiamond n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 3)
            {
                Debug.Log("SetSprite 3");
                Sprite newSprite = Resources.Load<Sprite>("Circle");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.yellow;
                    enemyShooting.damage = 75;
                    enemyShooting.delay = 0.8f;
                    Debug.Log("Sprite Circle chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite Circle n'a pas été trouvé dans les ressources.");
                }
            }
            else
            {
                Debug.Log("Pas de SetSprite");
            }
        }else if (age == 5)
        {
            if (type == 1)
            {
                Debug.Log("SetSprite 1");
                Sprite newSprite = Resources.Load<Sprite>("HexagonFlat");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.green;
                    enemyShooting.damage = 200;
                    enemyShooting.delay = 1.2f;
                    Debug.Log("Sprite HexagonFlat chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite HexagonFlat n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 2)
            {
                Debug.Log("SetSprite 2");
                Sprite newSprite = Resources.Load<Sprite>("IsometricDiamond");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.green;
                    enemyShooting.damage = 150;
                    enemyShooting.delay = 0.3f;
                    Debug.Log("Sprite IsometricDiamond chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite IsometricDiamond n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 3)
            {
                Debug.Log("SetSprite 3");
                Sprite newSprite = Resources.Load<Sprite>("Circle");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.green;
                    enemyShooting.damage = 100;
                    enemyShooting.delay = 0.8f;
                    Debug.Log("Sprite Circle chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite Circle n'a pas été trouvé dans les ressources.");
                }
            }
            else
            {
                Debug.Log("Pas de SetSprite");
            }
        }else if (age == 6)
        {
            if (type == 1)
            {
                Debug.Log("SetSprite 1");
                Sprite newSprite = Resources.Load<Sprite>("HexagonFlat");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.cyan;
                    enemyShooting.damage = 300;
                    enemyShooting.delay = 1.2f;
                    Debug.Log("Sprite HexagonFlat chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite HexagonFlat n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 2)
            {
                Debug.Log("SetSprite 2");
                Sprite newSprite = Resources.Load<Sprite>("IsometricDiamond");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.cyan;
                    enemyShooting.damage = 225;
                    enemyShooting.delay = 0.3f;
                    Debug.Log("Sprite IsometricDiamond chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite IsometricDiamond n'a pas été trouvé dans les ressources.");
                }
            }
            else if (type == 3)
            {
                Debug.Log("SetSprite 3");
                Sprite newSprite = Resources.Load<Sprite>("Circle");
                if (newSprite != null)
                {
                    spriteRenderer.sprite = newSprite;
                    spriteRenderer.color = Color.cyan;
                    enemyShooting.damage = 155;
                    enemyShooting.delay = 0.8f;
                    Debug.Log("Sprite Circle chargé avec succès.");
                }
                else
                {
                    Debug.LogError("Le sprite Circle n'a pas été trouvé dans les ressources.");
                }
            }
            else
            {
                Debug.Log("Pas de SetSprite");
            }
        }
    }
}
