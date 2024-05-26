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

    public GameObject objectToInstantiate;
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

    public void PlaceTurret(int placement, int id, int type)
    {
        if (type == 0)
        {
            type = _typeChoice;
        }
        else
        {
            Debug.Log("Type Turret: " + type);
        }
        if (id == 1 && nbPlacementId1 >= nbTowerId1)
        {
            if (type == 1 && castle1.player.GetMoney() >= _turret1Costs[castle1.player.GetAge() - 1])
            {
                nbTowerId1 += 1;
                castle1.player.AddMoney(-_turret1Costs[castle1.player.GetAge() - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 1", castle1.player.GetAge(), type, placement, castle1.id);
                script.SetPosition(castle1.id);
                script.Setup();
                nbTowerId1++;
                if (listTurretId1[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurretId1[placement - 1] = newObject;
                    castle1.player.AddMoney(200);
                }
            }
            else if (type == 2 && castle1.player.GetMoney() >= _turret2Costs[castle1.player.GetAge() - 1])
            {
                nbTowerId1 += 1;
                castle1.player.AddMoney(-_turret2Costs[castle1.player.GetAge() - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 2", castle1.player.GetAge(), type, placement, castle1.id);
                script.SetPosition(castle1.id);
                script.Setup();
                if (listTurretId1[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurretId1[placement - 1] = newObject;
                    castle1.player.AddMoney(200);
                }
            }
            else if (type == 3 && castle1.player.GetMoney() >= _turret3Costs[castle1.player.GetAge() - 1])
            {
                nbTowerId1 += 1;
                castle1.player.AddMoney(-_turret3Costs[castle1.player.GetAge() - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 3", castle1.player.GetAge(), type, placement, castle1.id);
                script.SetPosition(castle1.id);
                script.Setup();
                if (listTurretId1[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurretId1[placement - 1] = newObject;
                    castle1.player.AddMoney(200);
                }
            }
        }
        else if (id == 2 && nbPlacementId2 >= nbTowerId2)
        {
            if (type == 1 && castle2.player.GetMoney() >= _turret1Costs[castle2.player.GetAge() - 1])
            {
                nbTowerId2 += 1;
                castle2.player.AddMoney(-_turret1Costs[castle2.player.GetAge() - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 1", castle2.player.GetAge(), type, placement, castle2.id);
                script.SetPosition(castle2.id);
                script.Setup();
                if (listTurretId2[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurretId2[placement - 1] = newObject;
                    castle2.player.AddMoney(200);
                }
            }
            else if(type == 2 && castle2.player.GetMoney() >= _turret2Costs[castle2.player.GetAge() - 1])
            {
                nbTowerId2 += 1;
                castle2.player.AddMoney(-_turret2Costs[castle2.player.GetAge() - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 2", castle2.player.GetAge(), type, placement, castle2.id);
                script.SetPosition(castle2.id);
                script.Setup();
                if (listTurretId2[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurretId2[placement - 1] = newObject;
                    castle2.player.AddMoney(200);
                }
            }
            else if (type == 3 && castle2.player.GetMoney() >= _turret3Costs[castle2.player.GetAge() - 1])
            {
                nbTowerId2 += 1;
                castle2.player.AddMoney(-_turret3Costs[castle2.player.GetAge() - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 3", castle2.player.GetAge(), type, placement, castle2.id);
                script.SetPosition(castle2.id);
                script.Setup();
                if (listTurretId2[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurretId2[placement - 1] = newObject;
                    castle2.player.AddMoney(200);
                }
            }
        }
    }
}
