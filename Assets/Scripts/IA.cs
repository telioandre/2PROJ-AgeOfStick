using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Player player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public Casern casern;

    private System.Random random = new System.Random();
    private float timer = 0f;
    private float interval = 3f;
    private int randomNumber = 0;
    private int IATroops = 0;
    void GenerateRandomNumber()
    {
        randomNumber = random.Next(1, 4);
        //Debug.Log("Nombre aléatoire : " + randomNumber);
        IaSpecialAttack();
    }

    private void Start()
    {
        casern = FindObjectOfType<Casern>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Debug.Log(casern.troops.Count);
            if(casern.troops.Count > 0)
            {
                Debug.Log("liste avec un truc");
                if (casern.troops[0].name == "Troop 1 ally(Clone)")
                {
                    Debug.Log("c'est un miracle");
                }
                else
                {
                    Debug.Log("ntm mdrrr");
                }
            }
            else
            {
                Debug.Log("liste avec rien");
            }
                /*GameObject newObject = Instantiate(enemy1, transform.position, Quaternion.identity);
                if (newObject != null)
                {
                    Movement script = newObject.GetComponent<Movement>();
                    if (script != null)
                    {
                        IATroops += 1;
                        //Debug.Log(IATroops);
                        script.setPlayer(2);
                    }
                    else
                    {
                        Debug.LogError("Movement script not found on the instantiated object");
                    }
                }
                else
                {
                    Debug.LogError("Failed to instantiate enemy1");
                }*/
                timer = 0f;
            GenerateRandomNumber();
        }
    }

    void IaSpecialAttack()
    {
        if (randomNumber == 1)
        {
            //Debug.Log(" IAttaque spéciale");
            player.SpecialAttack(2);
        }
    }
}
