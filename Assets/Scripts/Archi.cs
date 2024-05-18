using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
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
    //public int ID = 1;

    private List<int> _spotCosts = new()
    {
        20, 50, 120, 200
    };
    public void switchToEnabled(int id)
    {
        if(id == 1)
        {
            if (nbPlacement_Id1 == 1)
            {
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
    public void SellSpot(int value)
    {
        int id = value / 10;
        int spot = value % 10;
    }

    public int ChoiceType(int type) => typeChoice = type;

    public void PlaceTurret(int placement, int id, int type)
    {
        if (type == 0)
        {
            type = typeChoice;
        }
        if (id == 1 && nbPlacement_Id1 > nbTowerId1)
        {
            GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
            Turret script = newObject.GetComponent<Turret>();
            script.Initialize("test", castle1.player.age.ToString(), type, placement, castle1.id, castle1);
            script.SetPosition(castle1.id);
            script.SetSprite();
            if (listTurret_Id1[placement - 1] != newObject)
            {
                Destroy(listTurret_Id1[placement - 1]);
                listTurret_Id1[placement-1] = newObject;
                nbTowerId1 += 1;
            }
        }
        else if (id == 2 && nbPlacement_Id2 > nbTowerId2)
        {
            GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
            Turret script = newObject.GetComponent<Turret>();
            script.Initialize("test", castle2.player.age.ToString(), type, placement, castle2.id, castle2);
            script.SetPosition(castle2.id);
            script.SetSprite();
            if (listTurret_Id2[placement - 1] != newObject)
            {
                Destroy(listTurret_Id2[placement - 1]);
                listTurret_Id2[placement-1] = newObject;
                nbTowerId2 += 1;
            }
        }
    }

    /*public void placeTurret(int placement, int id, int type)
    {
        Castle castle;
        //Debug.Log(placement);
        GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        Turret script = newObject.GetComponent<Turret>();
        if (id == 1)
        {
            castle = castle1;
        }
        else
        {
            castle = castle2;
        }
        if (type == 0)
        {
            type = typeChoice;
        }
        script.Initialize("test", "test", type, placement, castle.id, castle);
        script.SetPosition(castle.id);
        script.SetSprite();
        if (listTurret_Id1[placement - 1] != newObject && castle.id == 1 && nbPlacement_Id1 > nbTowerId1)
        {
            Destroy(listTurret_Id1[placement - 1]);
            //Debug.Log(placement);
            listTurret_Id1[placement-1] = newObject;
            nbTowerId1 += 1;

        }else if (listTurret_Id2[placement - 1] != newObject && castle.id == 2 && nbPlacement_Id2 > nbTowerId2)
        {
            Destroy(listTurret_Id2[placement - 1]);
            //Debug.Log(placement);
            listTurret_Id2[placement - 1] = newObject;
            nbTowerId2 += 1;

        }
    }*/
}
