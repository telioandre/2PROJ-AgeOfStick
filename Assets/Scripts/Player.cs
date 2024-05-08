using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public int xp;
    public int money;
    public int age = 1;
    public Castle castle;
    public string baseName;
    public TextMeshProUGUI textMoney;
    public TextMeshProUGUI textXp;
    public Color[] ageColors = { Color.blue, Color.yellow, Color.grey, Color.green, Color.magenta, Color.white };
    public GameObject specialAttack;
    private List<int> specialCosts;
    private List<int> ageCosts;
    public int troop1level;
    public int troop2level;
    public int troop3level;
    public int troop4level;
    public int numberOfTroop;
    private float specialCooldown = 20f;
    private float lastPlayer1Special;
    private float lastPlayer2Special;

    private void Start()
    {
        specialCosts = new List<int>() { 2300, 2900, 3000, 3800, 4200, 5800 };
        ageCosts = new List<int>() { 6500, 8000, 9500, 11000, 12500 };

        lastPlayer1Special = -specialCooldown;
        lastPlayer2Special = -specialCooldown;
    }

    public string GetName()
    {
        return baseName;
    }
    public void AddXp(int new_xp)
    {
        xp += new_xp;
        //Debug.Log("xp = " + xp);
    }

    public void SuppXp(int new_xp)
    {
        xp -= new_xp;
        //Debug.Log("xp = " + xp);
    }

    public int GetXp()
    {
        return xp;
    }

    public void AddMoney(int new_money)
    {
        money += new_money;
        //Debug.Log("money = " + money);
    }

    public void SuppMoney(int new_money)
    {
        money -= new_money;
        if (money < 0)
        {
            money = 0;
        }
        //Debug.Log("money = " + money);
    }

    public int GetMoney()
    {
        return money;
    }

    public void AgeUp()
    {
        if (age < 6)
        {
            if (xp <= ageCosts[age - 1])
            {
                Debug.Log("XP insufisant ! Manque : " + (ageCosts[age - 1] - xp));
            }
            else
            {
                xp -= ageCosts[age - 1];
                age += 1;
                castle.AddLifePoint(Mathf.RoundToInt(castle.lifePoint * 1.35f));
                castle.AddMaxLifePoint(Mathf.RoundToInt(castle.maxLifePoint * 1.35f));
                SpriteRenderer SpriteColor = GetComponent<SpriteRenderer>();
                SpriteColor.color = ageColors[age - 1];
            }
        }
        else
        {
            Debug.Log("Max age reached");
        }
    }

    public int GetAge()
    {
        return age;
    }
    public bool checkCooldown(int ID)
    {
        int cost = specialCosts[age - 1];
        if (GetXp() >= cost)
            if (ID == 1 && Time.time - lastPlayer1Special > specialCooldown + ((age - 1) * 5))
            {
                SuppXp(cost);
                StartCoroutine(SpecialAttackCoroutine(ID));

                lastPlayer1Special = Time.time;
                return true;

            }
            else if (ID == 2 && Time.time - lastPlayer2Special > specialCooldown + ((age - 1) * 5))
            {
                Debug.Log("Not enough XP");
                lastPlayer2Special = Time.time;
                return true;
            }
        Debug.Log("Too early");
        return false;
    }

    public void SpecialAttack(int ID)
    {
        if (checkCooldown(ID))
        {
            int cost = specialCosts[age - 1];
            if (GetXp() >= cost)
            {
                SuppXp(cost);
                StartCoroutine(SpecialAttackCoroutine(ID));
            }
            else
            {
                Debug.Log("Not enough XP");
            }
        }
    }

    public IEnumerator SpecialAttackCoroutine(int ID)
    {
        List<int> generatedNumbers = new List<int>();
        int randomNumber;
        for (int i = 1; i < 11; i++)
        {
            System.Random random = new System.Random();
            do
            {
                randomNumber = random.Next(1, 21);
            }
            while (generatedNumbers.Contains(randomNumber));

            generatedNumbers.Add(randomNumber);
            if (ID == 1)
            {
                Vector2 newPosition = transform.position + new Vector3(200f * randomNumber, 400f, 0f);
                GameObject newObject = Instantiate(specialAttack, newPosition, Quaternion.identity);
            }
            else if (ID == 2)
            {
                Vector2 newPosition = transform.position + new Vector3(-200f * randomNumber, 400f, 0f);
                GameObject newObject = Instantiate(specialAttack, newPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }

    public void upgradeTroopLevel(int troop)
    {
        switch (troop)
        {
            case 1:
                troop1level += 1;
                break;

            case 2:
                troop2level += 1;
                break;

            case 3:
                troop3level += 1;
                break;

            case 4:
                troop4level += 1;
                break;
        }

    }

    private void Update()
    {
        textMoney.text = "Money : " + castle.player.GetMoney();
        textXp.text = "XP : " + castle.player.GetXp();
    }
}