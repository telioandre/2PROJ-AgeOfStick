using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Player player;

    private System.Random random = new System.Random();
    private float timer = 0f;
    private float interval = 3f;
    private int randomNumber = 0;
    void GenerateRandomNumber()
    {
        randomNumber = random.Next(1, 4);
        Debug.Log("Nombre aléatoire : " + randomNumber);
        IaSpecialAttack();
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

    void IaSpecialAttack()
    {
        if (randomNumber == 1)
        {
            Debug.Log(" IAttaque spéciale");
            player.SpecialAttack(2);
        }
    }
}
