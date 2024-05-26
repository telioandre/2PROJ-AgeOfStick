using UnityEngine;

public class Turret : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private EnemyShooting _enemyShooting;

    public string name1 = "none";
    public int age = 1;
    public int type;
    public int placement;
    public int idTurret;


    // Constructeur de la classe
    public void Initialize(string nameTurret, int ageTurret, int typeTurret, int placementTurret, int id)
    {
        name1 = nameTurret;
        age = ageTurret;
        type = typeTurret;
        placement = placementTurret;
        idTurret = id;
        // Obtenez le composant SpriteRenderer
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyShooting = GetComponent<EnemyShooting>();
        // Assurez-vous que le composant SpriteRenderer existe
        if (_spriteRenderer == null)
        {
            // Si le SpriteRenderer n'est pas trouvé sur cet objet, ajoutez-le
            _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
    }

    public int GetIdTurret()
    {
        return idTurret;
    }

    public void SetPosition(int id)
    {
        if (id == 1)
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
        }else if (id == 2)
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
                    _spriteRenderer.sprite = newSprite;
                    _enemyShooting.damage = 40;
                    _enemyShooting.delay = 1.2f;
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
                    _spriteRenderer.sprite = newSprite;
                    _enemyShooting.damage = 30;
                    _enemyShooting.delay = 0.3f;
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
                    _spriteRenderer.sprite = newSprite;
                    _enemyShooting.damage = 20;
                    _enemyShooting.delay = 0.8f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.red;
                    _enemyShooting.damage = 60;
                    _enemyShooting.delay = 1.2f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.red;
                    _enemyShooting.damage = 45;
                    _enemyShooting.delay = 0.3f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.red;
                    _enemyShooting.damage = 30;
                    _enemyShooting.delay = 0.8f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.blue;
                    _enemyShooting.damage = 85;
                    _enemyShooting.delay = 1.2f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.blue;
                    _enemyShooting.damage = 67;
                    _enemyShooting.delay = 0.3f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.blue;
                    _enemyShooting.damage = 48;
                    _enemyShooting.delay = 0.8f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.yellow;
                    _enemyShooting.damage = 135;
                    _enemyShooting.delay = 1.2f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.yellow;
                    _enemyShooting.damage = 100;
                    _enemyShooting.delay = 0.3f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.yellow;
                    _enemyShooting.damage = 75;
                    _enemyShooting.delay = 0.8f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.green;
                    _enemyShooting.damage = 200;
                    _enemyShooting.delay = 1.2f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.green;
                    _enemyShooting.damage = 150;
                    _enemyShooting.delay = 0.3f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.green;
                    _enemyShooting.damage = 100;
                    _enemyShooting.delay = 0.8f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.cyan;
                    _enemyShooting.damage = 300;
                    _enemyShooting.delay = 1.2f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.cyan;
                    _enemyShooting.damage = 225;
                    _enemyShooting.delay = 0.3f;
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
                    _spriteRenderer.sprite = newSprite;
                    _spriteRenderer.color = Color.cyan;
                    _enemyShooting.damage = 155;
                    _enemyShooting.delay = 0.8f;
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
