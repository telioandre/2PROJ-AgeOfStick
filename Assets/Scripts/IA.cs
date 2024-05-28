using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia : MonoBehaviour
{
    public Player player;
    public Player opponent;
    public Castle castle;
    public Casern casern;
    public Archi archi;
    private DifficultyManager _selectedDifficulty;
    private string _difficulty;
    private int _previousLifePoint; 
    private int _frameCounter;
    private const int UpdateInterval = 360;
    private const float Cooldown = -2f;
    private float _lastCombo;

    private void Start()
    {
        _selectedDifficulty = DifficultyManager.difficulty;
        _difficulty = "Easy";
        //_difficulty = _selectedDifficulty.ToString().Split(' ')[0];
        Debug.Log(_difficulty);
        _previousLifePoint = castle.maxLifePoint;
        _lastCombo = -Cooldown;
        switch (_difficulty)
        {
            case "Easy":
                break;
            case "Normal":
                player.AddMoney(20);
                player.AddXp(200);
                break;
            case "Hard":
                player.AddMoney(30);
                player.AddXp(300);
                break;
            case "Impossible":
                player.AddMoney(40);
                player.AddXp(1500);
                break;
        }
    }

    void Update()
    {
        _frameCounter++;
        if (_frameCounter % UpdateInterval == 0)
        {
            int randomNumber = Random.Range(1, 21);
            //Debug.Log(randomNumber);

            if (player.GetAge() < 6)
            {
                if (player.GetXp() >= player.ageCosts[player.GetAge() - 1] && _difficulty != "Impossible")
                {
                    //AgeUp();
                }
            }

            switch (_difficulty)
            {
                case "Easy":
                    if (randomNumber <= 10)
                    {
                        IaSpecialAttack();
                    }

                    if (randomNumber == 2)
                    {
                        int randomTroop = Random.Range(1, 5);
                        IaUpgradeTroop(randomTroop);
                    }

                    if (randomNumber == 3)
                    {
                        if (archi.nbPlacementId2 < 4 && archi.nbPlacementId2 == archi.nbTowerId2)
                        {
                            IaBuildTowerSpot();
                        }
                        else if(archi.nbPlacementId2 > archi.nbTowerId2)
                        {
                            IaBuildTurret(archi.nbPlacementId2, 2);
                        }
                    }

                    if (randomNumber >= 15)
                    {
                        //IaGenerateTroop(0);
                    }

                    break;
                case "Normal":
                    if ((castle.lifePoint < _previousLifePoint || randomNumber >= 15) && player.numberOfTroop == 0)
                    {
                        IaGenerateEffectiveTroop(); // sur le premier
                    }

                    if (randomNumber <= 2)
                    {
                        if (archi.nbPlacementId2 < 4 && archi.nbPlacementId2 == archi.nbTowerId2)
                        {
                            IaBuildTowerSpot();
                        }
                        else if(archi.nbPlacementId2 > archi.nbTowerId2)
                        {
                            IaBuildTurret(archi.nbPlacementId2, 2);
                        }
                    }

                    if (randomNumber > 2 && randomNumber <= 6)
                    {
                        int randomTroop = Random.Range(1, 5);
                        IaUpgradeTroop(randomTroop);
                    }

                    if (player.numberOfTroop + 7 <= opponent.numberOfTroop)
                    {
                        IaSpecialAttack();
                        IaGenerateTroop(0);
                    }

                    if (randomNumber >= 15)
                    {
                        if (opponent.numberOfTroop == 0)
                        {
                            IaGenerateTroop(0);
                        }

                        if (player.numberOfTroop == 0 && opponent.numberOfTroop > player.numberOfTroop)
                        {
                            IaGenerateEffectiveTroop(); // sur le premier
                        }

                        List<int> possibleTroop = new List<int>() { 1, 2, 3, 4 };
                        int troopToAvoid = CountTroops();
                        possibleTroop.Remove((troopToAvoid % 4) + 1);
                        int randomIndex = Random.Range(0, possibleTroop.Count);
                        int troopToInstantiate = possibleTroop[randomIndex];
                        int value = int.Parse("2" + troopToInstantiate);
                        casern.InstantiateTroop(value);
                    }

                    _previousLifePoint = castle.lifePoint;
                    break;
                case "Hard":
                    if (randomNumber <= 3)
                    {
                        if (archi.nbPlacementId2 < 4 && archi.nbPlacementId2 == archi.nbTowerId2)
                        {
                            IaBuildTowerSpot();
                        }
                        else if(archi.nbPlacementId2 > archi.nbTowerId2)
                        {
                            IaBuildTurret(archi.nbPlacementId2, 2);
                        }
                    }

                    if (randomNumber > 3 && randomNumber <= 8)
                    {
                        int randomTroop = Random.Range(1, 5);
                        IaUpgradeTroop(randomTroop);
                    }

                    if (player.numberOfTroop + 5 <= opponent.numberOfTroop)
                    {
                        IaSpecialAttack();
                        IaGenerateEffectiveTroop(); // sur le premier
                    }

                    if (randomNumber >= 16)
                    {
                        IaGenerateEffectiveTroop(); // sur celle équivalent
                    }

                    if (randomNumber >= 18 && Time.time - _lastCombo > -Cooldown)
                    {
                        StartCoroutine(IaGenerateCombos(0));
                        _lastCombo = Time.time;
                    }

                    _previousLifePoint = castle.lifePoint;
                    break;

                case "Impossible":
                    if (player.numberOfTroop == 0)
                    {
                        StartCoroutine(IaGenerateCombos(3));
                    }

                    if (!IsStep1Completed())
                    {
                        print("step 1");
                        if (opponent.numberOfTroop > 3)
                        {
                            IaSpecialAttack();
                        }

                        if (archi.nbPlacementId2 == 0)
                        {
                            IaBuildTowerSpot();
                        }

                        if (archi.nbTowerId2 == 0)
                        {
                            IaBuildTurret(1, 2);
                        }
                    }
                    else if (IsStep1Completed() && !IsStep2Completed())
                    {
                        print("step 2");
                        if (archi.nbPlacementId2 < 4 && archi.nbPlacementId2 == archi.nbTowerId2)
                        {
                            IaBuildTowerSpot();
                        }

                        if (archi.nbPlacementId2 > archi.nbTowerId2)
                        {
                            IaBuildTurret(archi.nbPlacementId2, 2);
                        }

                        if (randomNumber >= 15)
                        {
                            IaGenerateTroop(2);
                        }
                        if (opponent.numberOfTroop > player.numberOfTroop + 4)
                        {
                            IaSpecialAttack();
                        }
                    }
                    else
                    {
                        print("step 3");
                        if (player.GetAge() != 6)
                        {
                            AgeUp();
                            /*IaSell();
                            IaSell();
                            IaBuildTurret(1, 3);
                            IaBuildTurret(2, 3);
                            IaGenerateTroop(5);*/
                        } 
                    }

                    break;
            }

            _frameCounter = 0;
        }
    }

    private bool IsStep1Completed()
    {
        return archi.nbTowerId2 >= 1;
    }
    
    private bool IsStep2Completed()
    {
        return player.GetMoney() >= 1000 && player.GetXp() >= 50000;
    }
    
    public int CountTroops()
    {
        int[] numberTroops = new int[4];

        foreach (GameObject gameobject in casern.troopsPlayer1)
        {
            GameManager script = gameobject.GetComponent<GameManager>();
            switch(script.troopId) {
                case 1:
                    numberTroops[0] += 1;
                    break;
                case 2:
                    numberTroops[1] += 1;
                    break;
                case 3:
                    numberTroops[2] += 1;
                    break;
                case 4:
                    numberTroops[3] += 1;
                    break;
            }
        }
        int maxIndex = 0;
        for (int i = 1; i < 4; i++)
        {
            if (numberTroops[i] > numberTroops[maxIndex])
            {
                maxIndex = i;
            }

        }
        Debug.Log(maxIndex + 1);
        return maxIndex + 1;
    }
    void IaGenerateTroop(int troop)
    {
        //print(casern.troopsPlayer2.Count);
        if (troop == 0)
        {
            troop = Random.Range(1, 5);
        }
        switch (troop)
        {
            case 1:
                casern.InstantiateTroop(21);
                break;

            case 2:
                casern.InstantiateTroop(22);
                break;

            case 3:
                casern.InstantiateTroop(23);
                break;

            case 4:
                casern.InstantiateTroop(24);
                break;
        }
    }

    IEnumerator IaGenerateCombos(int combo)
    {
        if (combo == 0)
        {
            combo = Random.Range(1, 5);
            
        }
        switch(combo)
        {
            case 1:
                yield return new WaitForSeconds(1);
                casern.InstantiateTroop(24);
                yield return new WaitForSeconds(3);
                casern.InstantiateTroop(22);
                yield return new WaitForSeconds(1);
                casern.InstantiateTroop(22);
                break;
            case 2:
                yield return new WaitForSeconds(1);
                casern.InstantiateTroop(23);
                yield return new WaitForSeconds(2);
                casern.InstantiateTroop(24);
                break;
            case 3:
                yield return new WaitForSeconds(1);
                casern.InstantiateTroop(22);
                yield return new WaitForSeconds(1);
                casern.InstantiateTroop(23);
                yield return new WaitForSeconds(1);
                casern.InstantiateTroop(22);
                break;
            case 4:
                yield return new WaitForSeconds(1);
                casern.InstantiateTroop(23);
                yield return new WaitForSeconds(2);
                casern.InstantiateTroop(22);
                yield return new WaitForSeconds(1);
                casern.InstantiateTroop(24);
                break;
        }
        yield return null;
    }

    void IaGenerateEffectiveTroop()
    {
        if (opponent.numberOfTroop > 0)
        {
            if (opponent.numberOfTroop > player.numberOfTroop)
            {
                int lastEnemy = casern.troopsPlayer1[casern.troopsPlayer1.Count - 1].GetComponent<GameManager>().troopId;
                
                switch (lastEnemy)
                {
                    case 1:
                        casern.InstantiateTroop(24);
                        break;
                        
                    case 2:
                        casern.InstantiateTroop(21);
                        break;
                        
                    case 3:
                        casern.InstantiateTroop(22);
                        break;
                        
                    case 4:
                        casern.InstantiateTroop(23);
                        break;
                }
            }
        }
    }

    void IaBuildTowerSpot()
    {
        archi.BuySpot(2);
    }
    void IaBuildTurret(int placement, int turret)
    {
        archi.PlaceTurret(placement, 2, turret);
    }

    void IaUpgradeTroop(int troop)
    {
        player.UpgradeTroopLevel(troop);
    }

    void IaUpgradeTower()
    {

    }

    void AgeUp()
    {
        //Debug.Log(" IAge Up");
        player.AgeUp();
    }

    void IaSell()
    {
        
    }
    void IaSpecialAttack()
    {
        //Debug.Log(" IAttaque spéciale");
        player.SpecialAttack(2);
    }
}