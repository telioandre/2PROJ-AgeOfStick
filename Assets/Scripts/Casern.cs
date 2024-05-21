using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Casern : MonoBehaviour
{
    public Player player;
    public Player opponent;

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

    private GameObject _troopToInstantiate;
    private int _troopId;
    private int _cost;
    private float _cooldown = 1f;
    private float _lastPlayer1Invoque;
    private float _lastPlayer2Invoque;

    //public int numberOfTroop1 = 0;
    //public int numberOfTroop2 = 0;
    public List<GameObject> troopsPlayer1 = new List<GameObject>();
    public List<GameObject> troopsPlayer2 = new List<GameObject>();
    [FormerlySerializedAs("IA")] public Ia ia;

    private List<int> _troop1Costs;
    private List<int> _troop2Costs;
    private List<int> _troop3Costs;
    private List<int> _troop4Costs;

    void Start()
    {
        _lastPlayer1Invoque = -_cooldown;
        _lastPlayer2Invoque = -_cooldown;

        _troop1Costs = new List<int>() { 2, 7, 12, 25, 60, 150 };
        _troop2Costs = new List<int>() { 1, 5, 9, 20, 55, 110 };
        _troop3Costs = new List<int>() { 7, 11, 22, 49, 95, 172 };
        _troop4Costs = new List<int>() { 9, 20, 41, 100, 200, 300 };
    }

    private void Update()
    {
        if(troopsPlayer1.Count > 0 && troopsPlayer2.Count > 0)
        {
        GetFirstTroop();
        }
        switch (player.age)
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
        switch (opponent.age)
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

    public void GetFirstTroop()
    {
        Debug.Log(troopsPlayer1[0].name);
        Debug.Log(troopsPlayer2[0].name);
    }
    public void InstantiateTroop(int value)
    {
        bool isValid = false;
        int id = value / 10;
        int troop = value % 10;
        switch (id)
        {
            case 1:
                if (player.numberOfTroop < 10 && Time.time - _lastPlayer1Invoque > _cooldown)
                {
                    _lastPlayer1Invoque = Time.time;
                    switch (troop)
                    {
                        case 1:
                            _cost = _troop1Costs[player.age - 1];
                            if (player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop1;
                                _troopId = 1;
                                isValid = true;
                            }
                            break;

                        case 2:
                            _cost = _troop2Costs[player.age - 1];
                            if (player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop2;
                                _troopId = 2;
                                isValid = true;
                            }
                            break;

                        case 3:
                            _cost = _troop3Costs[player.age - 1];
                            if (player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop3;
                                _troopId = 3;
                                isValid = true;
                            }
                            break;

                        case 4:
                            _cost = _troop4Costs[player.age - 1];
                            if (player.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop4;
                                _troopId = 4;
                                isValid = true;
                            }
                            break;
                    }
                }

                break;
            case 2:
                if (opponent.numberOfTroop < 10 && Time.time - _lastPlayer2Invoque > _cooldown)
                {
                    _lastPlayer2Invoque = Time.time;
                    switch (troop)
                    {

                        case 1:
                            _cost = _troop1Costs[opponent.age - 1];
                            if (opponent.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop5;
                                _troopId = 1;
                                isValid = true;
                            }
                            break;

                        case 2:
                            _cost = _troop2Costs[opponent.age - 1];
                            if (opponent.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop6;
                                _troopId = 2;
                                isValid = true;
                            }
                            break;

                        case 3:
                            _cost = _troop3Costs[opponent.age - 1];
                            if (opponent.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop7;
                                _troopId = 3;
                                isValid = true;
                            }
                            break;

                        case 4:
                            _cost = _troop4Costs[opponent.age - 1];
                            if (opponent.GetMoney() >= _cost)
                            {
                                _troopToInstantiate = currentTroop8;
                                _troopId = 4;
                                isValid = true;
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

    public void CreateTroop(int id, int troopId, GameObject troopToCreate)
    {
        GameObject newObject = Instantiate(troopToCreate, transform.position, Quaternion.identity);
        if (id == 1)
        {
            player.numberOfTroop += 1;
            troopsPlayer1.Add(newObject);
            Debug.Log("Troop player 1 count: " + troopsPlayer1.Count);
            player.AddMoney(-_cost);
        }
        else
        {
            opponent.numberOfTroop += 1;
            troopsPlayer2.Add(newObject);
            Debug.Log("Troop player 2 count: " + troopsPlayer2.Count);
            opponent.AddMoney(-_cost);
        }
        Movement script = newObject.GetComponent<Movement>();
        script.SetPlayer(id, troopId);
    }

    public void DestroyTroop(int id, string uniqueTroopId)
    {
        //Debug.Log(uniqueTroopId + " unique ID");

        Debug.Log("Troop player 1 count: " + troopsPlayer1.Count);
        Debug.Log("Troop player 2 count: " + troopsPlayer2.Count);
        if (id == 1)
        {
            Debug.Log("id 1");
            for(int i = troopsPlayer1.Count-1; i>=0; i--)
            {
                GameObject troop = troopsPlayer1[i];
                Movement movement = troop.GetComponent<Movement>();

                Debug.Log("troopsPlayer1");
                Debug.Log(uniqueTroopId + " unique ID");
                Debug.Log(movement.id + " movement ID");
                if (movement.uniqueId == uniqueTroopId)
                {
                    troopsPlayer1.Remove(troop);
                }
            }
            player.numberOfTroop -= 1;
            //troopsPlayer1.Remove(troop);
        }
        else if (id == 2)
        {
            Debug.Log("id 2");
            Debug.Log("Troop player count: " + troopsPlayer2.Count);
            for (int i = troopsPlayer2.Count-1; i >= 0; i--)
            {
                GameObject troop = troopsPlayer2[i];
                Movement movement = troop.GetComponent<Movement>();


                Debug.Log("troopsPlayer2");
                Debug.Log(uniqueTroopId + " unique ID");
                Debug.Log(movement.id + " movement ID");
                if (movement.uniqueId == uniqueTroopId)
                {
                    troopsPlayer2.Remove(troop);
                }
            }
            opponent.numberOfTroop -= 1;
            //troopsPlayer2.Remove(troop);
        }
        else
        {
            Debug.Log("id inconnu");
        }
    }
}