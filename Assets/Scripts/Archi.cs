using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Archi : MonoBehaviour
{
    [SerializeField]
    //private List<Turret> listTurret = new List<Turret>();
    public List<GameObject> listTurret = new List<GameObject>();
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;
    public GameObject objectToInstantiate;
    private int typeChoice;

    public void switchToEnabled()
    {
        spriteRenderer1.enabled = !spriteRenderer1.enabled;
        spriteRenderer2.enabled = !spriteRenderer2.enabled;
        spriteRenderer3.enabled = !spriteRenderer3.enabled;
    }

    public int ChoiceType(int type) => typeChoice = type;

    public void placeTurret(int placement)
    {
        Debug.Log(placement);
        GameObject newObject = Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        Turret script = newObject.GetComponent<Turret>();
        script.Initialize("test", "test", typeChoice, placement);
        script.SetPosition();
        script.SetSprite();
        if (listTurret[placement - 1] != newObject)
        {
            Destroy(listTurret[placement - 1]);
            Debug.Log(placement);
            listTurret[placement-1] = newObject;
        }
        
    }
}
