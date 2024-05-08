using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int xp = 0;
    public int money = 500;
    public int age = 1;
    public Castle castle;
    public string baseName;
    public TextMeshProUGUI textMoney;
    public TextMeshProUGUI textXp;
    public Color[] ageColors = { Color.blue, Color.yellow, Color.grey, Color.green, Color.magenta, Color.white };
    public GameObject specialAttack;

    public string GetName()
    {
        return baseName;
    }
    public void AddXp(int new_xp)
    {
        xp += new_xp;
        Debug.Log("xp = " + xp);
    }

    public void SuppXp(int new_xp)
    {
        xp -= new_xp;
        Debug.Log("xp = " + xp);
    }

    public int GetXp()
    {
        return xp;
    }

    public void AddMoney(int new_money)
    {
        money += new_money;
        Debug.Log("money = " + money);
    }

    public void SuppMoney(int new_money)
    {
        money -= new_money;
        if (money < 0)
        {
            money = 0;
        }
        Debug.Log("money = " + money);
    }

    public int GetMoney()
    {
        return money;
    }

    public void AgeUp()
    {
        if (age < 6)
        {

            if (xp <= age * 10)
            {
                Debug.Log("Argent insufisant ! Manque : " + (age * 10 - xp));
            }
            else
            {
                xp -= age * 10;
                age += 1;
                Debug.Log("age = " + age);
                Debug.Log("xp = " + xp);
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

    public void rien()
    {
        Debug.Log(GetMoney());
    }

    public void SpecialAttack()
    {
        if (GetXp() >= 100)
        {
            SuppXp(100);
            StartCoroutine(SpecialAttackCoroutine());

        }
        else
        {
            Debug.Log("Not enough XP");
        }
    }

    public IEnumerator SpecialAttackCoroutine()
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
            Vector2 newPosition = transform.position + new Vector3(200f * randomNumber, 400f, 0f);
            GameObject newObject = Instantiate(specialAttack, newPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }


    private void Update()
    {
        textMoney.text = "Money : " + money;
        textXp.text = "XP : " + xp;
    }
}