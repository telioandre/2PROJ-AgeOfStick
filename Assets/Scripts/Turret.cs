using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public string name1 = "none";
    public string age = "none";
    public int type;
    public int placement;
    public int IdTurret;
    public Castle _castle;

    private List<int> _turret1Costs = new()
    {
        100, 150, 300, 400, 500, 600
    };
    private List<int> _turret2Costs = new()
    {
        100, 200, 300, 400, 500, 600
    };
    private List<int> _turret3Costs = new()
    {
        100, 200, 300, 400, 500, 600
    };

    // Constructeur de la classe
    public void Initialize(string nameTurret, string ageTurret, int typeTurret, int placementTurret, int ID, Castle castle)
    {
        name1 = nameTurret;
        age = ageTurret;
        type = typeTurret;
        placement = placementTurret;
        IdTurret = ID;
        _castle = castle;
        // Obtenez le composant SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
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
                transform.position = new Vector3(6218, 630, 238);
                transform.localScale = new Vector3(60, 60, 5);
            }
            else if (placement == 2)
            {
                transform.position = new Vector3(6218, 715, 238);
                transform.localScale = new Vector3(60, 60, 5);
            }
            else if (placement == 3)
            {
                transform.position = new Vector3(6218, 801, 238);
                transform.localScale = new Vector3(60, 60, 5);
            }
            else if (placement == 4)
            {
                transform.position = new Vector3(6218, 888, 238);
                transform.localScale = new Vector3(60, 60, 5);
            }
        }
        
    }
    public void SetSprite()
    {
        if (type == 1 && _castle.player.money >= _turret1Costs[_castle.player.age-1])
        {
            _castle.player.AddMoney(-_turret1Costs[_castle.player.age-1]);
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
        else if (type == 2 && _castle.player.money >= _turret2Costs[_castle.player.age-1])
        {
            _castle.player.AddMoney(-_turret2Costs[_castle.player.age-1]);
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
        else if (type == 3 && _castle.player.money >= _turret3Costs[_castle.player.age-1])
        {
            _castle.player.AddMoney(-_turret3Costs[_castle.player.age-1]);
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
