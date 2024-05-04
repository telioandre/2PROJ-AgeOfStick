using System.Collections.Generic;
using UnityEngine;

public class Casern : MonoBehaviour
{
    [SerializeField]
    public Player player;
    public Player opponent;

    public GameObject objectToInstantiate;
    public GameObject objectToInstantiate2;
    public GameObject objectToInstantiate3;
    public GameObject objectToInstantiate4;
    public GameObject objectToInstantiate5;
    public GameObject objectToInstantiate6;
    public GameObject objectToInstantiate7;
    public GameObject objectToInstantiate8;

    private GameObject troopToInstantiate;
    private int cost;

    public int numberOfTroop1 = 0;
    public int numberOfTroop2 = 0;
    public List<GameObject> troops = new List<GameObject>();
    public IA IA;

    private List<int> troop1costs;
    private List<int> troop2costs;
    private List<int> troop3costs;
    private List<int> troop4costs;

    void Start()
    {
        troop1costs = new List<int>() { 2, 7, 12, 25, 60, 150 };
        troop2costs = new List<int>() { 1, 5, 9, 20, 55, 110 };
        troop3costs = new List<int>() { 7, 11, 22, 49, 95, 172 };
        troop4costs = new List<int>() { 9, 20, 41, 100, 200, 300 };
    }

    public void CreateTroop(int value)
    {
        int id = value / 10;
        int troop = value % 10;
        switch(id)
        {
            case 1:
                switch (troop)
                {
                    case 1:
                        cost = troop1costs[player.age - 1];
                        if (numberOfTroop1 < 10 && player.GetMoney() >= cost)
                        {
                            troopToInstantiate = objectToInstantiate;
                        }
                            break;

                    case 2:
                        cost = troop2costs[player.age - 1];
                        if (numberOfTroop1 < 10 && player.GetMoney() >= cost)
                        {
                            troopToInstantiate = objectToInstantiate2;
                        }
                        break;

                    case 3:
                        cost = troop3costs[player.age - 1];
                        if (numberOfTroop1 < 10 && player.GetMoney() >= cost)
                        {
                            troopToInstantiate = objectToInstantiate3;
                        }
                        break;

                    case 4:
                        cost = troop4costs[player.age - 1];
                        if (numberOfTroop1 < 10 && player.GetMoney() >= cost)
                        {
                            troopToInstantiate = objectToInstantiate4;
                        }
                        break;

                }
                break;

            case 2:
                switch (troop)
                {
                    case 1:
                        cost = troop1costs[player.age - 1];
                        if (numberOfTroop1 < 10 && player.GetMoney() >= cost)
                        {
                            troopToInstantiate = objectToInstantiate5;
                        }
                        break;

                    case 2:
                        cost = troop2costs[player.age - 1];
                        if (numberOfTroop1 < 10 && player.GetMoney() >= cost)
                        {
                            troopToInstantiate = objectToInstantiate6;
                        }
                        break;

                    case 3:
                        cost = troop3costs[player.age - 1];
                        if (numberOfTroop1 < 10 && player.GetMoney() >= cost)
                        {
                            troopToInstantiate = objectToInstantiate7;
                        }
                        break;

                    case 4:
                        cost = troop4costs[player.age - 1];
                        if (numberOfTroop1 < 10 && player.GetMoney() >= cost)
                        {
                            troopToInstantiate = objectToInstantiate8;
                        }
                        break;
                }
                break;
        }
        GameObject newObject = Instantiate(troopToInstantiate, transform.position, Quaternion.identity);
        if(id == 1)
        {
            numberOfTroop1 += 1;
            troops.Add(newObject);
            player.AddMoney(-cost);
        }
        else
        {
            numberOfTroop2 += 1;
            opponent.AddMoney(-cost);
        }
        Movement script = newObject.GetComponent<Movement>();
        script.setPlayer(id);
    }

    public void DestroyTroop1()
    {
        numberOfTroop1 -= 1;
        Debug.Log("troop ID 1 : " + numberOfTroop1);
    }
    public void DestroyTroop2()
    {
        numberOfTroop2 -= 1;
        Debug.Log("troop ID 2 : " + numberOfTroop2);
    }
}

