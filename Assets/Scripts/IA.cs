using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Player player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    private GameObject enemyToInstantiate;
    private List<GameObject> enemies;
    public Casern casern;

    private DifficultyManager selectedDifficulty;

    private System.Random random = new System.Random();
    private float timer = 0f;
    private float interval = 3f;
    private int randomNumber = 0;
    private string difficulty;

    void GenerateRandomNumber()
    {
        randomNumber = random.Next(1, 4);
        IaSpecialAttack();
    }

    private void Start()
    {
        enemies = new List<GameObject>() { enemy1, enemy2, enemy3, enemy4 };
        casern = FindObjectOfType<Casern>();

         selectedDifficulty = DifficultyManager.difficulty;
         difficulty = selectedDifficulty.ToString().Split(' ')[0];
         Debug.Log(difficulty); 
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            // Debug.Log(casern.numberOfTroop1 + "  Troupes 1 nombre");
            if(casern.troops.Count > 0)
            {
                if (casern.numberOfTroop1 > casern.numberOfTroop2)
                {
                    string lastEnemy = casern.troops[casern.troops.Count-1].name;
                    // Debug.Log(difficulty);
                    switch (difficulty)
                    {
                        case "Easy":
                            int randomIndex = Random.Range(0, enemies.Count);
                            enemyToInstantiate = enemies[randomIndex];
                            break;

                        default:
                            switch (lastEnemy)
                                {
                                case "Troop 1 ally(Clone)":
                                    enemyToInstantiate = enemy4;
                                    break;

                                case "Troop 2 ally(Clone)":
                                    enemyToInstantiate = enemy1;
                                    break;

                                case "Troop 3 ally(Clone)":
                                    enemyToInstantiate = enemy2;
                                    break;

                                case "Troop 4 ally(Clone)":
                                    enemyToInstantiate = enemy3;
                                    break;
                                }
                            break;
                        }
                    
                    GameObject newObject = Instantiate(enemyToInstantiate, transform.position, Quaternion.identity);
                    if (newObject != null)
                        {
                            Movement script = newObject.GetComponent<Movement>();
                            if (script != null)
                            {
                                casern.numberOfTroop2 += 1;                                
                                // Debug.Log(casern.numberOfTroop2 + "  Troupes 2 nombre");
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
                        }
                    
                }
            }
            timer = 0f;
            //GenerateRandomNumber();
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
