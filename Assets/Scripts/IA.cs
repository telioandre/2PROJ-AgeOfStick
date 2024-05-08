using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Player player;
    public Player opponent;
    public Casern casern;

    private DifficultyManager selectedDifficulty;

    private System.Random random = new System.Random();
    private float timer = 0f;
    private float interval = 2f;
    private string difficulty;

   

    private void Start()
    {
        selectedDifficulty = DifficultyManager.difficulty;
        difficulty = selectedDifficulty.ToString().Split(' ')[0];
        Debug.Log(difficulty);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            GenerateRandomNumber();
        }
    }
    void GenerateRandomNumber()
    {
        int randomNumber = random.Next(1, 11);
        if (randomNumber < 2)
        {
            IAgeUp();
        }
        if (randomNumber == 2)
        {
            IaSpecialAttack();
        }
        else
        {
            IaGenerateEmergencyTroop();
        }
    }
    void IaGenerateTroop()
    {
        if (casern.troops.Count > 0)
        {
            int randomCounter = random.Next(0, opponent.numberOfTroop);
        }

    }
    void IaGenerateEmergencyTroop()
    {
        if (opponent.numberOfTroop > 0)
        {
            if (opponent.numberOfTroop > player.numberOfTroop)
            {
                string lastEnemy = casern.troops[casern.troops.Count - 1].name;
                // Debug.Log(difficulty);
                switch (difficulty)
                {
                    case "Easy":
                        int randomTroop = Random.Range(1, 5);
                        switch (randomTroop)
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
                        break;

                    default:
                        switch (lastEnemy)
                        {
                            case "Troop 1 ally(Clone)":
                                casern.InstantiateTroop(24);
                                break;
                                
                            case "Troop 2 ally(Clone)":
                                casern.InstantiateTroop(21);
                                break;

                            case "Troop 3 ally(Clone)":
                                casern.InstantiateTroop(22);
                                break;

                            case "Troop 4 ally(Clone)":
                                casern.InstantiateTroop(23);
                                break;
                        }
                        break;
                }
            }
        }
    }
    void IAgeUp()
    {
        Debug.Log(" IAge Up");
        player.AgeUp();
    }
    void IaSpecialAttack()
    { 
        Debug.Log(" IAttaque spéciale");
        player.SpecialAttack(2);
        
    }
}
