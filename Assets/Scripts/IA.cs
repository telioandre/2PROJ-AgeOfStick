using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia : MonoBehaviour
{
    public Player player;
    public Player opponent;
    public Castle castle;
    public Casern casern;
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
                //player.AddXp(6400);
                //player.AgeUp();
                break;
            case "Normal":
                player.AddMoney(20);
                break;
            case "Hard":
                player.AddMoney(30);
                break;
            case "Impossible":
                player.AddMoney(40);
                break;
        }
    }

    void Update()
    {
        _frameCounter++;
        if(_frameCounter % UpdateInterval == 0 )
        {
            int randomNumber = Random.Range(1, 21);
            //Debug.Log(randomNumber);

            if (player.xp >= player.ageCosts[player.age - 1])
            {
                AgeUp();
            }
            switch (_difficulty)
            {
                case "Easy":
                    /*if (randomNumber <= 3)
                    {
                        IaSpecialAttack();
                    }
                    if (randomNumber > 3 && randomNumber <= 5)
                    {
                        int randomTroop = Random.Range(1, 5);
                        IaUpgradeTroop(randomTroop);
                    }
                    if (randomNumber > 5 && randomNumber <= 7)
                    {
                        if (castle.numberOfTower + castle.TowerSpotAvailable < 4)
                        {
                            IaBuildTowerSpot();
                        }
                        else
                        {
                            IaBuildTower();
                        }
                    }
                    if(randomNumber >= 15)
                    {
                        IaGenerateTroop();
                    }*/
                    break;
                case "Normal":
                    if ((castle.lifePoint < _previousLifePoint || randomNumber >= 15) && player.numberOfTroop == 0)
                    {
                        IaGenerateEffectiveTroop(); // sur le premier
                    }
                    if (randomNumber <= 2)
                    {
                        if (castle.numberOfTower + castle.towerSpotAvailable < 4)
                        {
                            IaBuildTowerSpot();
                        }
                        else
                        {
                            IaBuildTower();
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
                        IaGenerateTroop();
                    }
                    if (randomNumber >= 15)
                    {
                        if(opponent.numberOfTroop == 0)
                        {
                            IaGenerateTroop();
                        }
                        if(player.numberOfTroop == 0 && opponent.numberOfTroop > player.numberOfTroop)
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
                        if (castle.numberOfTower + castle.towerSpotAvailable < 4)
                        {
                            IaBuildTowerSpot();
                        }
                        else
                        {
                            IaBuildTower();
                        }
                    }
                    if (randomNumber > 3 && randomNumber <= 8)
                    {
                        int randomTroop = Random.Range(1, 5);
                        Debug.Log("troupe à up : " + randomTroop);
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
                        StartCoroutine(IaGenerateCombos());
                        _lastCombo = Time.time;
                    }
                    _previousLifePoint = castle.lifePoint;
                    break;
                case "Impossible":
                    IaGenerateEffectiveTroop();
                    break;
            }
            _frameCounter = 0;
        }
    }
    public int CountTroops()
    {
        int[] numberTroops = new int[4];

        foreach (GameObject gameobject in casern.troopsPlayer1)
        {
            Movement script = gameobject.GetComponent<Movement>();
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
    void IaGenerateTroop()
    {
        int randomTroop = Random.Range(1, 5);
        switch (randomTroop)
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

    IEnumerator IaGenerateCombos()
    {
        int randomCombo = Random.Range(1, 5);
        Debug.Log(randomCombo + " random combo");
        switch(randomCombo)
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
                casern.InstantiateTroop(21);
                yield return new WaitForSeconds(1);
                casern.InstantiateTroop(22);
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
                int lastEnemy = casern.troopsPlayer1[casern.troopsPlayer1.Count - 1].GetComponent<Movement>().troopId;
                
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

    }
    void IaBuildTower()
    {

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
    void IaSpecialAttack()
    {
        //Debug.Log(" IAttaque spéciale");
        player.SpecialAttack(2);
    }
}