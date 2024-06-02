// This script manages the behavior and properties of turrets in a castle defense game.
// It includes functionality for initializing turret properties, setting turret positions, 
// and ensuring the presence of required components.

using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private EnemyShooting _enemyShooting;

    public int age = 1;
    public int type;
    public int placement;
    public int idTurret;
    public int range;
    public int damage;

    // Class constructor to initialize turret properties
    public void Initialize(int placementTurret, int id, int rangeTurret, float damageTurret)
    {
        placement = placementTurret;
        idTurret = id;
        range = rangeTurret;
        damage = (int)damageTurret;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyShooting = GetComponent<EnemyShooting>();

        // Ensure the SpriteRenderer component exists
        if (_spriteRenderer == null)
        {
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

    // Sets the position of the turret based on its placement and ID
    public void SetPosition(int id)
    {
        if (id == 1)
        {
            switch (placement)
            {
                case 1:
                    transform.position = new Vector3(138, 690, 239);
                    break;
                case 2:
                    transform.position = new Vector3(138, 775, 239);
                    break;
                case 3:
                    transform.position = new Vector3(138, 861, 239);
                    break;
                case 4:
                    transform.position = new Vector3(138, 948, 239);
                    break;
            }
        }
        else if (id == 2)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            switch (placement)
            {
                case 1:
                    transform.position = new Vector3(4751, 690, 238);
                    break;
                case 2:
                    transform.position = new Vector3(4751, 773, 238);
                    break;
                case 3:
                    transform.position = new Vector3(4751, 860, 238);
                    break;
                case 4:
                    transform.position = new Vector3(4751, 946, 238);
                    break;
            }
        }
    }
}