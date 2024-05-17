using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public int xp;
    public int money;
    public int age = 1;
    public Castle castle;
    public Casern casern;
    public Player opponent;
    public string baseName;
    public TextMeshProUGUI textMoney;
    public TextMeshProUGUI textXp;
    public Color[] ageColors = { Color.blue, Color.yellow, Color.grey, Color.green, Color.magenta, Color.white };
    public GameObject specialAttack;
    public List<int> specialCosts;
    public List<int> ageCosts;
    [FormerlySerializedAs("troop1level")] public int troop1Level;
    [FormerlySerializedAs("troop2level")] public int troop2Level;
    [FormerlySerializedAs("troop3level")] public int troop3Level;
    [FormerlySerializedAs("troop4level")] public int troop4Level;
    public int numberOfTroop;
    public float precision;
    private float _specialCooldown = /*2*/0f;
    private float _lastPlayer1Special;
    private float _lastPlayer2Special;
    List<List<int>> _troops1UpgradeCosts = new List<List<int>>()
    {
        new() { 30, 1 },
        new() { 80, 2 },
        new() { 190, 4 },
    };
    List<List<int>> _troops2UpgradeCosts = new List<List<int>>()
    {
        new() { 20, 1 },
        new() { 50, 1 },
        new() { 110, 3 },
    };
    List<List<int>> _troops3UpgradeCosts = new List<List<int>>()
    {
        new() { 80, 2 },
        new() { 120, 3 },
        new() { 210, 5 },
    };
    List<List<int>> _troops4UpgradeCosts = new List<List<int>>()
    {
        new() { 100, 2 },
        new() { 210, 4 },
        new() { 280, 5 }
    };

    private void Start()
    {
        specialCosts = new List<int>() { 2300, 2900, 3000, 3800, 4200, 5800 };
        ageCosts = new List<int>() { 6500, 8000, 9500, 11000, 12500 };

        _lastPlayer1Special = -_specialCooldown;
        _lastPlayer2Special = -_specialCooldown;
    }

    public string GetName()
    {
        return baseName;
    }
    public void AddXp(int newXp)
    {
        xp += newXp;
        //Debug.Log("xp = " + xp);
    }

    public void SuppXp(int newXp)
    {
        xp -= newXp;
        //Debug.Log("xp = " + xp);
    }

    public int GetXp()
    {
        return xp;
    }

    public void AddMoney(int newMoney)
    {
        money += newMoney;
        //Debug.Log("money = " + money);
    }

    public void SuppMoney(int newMoney)
    {
        money -= newMoney;
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
            if (xp < ageCosts[age - 1])
            {
                //Debug.Log("XP insufisant ! Manque : " + (ageCosts[age - 1] - xp));
            }
            else
            {
                xp -= ageCosts[age - 1];
                age += 1;
                castle.AddLifePoint(Mathf.RoundToInt(castle.lifePoint * 1.35f));
                castle.AddMaxLifePoint(Mathf.RoundToInt(castle.maxLifePoint * 1.35f));
                SpriteRenderer spriteColor = GetComponent<SpriteRenderer>();
                spriteColor.color = ageColors[age - 1];
            }
        }
        else
        {
            //Debug.Log("Max age reached");
        }
    }

    public int GetAge()
    {
        return age;
    }
    public bool CheckCooldown(int id)
    {
        if (id == 1 /*&& Time.time - lastPlayer1Special > specialCooldown + ((age - 1) * 5)*/)
        {
            _lastPlayer1Special = Time.time;
            return true;
        }
        if (id == 2 && Time.time - _lastPlayer2Special > _specialCooldown + ((age - 1) * 5))
        {
            _lastPlayer2Special = Time.time;
            return true;
        }
        return false;
    }

    public void SpecialAttack(int id)
    {
        if (CheckCooldown(id))
        {
            int cost = specialCosts[age - 1];
            if (GetXp() >= cost)
            {
                SuppXp(cost);
                StartCoroutine(SpecialAttackCoroutine(id));
            }
            else
            {
                Debug.Log("Not enough XP");
            }
        }
    }

    public IEnumerator SpecialAttackCoroutine(int id)
    {
        List<float> positions = new();
        int randomNumber;
        int start = Mathf.RoundToInt(150f);
        int end = Mathf.RoundToInt(6280f);
        if (id == 1)
        {
            if (casern.troopsPlayer2.Count > 0)
            {
                start = Mathf.RoundToInt(casern.troopsPlayer2[0].transform.position.x);
                end = Mathf.RoundToInt(casern.troopsPlayer2[casern.troopsPlayer2.Count - 1].transform.position.x);
                for (int i = 0; i < casern.troopsPlayer2.Count; i++)
                {
                    Rigidbody2D script = casern.troopsPlayer2[i].GetComponent<Rigidbody2D>();
                    if (script.constraints != RigidbodyConstraints2D.FreezeAll)
                    {
                        positions.Add(script.transform.position.x - 420f - i * 190);
                    }
                    else
                    {
                        positions.Add(script.transform.position.x - 50f);
                    }
                }
            }
            int range = 10 - positions.Count;
            for (int i = 0; i < range; i++)
            {
                do
                {
                    randomNumber = Random.Range(start, end);
                }
                while (positions.Contains(randomNumber));
                positions.Add(randomNumber);
            }
        }
        else
        {
            if (casern.troopsPlayer1.Count > 0)
            {
                start = Mathf.RoundToInt(casern.troopsPlayer1[0].transform.position.x);
                end = Mathf.RoundToInt(casern.troopsPlayer1[casern.troopsPlayer1.Count - 1].transform.position.x);
                for (int i = 0; i < casern.troopsPlayer1.Count; i++)
                {
                    Rigidbody2D script = casern.troopsPlayer1[i].GetComponent<Rigidbody2D>();
                    if (script.constraints != RigidbodyConstraints2D.FreezeAll)
                    {
                        positions.Add(script.transform.position.x - 420f - i * 190);
                    }
                    else
                    {
                        positions.Add(script.transform.position.x - 50f);
                    }
                }
            }
            int range = 10 - positions.Count;
            for(int i=0; i < range; i++)
            {
                do
                {
                    randomNumber = Random.Range(start, end);
                }
                while (positions.Contains(randomNumber));
                positions.Add(randomNumber);
            }
        }
        for (int i = 0; i < positions.Count; i++)
        {
            float precisionShot = Random.Range(-precision, precision) * Random.Range(-500f, 500f);
            print(precisionShot);
            if (precisionShot < 150f)
            {
                precisionShot = 150f;
            }
            else if (precisionShot > 6280f)
            {
                precisionShot = 6280f;
            }
            //print(precisionShot + " precision shot");
            //print(positions[i] + precisionShot + " actual  shot");
            if (id == 1)
            {
                Vector2 newPosition = transform.position + new Vector3(positions[i] + precisionShot, 400f, 0f);
                Instantiate(specialAttack, newPosition, Quaternion.identity);
            }
            else if (id == 2)
            {
                Vector2 newPosition = transform.position + new Vector3(positions[i] + precisionShot, 400f, 0f);
                Instantiate(specialAttack, newPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.6f);
        }
        yield return null;
    }

    public void UpgradeTroopLevel(int troop)
    {
        switch (troop)
        {
            case 1:
                Debug.Log(money + " money " + _troops1UpgradeCosts[troop1Level][0] + " cout " + (money - _troops1UpgradeCosts[troop1Level][0]) + " resultat");
                if(troop1Level < 3 && money >= _troops1UpgradeCosts[troop1Level][0] && age >= _troops1UpgradeCosts[troop1Level][1])
                {
                    AddMoney(-_troops1UpgradeCosts[troop1Level][0]);
                    troop1Level += 1;
                }
                break;

            case 2:
                Debug.Log(money + " money " + _troops2UpgradeCosts[troop2Level][0] + " cout " + (money - _troops2UpgradeCosts[troop2Level][0]) + " resultat");
                if (troop2Level < 3 && money >= _troops2UpgradeCosts[troop2Level][0] && age >= _troops2UpgradeCosts[troop2Level][1])
                {
                    AddMoney(-_troops2UpgradeCosts[troop2Level][0]);
                    troop2Level += 1;
                }
                break;

            case 3:
                Debug.Log(money + " money " + _troops3UpgradeCosts[troop3Level][0] + " cout " + (money - _troops3UpgradeCosts[troop3Level][0]) + " resultat");
                if (troop3Level < 3 && money >= _troops3UpgradeCosts[troop3Level][0] && age >= _troops3UpgradeCosts[troop3Level][1])
                {
                    AddMoney(-_troops3UpgradeCosts[troop3Level][0]);
                    troop3Level += 1;
                }
                break;

            case 4:
                Debug.Log(money + " money " + _troops4UpgradeCosts[troop4Level][0] + " cout " + (money - _troops4UpgradeCosts[troop4Level][0]) + " resultat");
                if (troop4Level < 3 && money >= _troops4UpgradeCosts[troop4Level][0] && age >= _troops4UpgradeCosts[troop4Level][1])
                {
                    AddMoney(-_troops4UpgradeCosts[troop4Level][0]);
                    troop4Level += 1;
                }
                break;
        }
    }

    private void Update()
    {
        textMoney.text = "Money : " + castle.player.GetMoney();
        textXp.text = "XP : " + castle.player.GetXp();
        switch (age)
        {
            case 1:
                precision = 5f;
                break;
            case 2:
                precision = 4f;
                break;
            case 3:
                precision = 3f;
                break;
            case 4:
                precision = 1f;
                break;
            case 5:
                precision = 1f;
                break;
            case 6:
                precision = 0f;
                break;
        }
    }
}