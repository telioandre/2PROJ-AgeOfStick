using System.Collections.Generic;
using Unity.VisualScripting;
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

    private GameObject objectToInstantiate;

    public GameObject TurretType1Age1;
    public GameObject TurretType2Age1;
    public GameObject TurretType3Age1;

    public GameObject TurretType1Age2;
    public GameObject TurretType2Age2;
    public GameObject TurretType3Age2;

    public GameObject TurretType1Age3;
    public GameObject TurretType2Age3;
    public GameObject TurretType3Age3;

    public GameObject TurretType1Age4;
    public GameObject TurretType2Age4;
    public GameObject TurretType3Age4;

    public GameObject TurretType1Age5;
    public GameObject TurretType2Age5;
    public GameObject TurretType3Age5;

    public GameObject TurretType1Age6;
    public GameObject TurretType2Age6;
    public GameObject TurretType3Age6;

    private int _typeChoice;
    public int delete;

    private List<int> _spotCosts = new()
    {
        20, 50, 120, 200
    };

    private List<int> _turret1Costs = new()
    {
        25, 150, 300, 400, 500, 600
    };
    private List<int> _turret2Costs = new()
    {
        50, 200, 300, 400, 500, 600
    };
    private List<int> _turret3Costs = new()
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
        if (id == 1 && nbPlacementId1 < 4 && castle1.player.GetMoney() >= _spotCosts[nbPlacementId1])
        {
            castle1.player.AddMoney(-_spotCosts[nbPlacementId1]);
            nbPlacementId1 += 1;
        }
        else if(id == 2 && nbPlacementId2 < 4 && castle2.player.GetMoney() >= _spotCosts[nbPlacementId2])
        {
            castle2.player.AddMoney(-_spotCosts[nbPlacementId2]);
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
        if(turret != 0)
        {
            _typeChoice = turret;
        }
        if (id == 1 && nbPlacementId1 >= nbTowerId1)
        {
            HandleTurretPlacement(_typeChoice, placement, castle1, ref nbTowerId1, listTurretId1, id);
        }
        else if (id == 2 && nbPlacementId2 >= nbTowerId2)
        {
            HandleTurretPlacement(_typeChoice, placement, castle2, ref nbTowerId2, listTurretId2, id);
        }
        else
        {
            Debug.LogError("Invalid id or max placements reached");
        }
    }

    private void HandleTurretPlacement(int type, int placement, Castle castle, ref int nbTowerId, List<GameObject> listTurretId, int id)
    {
        int age = castle.player.GetAge();
        int cost = 0;

        switch (type)
        {
            case 1:
                cost = _turret1Costs[age - 1];
                break;
            case 2:
                cost = _turret2Costs[age - 1];
                break;
            case 3:
                cost = _turret3Costs[age - 1];
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
                    objectToInstantiate = type == 1 ? TurretType1Age1 : type == 2 ? TurretType2Age1 : TurretType3Age1;
                    break;
                case 2:
                    objectToInstantiate = type == 1 ? TurretType1Age2 : type == 2 ? TurretType2Age2 : TurretType3Age2;
                    break;
                case 3:
                    objectToInstantiate = type == 1 ? TurretType1Age3 : type == 2 ? TurretType2Age3 : TurretType3Age3;
                    break;
                case 4:
                    objectToInstantiate = type == 1 ? TurretType1Age4 : type == 2 ? TurretType2Age4 : TurretType3Age4;
                    break;
                case 5:
                    objectToInstantiate = type == 1 ? TurretType1Age5 : type == 2 ? TurretType2Age5 : TurretType3Age5;
                    break;
                case 6:
                    objectToInstantiate = type == 1 ? TurretType1Age6 : type == 2 ? TurretType2Age6 : TurretType3Age6;
                    break;
                default:
                    Debug.LogError("Invalid age");
                    return;
            }

            GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
            Turret script = newObject.GetComponent<Turret>();
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
