using System.Collections.Generic;
using UnityEngine;

public class Archi : MonoBehaviour
{
    public int nbPlacementId1;
    public int nbTowerId1;
    public Castle castle1;
    public List<GameObject> listTurretId1 = new();
    public SpriteRenderer spriteRenderer1Id1;
    public SpriteRenderer spriteRenderer2Id1;
    public SpriteRenderer spriteRenderer3Id1;
    public SpriteRenderer spriteRenderer4Id1;
    public Collider2D collider2D1Id1;
    public Collider2D collider2D2Id1;
    public Collider2D collider2D3Id1;
    public Collider2D collider2D4Id1;

    public int nbPlacementId2;
    public int nbTowerId2;
    public Castle castle2;
    public List<GameObject> listTurretId2 = new();
    public SpriteRenderer spriteRenderer1Id2;
    public SpriteRenderer spriteRenderer2Id2;
    public SpriteRenderer spriteRenderer3Id2;
    public SpriteRenderer spriteRenderer4Id2;
    public Collider2D collider2D1Id2;
    public Collider2D collider2D2Id2;
    public Collider2D collider2D3Id2;
    public Collider2D collider2D4Id2;

    private GameObject _objectToInstantiate;

    public GameObject turretType1Age1;
    public GameObject turretType2Age1;
    public GameObject turretType3Age1;

    public GameObject turretType1Age2;
    public GameObject turretType2Age2;
    public GameObject turretType3Age2;

    public GameObject turretType1Age3;
    public GameObject turretType2Age3;
    public GameObject turretType3Age3;

    public GameObject turretType1Age4;
    public GameObject turretType2Age4;
    public GameObject turretType3Age4;

    public GameObject turretType1Age5;
    public GameObject turretType2Age5;
    public GameObject turretType3Age5;

    public GameObject turretType1Age6;
    public GameObject turretType2Age6;
    public GameObject turretType3Age6;

    private int _typeChoice;
    public int delete;

    public List<int> spotCosts = new()
    {
        20, 50, 120, 200
    };

    public List<int> turret1Costs = new()
    {
        25, 150, 300, 400, 500, 600
    };
    public List<int> turret2Costs = new()
    {
        50, 200, 300, 400, 500, 600
    };
    public List<int> turret3Costs = new()
    {
        75, 200, 300, 400, 500, 600
    };
    public void SwitchToEnabled(int id)
    {
        if(id == 1)
        {
            if (nbPlacementId1 == 1)
            { 
                Debug.Log("id: " + id);
                spriteRenderer1Id1.enabled = !spriteRenderer1Id1.enabled;

                collider2D1Id1.enabled = !collider2D1Id1.enabled;
            }
            else if (nbPlacementId1 == 2)
            {
                spriteRenderer1Id1.enabled = !spriteRenderer1Id1.enabled;
                spriteRenderer2Id1.enabled = !spriteRenderer2Id1.enabled;

                collider2D1Id1.enabled = !collider2D1Id1.enabled;
                collider2D2Id1.enabled = !collider2D2Id1.enabled;
            }
            else if (nbPlacementId1 == 3)
            {
                spriteRenderer1Id1.enabled = !spriteRenderer1Id1.enabled;
                spriteRenderer2Id1.enabled = !spriteRenderer2Id1.enabled;
                spriteRenderer3Id1.enabled = !spriteRenderer3Id1.enabled;

                collider2D1Id1.enabled = !collider2D1Id1.enabled;
                collider2D2Id1.enabled = !collider2D2Id1.enabled;
                collider2D3Id1.enabled = !collider2D3Id1.enabled;
            }
            else if (nbPlacementId1 == 4)
            {
                spriteRenderer1Id1.enabled = !spriteRenderer1Id1.enabled;
                spriteRenderer2Id1.enabled = !spriteRenderer2Id1.enabled;
                spriteRenderer3Id1.enabled = !spriteRenderer3Id1.enabled;
                spriteRenderer4Id1.enabled = !spriteRenderer4Id1.enabled;

                collider2D1Id1.enabled = !collider2D1Id1.enabled;
                collider2D2Id1.enabled = !collider2D2Id1.enabled;
                collider2D3Id1.enabled = !collider2D3Id1.enabled;
                collider2D4Id1.enabled = !collider2D4Id1.enabled;
            }
        }else if(id == 2)
        {
            if (nbPlacementId2 == 1)
            {
                spriteRenderer1Id2.enabled = !spriteRenderer1Id2.enabled;

                collider2D1Id2.enabled = !collider2D1Id2.enabled;
            }
            else if (nbPlacementId2 == 2)
            {
                spriteRenderer1Id2.enabled = !spriteRenderer1Id2.enabled;
                spriteRenderer2Id2.enabled = !spriteRenderer2Id2.enabled;

                collider2D1Id2.enabled = !collider2D1Id2.enabled;
                collider2D2Id2.enabled = !collider2D2Id2.enabled;
            }
            else if (nbPlacementId2 == 3)
            {
                spriteRenderer1Id2.enabled = !spriteRenderer1Id2.enabled;
                spriteRenderer2Id2.enabled = !spriteRenderer2Id2.enabled;
                spriteRenderer3Id2.enabled = !spriteRenderer3Id2.enabled;

                collider2D1Id2.enabled = !collider2D1Id2.enabled;
                collider2D2Id2.enabled = !collider2D2Id2.enabled;
                collider2D3Id2.enabled = !collider2D3Id2.enabled;
            }
            else if (nbPlacementId2 == 4)
            {
                spriteRenderer1Id2.enabled = !spriteRenderer1Id2.enabled;
                spriteRenderer2Id2.enabled = !spriteRenderer2Id2.enabled;
                spriteRenderer3Id2.enabled = !spriteRenderer3Id2.enabled;
                spriteRenderer4Id2.enabled = !spriteRenderer4Id2.enabled;

                collider2D1Id2.enabled = !collider2D1Id2.enabled;
                collider2D2Id2.enabled = !collider2D2Id2.enabled;
                collider2D3Id2.enabled = !collider2D3Id2.enabled;
                collider2D4Id2.enabled = !collider2D4Id2.enabled;
            }
        }
        
    }

    public void BuySpot(int id)
    {
        if (id == 1 && nbPlacementId1 < 4 && castle1.player.GetMoney() >= spotCosts[nbPlacementId1])
        {
            castle1.player.AddMoney(-spotCosts[nbPlacementId1]);
            nbPlacementId1 += 1;
        }
        else if(id == 2 && nbPlacementId2 < 4 && castle2.player.GetMoney() >= spotCosts[nbPlacementId2])
        {
            castle2.player.AddMoney(-spotCosts[nbPlacementId2]);
            nbPlacementId2 += 1;
        }
    }
    public void SellSpot(int placement, int id)
    {
        if (id == 1)
        {
            if (listTurretId1[placement - 1] != null)
            {
                Destroy(listTurretId1[placement - 1]);
                listTurretId1[placement - 1] = null;
                nbTowerId1 -= 1;
            }
        }
        else
        {
            if (listTurretId2[placement - 1] != null)
            {
                Destroy(listTurretId2[placement - 1]);
                listTurretId2[placement - 1] = null;
                nbTowerId2 -= 1;
            }
        }
    }

    public int ChoiceType(int type) => _typeChoice = type;

    public void PlaceTurret(int placement, int id, int turret)
    {
        if (turret != 0)
        {
            _typeChoice = turret;
        }
        if (id == 1)
        {
            if (castle1 == null)
            {
                Debug.LogError("castle1 is null in PlaceTurret");
                return;
            }
            if (nbPlacementId1 >= nbTowerId1)
            {
                HandleTurretPlacement(_typeChoice, placement, castle1, ref nbTowerId1, listTurretId1, id);
            }
            else
            {
                Debug.LogError("Invalid placement or max placements reached for ID 1");
            }
        }
        else if (id == 2)
        {
            if (castle2 == null)
            {
                Debug.LogError("castle2 is null in PlaceTurret");
                return;
            }
            if (nbPlacementId2 >= nbTowerId2)
            {
                HandleTurretPlacement(_typeChoice, placement, castle2, ref nbTowerId2, listTurretId2, id);
            }
            else
            {
                Debug.LogError("Invalid placement or max placements reached for ID 2");
            }
        }
        else
        {
            Debug.LogError("Invalid id");
        }
    }


    private void HandleTurretPlacement(int type, int placement, Castle castle, ref int nbTowerId, List<GameObject> listTurretId, int id)
    {
        if (castle == null)
        {
            Debug.LogError("Castle is null in HandleTurretPlacement");
            return;
        }
        if (castle.player == null)
        {
            Debug.LogError("Player is null in HandleTurretPlacement");
            return;
        }
        if (listTurretId == null)
        {
            Debug.LogError("listTurretId is null in HandleTurretPlacement");
            return;
        }
        if (listTurretId.Count <= placement - 1)
        {
            Debug.LogError("listTurretId does not have enough elements");
            return;
        }

        int age = castle.player.GetAge();
        int cost = 0;

        switch (type)
        {
            case 1:
                cost = turret1Costs[age - 1];
                break;
            case 2:
                cost = turret2Costs[age - 1];
                break;
            case 3:
                cost = turret3Costs[age - 1];
                break;
            default:
                Debug.LogError("Invalid turret type");
                return;
        }

        if (castle.player.GetMoney() >= cost)
        {
            castle.player.AddMoney(-cost);
            nbTowerId += 1;

            switch (age)
            {
                case 1:
                    _objectToInstantiate = type == 1 ? turretType1Age1 : type == 2 ? turretType2Age1 : turretType3Age1;
                    break;
                case 2:
                    _objectToInstantiate = type == 1 ? turretType1Age2 : type == 2 ? turretType2Age2 : turretType3Age2;
                    break;
                case 3:
                    _objectToInstantiate = type == 1 ? turretType1Age3 : type == 2 ? turretType2Age3 : turretType3Age3;
                    break;
                case 4:
                    _objectToInstantiate = type == 1 ? turretType1Age4 : type == 2 ? turretType2Age4 : turretType3Age4;
                    break;
                case 5:
                    _objectToInstantiate = type == 1 ? turretType1Age5 : type == 2 ? turretType2Age5 : turretType3Age5;
                    break;
                case 6:
                    _objectToInstantiate = type == 1 ? turretType1Age6 : type == 2 ? turretType2Age6 : turretType3Age6;
                    break;
                default:
                    Debug.LogError("Invalid age");
                    return;
            }

            if (_objectToInstantiate == null)
            {
                Debug.LogError("objectToInstantiate is null");
                return;
            }

            GameObject newObject = Instantiate(_objectToInstantiate, transform.position, Quaternion.identity);
            Turret script = newObject.GetComponent<Turret>();
            if (script == null)
            {
                Debug.LogError("Turret script is missing on instantiated object");
                return;
            }
            script.Initialize(placement, castle.id);
            script.SetPosition(castle.id);

            if (listTurretId[placement - 1] != newObject)
            {
                SellSpot(placement, id);
                listTurretId[placement - 1] = newObject;
                castle.player.AddMoney(cost / 2);
            }
        }
        else
        {
            Debug.Log("Not enough money to place turret");
        }
    }

}
