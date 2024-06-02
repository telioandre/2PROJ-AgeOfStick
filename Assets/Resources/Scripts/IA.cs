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

    /*
     * This start method will set the IA level depending on the selected difficulty send by the DifficultyManager script.
     * Depending on the difficulty, the IA will get a start buff.
     */
    private void Start()
    {
        _selectedDifficulty = DifficultyManager.difficulty;
        _difficulty = _selectedDifficulty.ToString().Split(' ')[0];
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
                player.AddXp(1300);
                break;
        }
    }

    /*
     * Getter to see the current difficulty.
     */
    public string GetDifficulty()
    {
        return _difficulty;
    }

    /*
     * Main method to set what the IA will do, based on a random number, all along the game.
     * The choices and their probabilities will vary with the difficulty.
     */
    void Update()
    {
        _frameCounter++;
        if (_frameCounter % UpdateInterval == 0)
        {
            int randomNumber = Random.Range(1, 31);

            if (player.GetAge() < 6)
            {
                if (player.GetXp() >= player.ageCosts[player.GetAge() - 1] && _difficulty != "Impossible")
                {
                    AgeUp();
                }
            }

            switch (_difficulty)
            {
                case "Easy":
                    if (randomNumber == 1)
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
                            int turret = Random.Range(1, 4);
                            IaBuildTurret(archi.nbPlacementId2, turret);
                        }
                    }

                    if (randomNumber == 4)
                    {
                        IaUpgradeTurret();
                    }

                    if (randomNumber >= 22)
                    {
                        IaGenerateTroop(0);
                    }

                    break;
                case "Normal":
                    if ((castle.lifePoint < _previousLifePoint || randomNumber >= 22) && player.numberOfTroop == 0)
                    {
                        IaGenerateEffectiveTroop(0);
                    }

                    if (randomNumber <= 2)
                    {
                        if (archi.nbPlacementId2 < 4 && archi.nbPlacementId2 == archi.nbTowerId2)
                        {
                            IaBuildTowerSpot();
                        }
                        else if(archi.nbPlacementId2 > archi.nbTowerId2)
                        {
                            int turret = Random.Range(1, 4);
                            IaBuildTurret(archi.nbPlacementId2, turret);
                        }
                    }

                    if (randomNumber > 2 && randomNumber <= 6)
                    {
                        int randomTroop = Random.Range(1, 5);
                        IaUpgradeTroop(randomTroop);
                    }

                    if (randomNumber == 7)
                    {
                        IaUpgradeTurret();
                    }
                    
                    if (player.numberOfTroop + 7 <= opponent.numberOfTroop)
                    {
                        IaSpecialAttack();
                        IaGenerateTroop(0);
                    }

                    if (randomNumber >= 21)
                    {
                        if (opponent.numberOfTroop == 0)
                        {
                            IaGenerateTroop(0);
                        }

                        else if (player.numberOfTroop == 0 && opponent.numberOfTroop > player.numberOfTroop)
                        {
                            IaGenerateEffectiveTroop(0);
                        }
                        else
                        {
                            IaGenerateSmartTroop();
                        }
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
                            int turret = Random.Range(1, 4);
                            IaBuildTurret(archi.nbPlacementId2, turret);
                        }
                    }

                    if (randomNumber > 3 && randomNumber <= 8)
                    {
                        int randomTroop = Random.Range(1, 5);
                        IaUpgradeTroop(randomTroop);
                    }
                    
                    if (randomNumber > 8  && randomNumber <= 10)
                    {
                        IaUpgradeTurret();
                    }

                    if (player.numberOfTroop + 5 <= opponent.numberOfTroop)
                    {
                        IaSpecialAttack();
                        IaGenerateEffectiveTroop(0);
                    }

                    if (randomNumber >= 20)
                    {
                        IaGenerateEffectiveTroop(casern.troopsPlayer2.Count);
                    }

                    if (randomNumber >= 18 && Time.time - _lastCombo > -Cooldown)
                    {
                        StartCoroutine(IaGenerateCombos(0));
                        _lastCombo = Time.time;
                    }

                    _previousLifePoint = castle.lifePoint;
                    break;

                case "Impossible":
                    if (player.numberOfTroop == 0 && !IsStep1Completed() && !IsStep2Completed())
                    {
                        StartCoroutine(IaGenerateCombos(3));
                    }

                    if (!IsStep1Completed())
                    {
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
                        if (archi.nbPlacementId2 < 4 && archi.nbPlacementId2 == archi.nbTowerId2)
                        {
                            IaBuildTowerSpot();
                        }

                        if (archi.nbPlacementId2 > archi.nbTowerId2)
                        {
                            IaBuildTurret(archi.nbPlacementId2, 2);
                        }

                        if (randomNumber >= 18)
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
                        if (player.GetAge() != 6)
                        {
                            AgeUp();
                        } 
                        IaSell(4);
                        IaSell(3);
                        IaBuildTurret(3, 2);
                        IaBuildTurret(4, 2);
                        if (player.GetAge() == 6)
                        {
                            IaUnlockTroop5();
                            
                            if (randomNumber >= 1 && randomNumber < 5)
                            {
                                int randomTroop = Random.Range(1, 5);
                                IaUpgradeTroop(randomTroop);
                            }

                            if (randomNumber >= 5 && randomNumber < 8)
                            {
                                IaBuildTurret(1, 2);
                            }
                            if (randomNumber >= 8 && randomNumber < 11)
                            {
                                IaBuildTurret(2, 2);
                            }
                            
                            if (randomNumber >= 25)
                            {
                                IaGenerateTroop(0);
                            }
                            IaGenerateTroop(5);
                        }
                    }
                    break;
            }
            _frameCounter = 0;
        }
    }

    /*
     * Method to check if the first step of the Impossible level is done.
     */
    private bool IsStep1Completed()
    {
        return archi.nbTowerId2 >= 1;
    }
    
    /*
     * Method to check if the second step of the Impossible level is done.
     */
    private bool IsStep2Completed()
    {
        return player.GetMoney() >= 1200 && player.GetXp() >= 47500;
    }
    
    /*
     * Method to create troop with the Casern script.
     */
    private void IaGenerateTroop(int troop)
    {
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

    /*
     * Method to generate troop with the Casern script.
     * It removes the possibility of placing a weak troop based on which troop the opponent has the most.
     */
    private void IaGenerateSmartTroop()
    {
        List<int> possibleTroop = new List<int> { 1, 2, 3, 4 };
        int troopToAvoid = CountTroops();
        possibleTroop.Remove(troopToAvoid % 4 + 1);
        int randomIndex = Random.Range(0, possibleTroop.Count);
        int troopToInstantiate = possibleTroop[randomIndex];
        int value = int.Parse("2" + troopToInstantiate);
        casern.InstantiateTroop(value);
    }

    /*
     * Method to let the IA generate a combo of troop.
     */
    private IEnumerator IaGenerateCombos(int combo)
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

    /*
     * This method will create a super effective troop against the opponent enemy at the chosen index.
     */
    private void IaGenerateEffectiveTroop(int index)
    {
        if (index == -1)
        {
            index = casern.troopsPlayer1.Count - 1;
        }
        if (opponent.numberOfTroop > 0)
        {
            if (opponent.numberOfTroop > player.numberOfTroop)
            {
                int enemyTroop = casern.troopsPlayer1[index].GetComponent<GameManager>().troopId;
                
                switch (enemyTroop)
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

    /*
     * This method will count every opponent's troops and then return the index of the troop with the highest count.
     */
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
        return maxIndex + 1;
    }
    
    /*
     * This method will build a spot for a turret based on the Archi script.
     */
    private void IaBuildTowerSpot()
    {
        archi.BuySpot(2);
    }
    
    /*
     * This method will build a turret based on the Archi script.
     */
    private void IaBuildTurret(int placement, int turret)
    {
        archi.PlaceTurret(placement, 2, turret);
    }

    /*
     * This method will upgrade a troop based on the Player script.
     */
    private void IaUpgradeTroop(int troop)
    {
        player.UpgradeTroopLevel(troop);
    }

    /*
     * This method will upgrade a turret based on the Player script.
     */
    private void IaUpgradeTurret()
    {
        int upgrade = Random.Range(1, 3);
        player.UpgradeTurret(upgrade);
    }

    /*
     * This method will upgrade the age based on the Player script.
     */
    private void AgeUp()
    {
        player.AgeUp();
    }

    /*
     * This method will sell a turret based on the Archi script.
     */
    private void IaSell(int placement)
    {
        archi.SellSpot(placement, 2);
    }
    
    /*
     * This method will launch a special attack based on the Player script.
     */
    private void IaSpecialAttack()
    {
        player.SpecialAttack(2);
    }

    /*
     * This method will unlock the ultimate troop based on the Player script.
     */
    private void IaUnlockTroop5()
    {
        player.UnlockTroop5();
    }
}