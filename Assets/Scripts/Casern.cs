using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casern : MonoBehaviour
{
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
    private float cooldown = 1f;
    private float lastPlayer1Invoque;
    private float lastPlayer2Invoque;

    //public int numberOfTroop1 = 0;
    //public int numberOfTroop2 = 0;
    public List<GameObject> troops = new List<GameObject>();
    public IA IA;

    private List<int> troop1costs;
    private List<int> troop2costs;
    private List<int> troop3costs;
    private List<int> troop4costs;

    void Start()
    {
        lastPlayer1Invoque = -cooldown;
        lastPlayer2Invoque = -cooldown;

        troop1costs = new List<int>() { 2, 7, 12, 25, 60, 150 };
        troop2costs = new List<int>() { 1, 5, 9, 20, 55, 110 };
        troop3costs = new List<int>() { 7, 11, 22, 49, 95, 172 };
        troop4costs = new List<int>() { 9, 20, 41, 100, 200, 300 };
    }

    public void InstantiateTroop(int value)
    {
        bool isValid = false;
        int id = value / 10;
        int troop = value % 10;
        switch (id)
        {
            case 1:
                if (player.numberOfTroop < 10 && Time.time - lastPlayer1Invoque > cooldown)
                {
                    lastPlayer1Invoque = Time.time;
                    switch (troop)
                    {
                        case 1:
                            cost = troop1costs[player.age - 1];
                            if (player.GetMoney() >= cost)
                            {
                                troopToInstantiate = objectToInstantiate;
                                isValid = true;
                            }
                            break;

                        case 2:
                            cost = troop2costs[player.age - 1];
                            if (player.GetMoney() >= cost)
                            {
                                troopToInstantiate = objectToInstantiate2;
                                isValid = true;
                            }
                            break;

                        case 3:
                            cost = troop3costs[player.age - 1];
                            if (player.GetMoney() >= cost)
                            {
                                troopToInstantiate = objectToInstantiate3;
                                isValid = true;
                            }
                            break;

                        case 4:
                            cost = troop4costs[player.age - 1];
                            if (player.GetMoney() >= cost)
                            {
                                troopToInstantiate = objectToInstantiate4;
                                isValid = true;
                            }
                            break;
                    }
                }

                break;
            case 2:
                if (opponent.numberOfTroop < 10 && Time.time - lastPlayer2Invoque > cooldown)
                {
                    lastPlayer2Invoque = Time.time;
                    switch (troop)
                    {

                        case 1:
                            cost = troop1costs[player.age - 1];
                            if (opponent.GetMoney() >= cost)
                            {
                                troopToInstantiate = objectToInstantiate5;
                                isValid = true;
                            }
                            break;

                        case 2:
                            cost = troop2costs[player.age - 1];
                            if (opponent.GetMoney() >= cost)
                            {
                                troopToInstantiate = objectToInstantiate6;
                                isValid = true;
                            }
                            break;

                        case 3:
                            cost = troop3costs[player.age - 1];
                            if (opponent.GetMoney() >= cost)
                            {
                                troopToInstantiate = objectToInstantiate7;
                                isValid = true;
                            }
                            break;

                        case 4:
                            cost = troop4costs[player.age - 1];
                            if (opponent.GetMoney() >= cost)
                            {
                                troopToInstantiate = objectToInstantiate8;
                                isValid = true;
                            }
                            break;
                    }
                }
                break;
        }
        if (isValid)
        {
            CreateTroop(id, troopToInstantiate);
        }
    }

    public void CreateTroop(int id, GameObject troopToCreate)
    {
        GameObject newObject = Instantiate(troopToCreate, transform.position, Quaternion.identity);
        if (id == 1)
        {
            player.numberOfTroop += 1;
            troops.Add(newObject);
            player.AddMoney(-cost);
        }
        else
        {
            opponent.numberOfTroop += 1;
            opponent.AddMoney(-cost);
        }
        Movement script = newObject.GetComponent<Movement>();
        script.setPlayer(id);
    }

    public void DestroyTroop(int id)
    {
        if (id == 1)
        {
            player.numberOfTroop -= 1;
        }
        else
        {
            opponent.numberOfTroop -= 1;
        }
    }
}