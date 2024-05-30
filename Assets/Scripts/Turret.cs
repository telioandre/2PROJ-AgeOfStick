using Unity.VisualScripting;
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
    public void Initialize(int placementTurret, int id)
    {
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
            }
            else if(placement == 2){
                transform.position = new Vector3(138, 775, 239);
            }
            else if (placement == 3)
            {
                transform.position = new Vector3(138, 861, 239);
            }
            else if (placement == 4)
            {
                transform.position = new Vector3(138, 948, 239);
            }
        }
        else if (id == 2)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            if (placement == 1)
            {
                transform.position = new Vector3(4751, 690, 238);
            }
            else if (placement == 2)
            {
                transform.position = new Vector3(4751, 773, 238);
            }
            else if (placement == 3)
            {
                transform.position = new Vector3(4751, 860, 238);
            }
            else if (placement == 4)
            {
                transform.position = new Vector3(4751, 946, 238);
            }
        }
        
    }
}
