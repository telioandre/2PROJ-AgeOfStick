using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private EnemyShooting _enemyShooting;

    public int age = 1; // age of the turret
    public int type; // type of the turret
    public int placement; // placement of the turret
    public int idTurret; // id of the player who installed the turret
    public int range; // range of the turret
    public int damage; // damage of the turret


    // Class constructor
    public void Initialize(int placementTurret, int id, int rangeTurret, float damageTurret)
    {
        placement = placementTurret;
        idTurret = id; 
        range = rangeTurret;
        damage = (int)damageTurret;
        _spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer recovery
        _enemyShooting = GetComponent<EnemyShooting>(); // EnemyShooting recovery

        // Make sure the SpriteRenderer component exists
        if (_spriteRenderer == null)
        {
            // If the SpriteRenderer is not found on this object, we add it
            _spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
    }

    public int GetIdTurret()
    {
        return idTurret;
    }

    public int getDamage()
    {
        return damage;
    }

    public int getRange()
    {
        return range;
    }

    public void SetPosition(int id) // This function lets you set turret locations according to their id.
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
            // We reverse the direction of each turret so that it faces the correct direction of play. 
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
