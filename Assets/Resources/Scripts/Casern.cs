using System.Collections.Generic;
using UnityEngine;

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
    
    /*
     * This Start method will set up the different costs for each troops.
     */
    void Start()
    {
        troop1Costs = new List<int> { 2, 7, 12, 25, 60, 150 };
        troop2Costs = new List<int> { 1, 5, 9, 20, 55, 110 };
        troop3Costs = new List<int> { 7, 11, 22, 49, 95, 172 };
        troop4Costs = new List<int> { 9, 20, 41, 100, 200, 300 };
    }

    /*
     * Boolean setter to see later if the player is playing online or not
     */
    public void setOnline(bool online)
    {
        _isOnline = online;
    }
    
    /*
     * This update method will check the age of the 2 players to set up the correct background for both players.
     * It will also check each queue, it permits to automatically form troops for players if they spammed any troops button.
     * Finally, it will check the current age for each player and change the troop's sprite depending on it.
     */
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

    /*
     * This method take 1 argument "value" then will split it into 2 variables.
     * These 2 variables will be use for the differents switch case.
     * It permits to instantiate the troop according to the player's choice then check if the amount of money is sufficient or not.
     * If the boolean isForming is true, then the value will be save in the queue list corresponding.
     */
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
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
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
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
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
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
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
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
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
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
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
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
                            }
                            break;
                        case 2:
                            _cost = troop2Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                queue1.Add(value);
                                castle1.player.AddMoney(-_cost);
                            }
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
                            }
                            break;
                        case 3:
                            _cost = troop3Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                queue1.Add(value);
                                castle1.player.AddMoney(-_cost);
                            }
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
                            }
                            break;
                        case 4:
                            _cost = troop4Costs[castle1.player.GetAge() - 1];
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                queue1.Add(value);
                                castle1.player.AddMoney(-_cost);
                            }
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
                            }
                            break;
                        case 5:
                            _cost = 750;
                            if (castle1.player.GetMoney() >= _cost)
                            {
                                queue1.Add(value);
                                castle1.player.AddMoney(-_cost);
                            }
                            else
                            {
                                StartCoroutine(castle1.player.MoneyError());
                            }
                            break;
                    }
                }
                else
                {
                    StartCoroutine(castle1.player.TroopsError());
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
    }

    /*
     * This method is called right after the InstantiateTroop() to generalize the process.
     * It will catch the id of the player, so that the spawn points are different, and therefore they do not do premature damage.
     * The method will check if the player is playing online to make the appropriate Instantiation.
     * After the creation, the troop will be store in a list to count of each player.
     */
    private void CreateTroop(int id, int troopId, GameObject troopToCreate)
    {
        Player currentPlayer;
        List<GameObject> currentTroops;
        Vector2 newPosition;

        if (id == 1)
        {
            isForming1 = true;
            currentPlayer = castle1.player;
            currentTroops = troopsPlayer1;
            newPosition = new Vector2(500, -500);
        }
        else
        {
            isForming2 = true;
            currentPlayer = castle2.player;
            currentTroops = troopsPlayer2;
            newPosition = new Vector2(5000, -500);
        }

        if (_isOnline)
        {
            GameObject newObject = PhotonNetwork.Instantiate(troopToCreate.name, newPosition, Quaternion.identity, 0);
            currentPlayer.numberOfTroop += 1;
            if (currentPlayer.castle.id == 1)
            {
                if (queue1.Count == 0)
                {
                    currentPlayer.AddMoney(-_cost);
                }
            }
            if (currentPlayer.castle.id == 2)
            {
                if (queue2.Count == 0)
                {
                    currentPlayer.AddMoney(-_cost);
                }
            }
            currentTroops.Add(newObject);
            GameManager script = newObject.GetComponent<GameManager>();
            script.SetPlayer(id, troopId);
        }
        else
        {
            GameObject newObject = Instantiate(troopToCreate, newPosition, Quaternion.identity);
            currentPlayer.numberOfTroop += 1;
            if (currentPlayer.castle.id == 1)
            {
                if (queue1.Count == 0)
                {
                    currentPlayer.AddMoney(-_cost);
                }
            }
            if (currentPlayer.castle.id == 2)
            {
                if (queue2.Count == 0)
                {
                    currentPlayer.AddMoney(-_cost);
                }
            }
            GameManager script = newObject.GetComponent<GameManager>();
            currentTroops.Add(newObject);
            script.SetPlayer(id, troopId);
        }
    }


    /*
     * This method will get the Player id of the troop to check on the correct list the unique Id it has.
     * Then it will proceed to erase it from the list and destroy the GameObject from the scene.
     */
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
        }
    }
}