using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Casern : MonoBehaviour
{
    public Castle castle1;
    public Castle castle2;

    public GameObject background;
    public Sprite[] backgroundImages;
    
    public GameObject currentTroop1;
    public GameObject currentTroop2;
    public GameObject currentTroop3;
    public GameObject currentTroop4;
    public GameObject currentTroop5;
    public GameObject currentTroop6;
    public GameObject currentTroop7;
    public GameObject currentTroop8;

    public GameObject age2Troop1;
    public GameObject age2Troop2;
    public GameObject age2Troop3;
    public GameObject age2Troop4;
    public GameObject age2Troop5;
    public GameObject age2Troop6;
    public GameObject age2Troop7;
    public GameObject age2Troop8;

    public GameObject age3Troop1;
    public GameObject age3Troop2;
    public GameObject age3Troop3;
    public GameObject age3Troop4;
    public GameObject age3Troop5;
    public GameObject age3Troop6;
    public GameObject age3Troop7;
    public GameObject age3Troop8;

    public GameObject age4Troop1;
    public GameObject age4Troop2;
    public GameObject age4Troop3;
    public GameObject age4Troop4;
    public GameObject age4Troop5;
    public GameObject age4Troop6;
    public GameObject age4Troop7;
    public GameObject age4Troop8;

    public GameObject age5Troop1;
    public GameObject age5Troop2;
    public GameObject age5Troop3;
    public GameObject age5Troop4;
    public GameObject age5Troop5;
    public GameObject age5Troop6;
    public GameObject age5Troop7;
    public GameObject age5Troop8;

    public GameObject age6Troop1;
    public GameObject age6Troop2;
    public GameObject age6Troop3;
    public GameObject age6Troop4;
    public GameObject age6Troop5;
    public GameObject age6Troop6;
    public GameObject age6Troop7;
    public GameObject age6Troop8;
    public GameObject ultimateTroop;

    private GameObject _troopToInstantiate;
    private int _troopId;
    private int _cost;
    
    public bool isForming1;
    public bool isForming2;
    public List<int> queue1 = new();
    public List<int> queue2 = new();

    public List<GameObject> troopsPlayer1 = new();
    public List<GameObject> troopsPlayer2 = new();

    public List<int> troop1Costs;
    public List<int> troop2Costs;
    public List<int> troop3Costs;
    public List<int> troop4Costs;

    private bool _isOnline;
    void Start()
    {
        troop1Costs = new List<int> { 2, 7, 12, 25, 60, 150 };
        troop2Costs = new List<int> { 1, 5, 9, 20, 55, 110 };
        troop3Costs = new List<int> { 7, 11, 22, 49, 95, 172 };
        troop4Costs = new List<int> { 9, 20, 41, 100, 200, 300 };
    }

    public void setOnline(bool online)
    {
        _isOnline = online;
    }
    private void Update()
    {
        SpriteRenderer spriteRenderer = background.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = backgroundImages[Mathf.Max(castle1.player.GetAge(), castle2.player.GetAge())-1];
        if (!isForming1 && queue1.Count > 0)
        {
            InstantiateTroop(queue1[0]);
            queue1.Remove(queue1[0]);
        }
        if (!isForming2 && queue2.Count > 0)
        {
            InstantiateTroop(queue2[0]);
            queue2.Remove(queue2[0]);
        }
        
        switch (castle1.player.GetAge())
        {
            case 2:
                currentTroop1 = age2Troop1;
                currentTroop2 = age2Troop2;
                currentTroop3 = age2Troop3;
                currentTroop4 = age2Troop4;
                break;
            case 3:
                currentTroop1 = age3Troop1;
                currentTroop2 = age3Troop2;
                currentTroop3 = age3Troop3;
                currentTroop4 = age3Troop4;
                break;
            case 4:
                currentTroop1 = age4Troop1;
                currentTroop2 = age4Troop2;
                currentTroop3 = age4Troop3;
                currentTroop4 = age4Troop4;
                break;
            case 5:
                currentTroop1 = age5Troop1;
                currentTroop2 = age5Troop2;
                currentTroop3 = age5Troop3;
                currentTroop4 = age5Troop4;
                break;
            case 6:
                currentTroop1 = age6Troop1;
                currentTroop2 = age6Troop2;
                currentTroop3 = age6Troop3;
                currentTroop4 = age6Troop4;
                break;
        }
        switch (castle2.player.GetAge())
        {
            case 2:
                currentTroop5 = age2Troop5;
                currentTroop6 = age2Troop6;
                currentTroop7 = age2Troop7;
                currentTroop8 = age2Troop8;
                break;
            case 3:
                currentTroop5 = age3Troop5;
                currentTroop6 = age3Troop6;
                currentTroop7 = age3Troop7;
                currentTroop8 = age3Troop8;
                break;
            case 4:
                currentTroop5 = age4Troop5;
                currentTroop6 = age4Troop6;
                currentTroop7 = age4Troop7;
                currentTroop8 = age4Troop8;
                break;
            case 5:
                currentTroop5 = age5Troop5;
                currentTroop6 = age5Troop6;
                currentTroop7 = age5Troop7;
                currentTroop8 = age5Troop8;
                break;
            case 6:
                currentTroop5 = age6Troop5;
                currentTroop6 = age6Troop6;
                currentTroop7 = age6Troop7;
                currentTroop8 = age6Troop8;
                break;
        }
    }

    public void InstantiateTroop(int value)
    {
        bool isValid = false;
        int id = value / 10;
        int troop = value % 10;
        switch (id)
        {
            case 1:
                if (castle1.player.numberOfTroop < 10 && !isForming1)
                {
                    switch (troop)
                    {
                        case 1:
                            _cost = troop1Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop1;
                                _troopId = 1;
                                isValid = true;
                            }
                            break;

                        case 2:
                            _cost = troop2Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop2;
                                _troopId = 2;
                                isValid = true;
                            }
                            break;

                        case 3:
                            _cost = troop3Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop3;
                                _troopId = 3;
                                isValid = true;
                            }
                            break;

                        case 4:
                            _cost = troop4Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop4;
                                _troopId = 4;
                                isValid = true;
                            }
                            break;
                        case 5:
                            _cost = 750;
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = ultimateTroop;
                                _troopId = 5;
                                isValid = true;
                            }
                            break;
                    }
                }
                else if(castle1.player.numberOfTroop + queue1.Count < 10)
                {
                    switch (troop)
                    {
                        case 1:
                            _cost = troop1Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                queue1.Add(value);
                                castle1.player.AddMoney(-_cost);
                            }
                            break;
                        case 2:
                            _cost = troop2Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                queue1.Add(value);
                                castle1.player.AddMoney(-_cost);
                            }
                            break;
                        case 3:
                            _cost = troop3Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                queue1.Add(value);
                                castle1.player.AddMoney(-_cost);
                            }
                            break;
                        case 4:
                            _cost = troop4Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                queue1.Add(value);
                                castle1.player.AddMoney(-_cost);
                            }
                            break;
                        case 5:
                            _cost = 750;
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                queue1.Add(value);
                                castle1.player.AddMoney(-_cost);
                            }
                            break;
                    }
                }

                break;
            case 2:
                if (castle2.player.numberOfTroop < 10 && !isForming2)
                {
                    switch (troop)
                    {

                        case 1:
                            _cost = troop1Costs[castle2.player.GetAge() - 1];
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop5;
                                _troopId = 1;
                                isValid = true;
                            }
                            break;

                        case 2:
                            _cost = troop2Costs[castle2.player.GetAge() - 1];
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop6;
                                _troopId = 2;
                                isValid = true;
                            }
                            break;

                        case 3:
                            _cost = troop3Costs[castle2.player.GetAge() - 1];
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop7;
                                _troopId = 3;
                                isValid = true;
                            }
                            break;

                        case 4:
                            _cost = troop4Costs[castle2.player.GetAge() - 1];
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop8;
                                _troopId = 4;
                                isValid = true;
                            }
                            break;
                        case 5:
                            _cost = 750;
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = ultimateTroop;
                                _troopId = 5;
                                isValid = true;
                            }
                            break;
                    }
                }
                else if(castle2.player.numberOfTroop + queue2.Count < 10)
                {
                    switch (troop)
                    {
                        case 1:
                            _cost = troop1Costs[castle2.player.GetAge() - 1];
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                queue2.Add(value);
                                castle2.player.AddMoney(-_cost);
                            }
                            break;
                        case 2:
                            _cost = troop2Costs[castle2.player.GetAge() - 1];
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                queue2.Add(value);
                                castle2.player.AddMoney(-_cost);
                            }
                            break;
                        case 3:
                            _cost = troop3Costs[castle2.player.GetAge() - 1];
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                queue2.Add(value);
                                castle2.player.AddMoney(-_cost);
                            }
                            break;
                        case 4:
                            _cost = troop4Costs[castle2.player.GetAge() - 1];
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                queue2.Add(value);
                                castle2.player.AddMoney(-_cost);
                            }
                            break;
                        case 5:
                            _cost = 750;
                            if (castle2.player.GetMoney() >= _cost)
                            {
                                queue2.Add(value);
                                castle2.player.AddMoney(-_cost);
                            }
                            break;
                    }
                }
                break;
        }
        if (isValid)
        {
            CreateTroop(id, _troopId, _troopToInstantiate);
        }
        else
        {
            //Debug.Log("not enough money or too fast");
        }
    }

    private void CreateTroop(int id, int troopId, GameObject troopToCreate)
    {
        Player currentPlayer;
        List<GameObject> currentTroops;
        Vector2 new_position;

        if (id == 1)
        {
            isForming1 = true;
            currentPlayer = castle1.player;
            currentTroops = troopsPlayer1;
            new_position = new Vector2(500, 0);
        }
        else
        {
            isForming2 = true;
            currentPlayer = castle2.player;
            currentTroops = troopsPlayer2;
            new_position = new Vector2(5000, 0);
        }

        if (_isOnline)
        {
            GameObject newObject = PhotonNetwork.Instantiate(troopToCreate.name, new_position, Quaternion.identity, 0);
            currentPlayer.numberOfTroop += 1;
            currentPlayer.AddMoney(-_cost);
            currentTroops.Add(newObject);
            GameManager script = newObject.GetComponent<GameManager>();
            script.SetPlayer(id, troopId);
        }
        else
        {
            GameObject newObject = Instantiate(troopToCreate, new_position, Quaternion.identity);
            currentPlayer.numberOfTroop += 1;
            currentPlayer.AddMoney(-_cost);
            GameManager script = newObject.GetComponent<GameManager>();
            currentTroops.Add(newObject);
            script.SetPlayer(id, troopId);
        }
    }


    public void DestroyTroop(int id, string uniqueTroopId)
    {
        if (id == 1)
        {
            for(int i = troopsPlayer1.Count-1; i>=0; i--)
            {
                GameObject troop = troopsPlayer1[i];
                if (troop != null)
                {
                    GameManager gameManager = troop.GetComponent<GameManager>();
                    if(gameManager.uniqueId == uniqueTroopId)
                    {
                        troopsPlayer1.Remove(troop);
                    }
                }
            }
            castle1.player.numberOfTroop -= 1;
            //troopsPlayer1.Remove(troop);
        }
        if(id == 2)
        {
            for (int i = troopsPlayer2.Count-1; i >= 0; i--)
            {
                GameObject troop = troopsPlayer2[i];
                if (troop != null)
                {
                    GameManager gameManager = troop.GetComponent<GameManager>();
                    if (gameManager.uniqueId == uniqueTroopId)
                    {
                        troopsPlayer2.Remove(troop);
                    }
                } 
            }
            castle2.player.numberOfTroop -= 1;
            //troopsPlayer2.Remove(troop);
        }
    }
}