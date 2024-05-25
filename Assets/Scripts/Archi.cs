using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Archi : MonoBehaviour
{
    public int nbPlacement_Id1;
    public int nbTowerId1;
    public Castle castle1;
    [SerializeField]
    public List<GameObject> listTurret_Id1 = new();
    public SpriteRenderer spriteRenderer1_Id1;
    public SpriteRenderer spriteRenderer2_Id1;
    public SpriteRenderer spriteRenderer3_Id1;
    public SpriteRenderer spriteRenderer4_Id1;
    public Collider2D collider2D_1_Id1;
    public Collider2D collider2D_2_Id1;
    public Collider2D collider2D_3_Id1;
    public Collider2D collider2D_4_Id1;

    public int nbPlacement_Id2;
    public int nbTowerId2;
    public Castle castle2;
    public List<GameObject> listTurret_Id2 = new();
    public SpriteRenderer spriteRenderer1_Id2;
    public SpriteRenderer spriteRenderer2_Id2;
    public SpriteRenderer spriteRenderer3_Id2;
    public SpriteRenderer spriteRenderer4_Id2;
    public Collider2D collider2D_1_Id2;
    public Collider2D collider2D_2_Id2;
    public Collider2D collider2D_3_Id2;
    public Collider2D collider2D_4_Id2;

    public GameObject objectToInstantiate;
    private int typeChoice;
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
    public void switchToEnabled(int id)
    {
        if(id == 1)
        {
            if (nbPlacement_Id1 == 1)
            { 
                Debug.Log("id: " + id);
                spriteRenderer1_Id1.enabled = !spriteRenderer1_Id1.enabled;

                collider2D_1_Id1.enabled = !collider2D_1_Id1.enabled;
            }
            else if (nbPlacement_Id1 == 2)
            {
                spriteRenderer1_Id1.enabled = !spriteRenderer1_Id1.enabled;
                spriteRenderer2_Id1.enabled = !spriteRenderer2_Id1.enabled;

                collider2D_1_Id1.enabled = !collider2D_1_Id1.enabled;
                collider2D_2_Id1.enabled = !collider2D_2_Id1.enabled;
            }
            else if (nbPlacement_Id1 == 3)
            {
                spriteRenderer1_Id1.enabled = !spriteRenderer1_Id1.enabled;
                spriteRenderer2_Id1.enabled = !spriteRenderer2_Id1.enabled;
                spriteRenderer3_Id1.enabled = !spriteRenderer3_Id1.enabled;

                collider2D_1_Id1.enabled = !collider2D_1_Id1.enabled;
                collider2D_2_Id1.enabled = !collider2D_2_Id1.enabled;
                collider2D_3_Id1.enabled = !collider2D_3_Id1.enabled;
            }
            else if (nbPlacement_Id1 == 4)
            {
                spriteRenderer1_Id1.enabled = !spriteRenderer1_Id1.enabled;
                spriteRenderer2_Id1.enabled = !spriteRenderer2_Id1.enabled;
                spriteRenderer3_Id1.enabled = !spriteRenderer3_Id1.enabled;
                spriteRenderer4_Id1.enabled = !spriteRenderer4_Id1.enabled;

                collider2D_1_Id1.enabled = !collider2D_1_Id1.enabled;
                collider2D_2_Id1.enabled = !collider2D_2_Id1.enabled;
                collider2D_3_Id1.enabled = !collider2D_3_Id1.enabled;
                collider2D_4_Id1.enabled = !collider2D_4_Id1.enabled;
            }
        }else if(id == 2)
        {
            if (nbPlacement_Id2 == 1)
            {
                spriteRenderer1_Id2.enabled = !spriteRenderer1_Id2.enabled;

                collider2D_1_Id2.enabled = !collider2D_1_Id2.enabled;
            }
            else if (nbPlacement_Id2 == 2)
            {
                spriteRenderer1_Id2.enabled = !spriteRenderer1_Id2.enabled;
                spriteRenderer2_Id2.enabled = !spriteRenderer2_Id2.enabled;

                collider2D_1_Id2.enabled = !collider2D_1_Id2.enabled;
                collider2D_2_Id2.enabled = !collider2D_2_Id2.enabled;
            }
            else if (nbPlacement_Id2 == 3)
            {
                spriteRenderer1_Id2.enabled = !spriteRenderer1_Id2.enabled;
                spriteRenderer2_Id2.enabled = !spriteRenderer2_Id2.enabled;
                spriteRenderer3_Id2.enabled = !spriteRenderer3_Id2.enabled;

                collider2D_1_Id2.enabled = !collider2D_1_Id2.enabled;
                collider2D_2_Id2.enabled = !collider2D_2_Id2.enabled;
                collider2D_3_Id2.enabled = !collider2D_3_Id2.enabled;
            }
            else if (nbPlacement_Id2 == 4)
            {
                spriteRenderer1_Id2.enabled = !spriteRenderer1_Id2.enabled;
                spriteRenderer2_Id2.enabled = !spriteRenderer2_Id2.enabled;
                spriteRenderer3_Id2.enabled = !spriteRenderer3_Id2.enabled;
                spriteRenderer4_Id2.enabled = !spriteRenderer4_Id2.enabled;

                collider2D_1_Id2.enabled = !collider2D_1_Id2.enabled;
                collider2D_2_Id2.enabled = !collider2D_2_Id2.enabled;
                collider2D_3_Id2.enabled = !collider2D_3_Id2.enabled;
                collider2D_4_Id2.enabled = !collider2D_4_Id2.enabled;
            }
        }
        
    }

    public void BuySpot(int id)
    {
        if (id == 1 && nbPlacement_Id1 < 4 && castle1.player.money >= _spotCosts[nbPlacement_Id1])
        {
            castle1.player.AddMoney(-_spotCosts[nbPlacement_Id1]);
            nbPlacement_Id1 += 1;
        }
        else if(id == 2 && nbPlacement_Id2 < 4 && castle2.player.money >= _spotCosts[nbPlacement_Id2])
        {
            castle2.player.AddMoney(-_spotCosts[nbPlacement_Id2]);
            nbPlacement_Id2 += 1;
        }
    }
    public void SellSpot(int placement, int ID)
    {
        if (ID == 1)
        {
            if (listTurret_Id1[placement - 1] != null)
            {
                Destroy(listTurret_Id1[placement - 1]);
                listTurret_Id1[placement - 1] = null;
                nbTowerId1 -= 1;
            }
        }
        else
        {
            if (listTurret_Id2[placement - 1] != null)
            {
                Destroy(listTurret_Id2[placement - 1]);
                listTurret_Id2[placement - 1] = null;
                nbTowerId2 -= 1;
            }
        }
    }

    public int ChoiceType(int type) => typeChoice = type;

    public void PlaceTurret(int placement, int id, int type)
    {
        if (type == 0)
        {
            type = typeChoice;
        }
        else
        {
            Debug.Log("Type Turret: " + type);
        }
        if (id == 1 && nbPlacement_Id1 >= nbTowerId1)
        {
            if (type == 1 && castle1.player.money >= _turret1Costs[castle1.player.age - 1])
            {
                nbTowerId1 += 1;
                castle1.player.AddMoney(-_turret1Costs[castle1.player.age - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 1", castle1.player.age, type, placement, castle1.id);
                script.SetPosition(castle1.id);
                script.Setup();
                nbTowerId1++;
                if (listTurret_Id1[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurret_Id1[placement - 1] = newObject;
                    castle1.player.AddMoney(200);
                }
            }
            else if (type == 2 && castle1.player.money >= _turret2Costs[castle1.player.age - 1])
            {
                nbTowerId1 += 1;
                castle1.player.AddMoney(-_turret2Costs[castle1.player.age - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 2", castle1.player.age, type, placement, castle1.id);
                script.SetPosition(castle1.id);
                script.Setup();
                if (listTurret_Id1[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurret_Id1[placement - 1] = newObject;
                    castle1.player.AddMoney(200);
                }
            }
            else if (type == 3 && castle1.player.money >= _turret3Costs[castle1.player.age - 1])
            {
                nbTowerId1 += 1;
                castle1.player.AddMoney(-_turret3Costs[castle1.player.age - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 3", castle1.player.age, type, placement, castle1.id);
                script.SetPosition(castle1.id);
                script.Setup();
                if (listTurret_Id1[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurret_Id1[placement - 1] = newObject;
                    castle1.player.AddMoney(200);
                }
            }
        }
        else if (id == 2 && nbPlacement_Id2 >= nbTowerId2)
        {
            if (type == 1 && castle2.player.money >= _turret1Costs[castle2.player.age - 1])
            {
                nbTowerId2 += 1;
                castle2.player.AddMoney(-_turret1Costs[castle2.player.age - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 1", castle2.player.age, type, placement, castle2.id);
                script.SetPosition(castle2.id);
                script.Setup();
                if (listTurret_Id2[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurret_Id2[placement - 1] = newObject;
                    castle2.player.AddMoney(200);
                }
            }
            else if(type == 2 && castle2.player.money >= _turret2Costs[castle2.player.age - 1])
            {
                nbTowerId2 += 1;
                castle2.player.AddMoney(-_turret2Costs[castle2.player.age - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 2", castle2.player.age, type, placement, castle2.id);
                script.SetPosition(castle2.id);
                script.Setup();
                if (listTurret_Id2[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurret_Id2[placement - 1] = newObject;
                    castle2.player.AddMoney(200);
                }
            }
            else if (type == 3 && castle2.player.money >= _turret3Costs[castle2.player.age - 1])
            {
                nbTowerId2 += 1;
                castle2.player.AddMoney(-_turret3Costs[castle2.player.age - 1]);
                GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
                Turret script = newObject.GetComponent<Turret>();
                script.Initialize("Tourelle 3", castle2.player.age, type, placement, castle2.id);
                script.SetPosition(castle2.id);
                script.Setup();
                if (listTurret_Id2[placement - 1] != newObject)
                {
                    SellSpot(placement, id);
                    listTurret_Id2[placement - 1] = newObject;
                    castle2.player.AddMoney(200);
                }
            }
        }
    }
}
