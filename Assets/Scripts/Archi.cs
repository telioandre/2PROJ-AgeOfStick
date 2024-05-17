using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Archi : MonoBehaviour
{
    public int nbPlacement_Id1 = 1;
    [SerializeField]
    public List<GameObject> listTurret_Id1 = new List<GameObject>();
    public SpriteRenderer spriteRenderer1_Id1;
    public SpriteRenderer spriteRenderer2_Id1;
    public SpriteRenderer spriteRenderer3_Id1;
    public SpriteRenderer spriteRenderer4_Id1;
    public Collider2D collider2D_1_Id1;
    public Collider2D collider2D_2_Id1;
    public Collider2D collider2D_3_Id1;
    public Collider2D collider2D_4_Id1;

    public int nbPlacement_Id2 = 1;
    public List<GameObject> listTurret_Id2 = new List<GameObject>();
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
    public int ID = 1;
    public void switchToEnabled()
    {
        if(ID == 1)
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
        }else if(ID == 2)
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

    public int ChoiceType(int type) => typeChoice = type;

    public void placeTurret(int placement)
    {
        Debug.Log(placement);
        GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        Turret script = newObject.GetComponent<Turret>();
        script.Initialize("test", "test", typeChoice, placement, ID);
        script.SetPosition(ID);
        script.SetSprite();
        if (listTurret_Id1[placement - 1] != newObject)
        {
            Destroy(listTurret_Id1[placement - 1]);
            Debug.Log(placement);
            listTurret_Id1[placement-1] = newObject;

        }else if (listTurret_Id2[placement - 1] != newObject)
        {
            Destroy(listTurret_Id2[placement - 1]);
            Debug.Log(placement);
            listTurret_Id2[placement - 1] = newObject;
        }
    }
}
