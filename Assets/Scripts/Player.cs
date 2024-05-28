using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    private int _xp;
    private int _money;
    private int _age = 1;
    public Castle castle;
    public Casern casern;
    public string baseName;
    public TextMeshProUGUI textMoney;
    public TextMeshProUGUI textXp;
    public Sprite[] ageSprites = {};
    public Scale[] ageScale = {};
    public List<Sprite> attackSpecialSprite = new();
    public Button specialAttackButton;
    public List<Sprite> troop1Sprite = new();
    public Button troop1Button;
    //public Image troop1Image;
    public List<Sprite> troop2Sprite = new();
    public Button troop2Button;
    //public Image troop2Image;
    public List<Sprite> troop3Sprite = new();
    public Button troop3Button;
    //public Image troop3Image;
    public List<Sprite> troop4Sprite = new();
    public Button troop4Button;
    //public Image troop4Image;
    public GameObject troop5Button;
    public List<Sprite> troop1UpgradeSprite = new();
    public Button troop1UpgradeButton;
    public List<Sprite> troop2UpgradeSprite = new();
    public Button troop2UpgradeButton;
    public List<Sprite> troop3UpgradeSprite = new();
    public Button troop3UpgradeButton;
    public List<Sprite> troop4UpgradeSprite = new();
    public Button troop4UpgradeButton;
    public List<Sprite> turret1Sprite = new();
    public Button turret1Button;
    //public Image turret1Image;
    public List<Sprite> turret2Sprite = new();
    public Button turret2Button;
    //public Image turret2Image;
    public List<Sprite> turret3Sprite = new();
    public Button turret3Button;
    //public Image turret3Image;
    public GameObject specialAttack;
    public List<int> specialCosts;
    public List<int> ageCosts;
    public int troop1Level;
    public int troop2Level;
    public int troop3Level;
    public int troop4Level;
    public int numberOfTroop;
    private float _precision;
    private float _specialCooldown = 20f;
    private float _lastPlayer1Special;
    private float _lastPlayer2Special;
    List<List<int>> _troops1UpgradeCosts = new()
    {
        new() { 30, 1 },
        new() { 80, 2 },
        new() { 190, 4 },
    };
    List<List<int>> _troops2UpgradeCosts = new()
    {
        new() { 20, 1 },
        new() { 50, 1 },
        new() { 110, 3 },
    };
    List<List<int>> _troops3UpgradeCosts = new()
    {
        new() { 80, 2 },
        new() { 120, 3 },
        new() { 210, 5 },
    };
    List<List<int>> _troops4UpgradeCosts = new()
    {
        new() { 100, 2 },
        new() { 210, 4 },
        new() { 280, 5 }
    };

    private void Start()
    {
        SetAge(1);
        AddMoney(1000);
        AddXp(100000);
        
        specialCosts = new List<int> { 2300, 2900, 3000, 3800, 4200, 5800 };
        ageCosts = new List<int> { 6500, 8000, 9500, 11000, 12500 };

        _lastPlayer1Special = -_specialCooldown;
        _lastPlayer2Special = -_specialCooldown;
    }
    public void AddXp(int newXp)
    {
        _xp += newXp;
        //Debug.Log("xp = " + xp);
    }

    public void SuppXp(int newXp)
    {
        _xp -= newXp;
        //Debug.Log("xp = " + xp);
    }

    public int GetXp()
    {
        return _xp;
    }

    public void AddMoney(int newMoney)
    {
        _money += newMoney;
        //Debug.Log("money = " + money);
    }

    public void SuppMoney(int newMoney)
    {
        _money -= newMoney;
        if (_money < 0)
        {
            _money = 0;
        }
        //Debug.Log("money = " + money);
    }

    public int GetMoney()
    {
        return _money;
    }

    public void SetAge(int newAge)
    {
        _age = newAge;
    }

    public void AgeUp()
    {
        if (_age < 6)
        {
            if (_xp < ageCosts[_age - 1])
            {
                //Debug.Log("XP insufisant ! Manque : " + (ageCosts[age - 1] - xp));
            }
            else
            {
                _xp -= ageCosts[_age - 1];
                _age += 1;
                castle.AddLifePoint(Mathf.RoundToInt(castle.lifePoint * 1.35f));
                castle.AddMaxLifePoint(Mathf.RoundToInt(castle.maxLifePoint * 1.35f));
                SpriteRenderer spriteColor = GetComponent<SpriteRenderer>();
                spriteColor.sprite = ageSprites[_age - 1];
                specialAttackButton.image.sprite = attackSpecialSprite[_age - 1];
                troop1Button.image.sprite = troop1Sprite[_age - 1];
                //troop1Image.sprite = troop1Sprite[_age - 1];
                troop2Button.image.sprite = troop2Sprite[_age - 1];
                //troop2Image.sprite = troop2Sprite[_age - 1];
                troop3Button.image.sprite = troop3Sprite[_age - 1];
                //troop3Image.sprite = troop3Sprite[_age - 1];
                troop4Button.image.sprite = troop4Sprite[_age - 1];
                //troop4Image.sprite = troop4Sprite[_age - 1];
                troop1UpgradeButton.image.sprite = troop1UpgradeSprite[_age + troop1Level * 6 - 1];
                troop2UpgradeButton.image.sprite = troop2UpgradeSprite[_age + troop2Level * 6 - 1];
                troop3UpgradeButton.image.sprite = troop3UpgradeSprite[_age + troop3Level * 6 - 1];
                troop4UpgradeButton.image.sprite = troop4UpgradeSprite[_age + troop4Level * 6 - 1];
                turret1Button.image.sprite = turret1Sprite[_age - 1];
                //turret1Image.sprite = turret1Sprite[_age - 1];
                turret2Button.image.sprite = turret2Sprite[_age - 1];
                //turret2Image.sprite = turret2Sprite[_age - 1];
                turret3Button.image.sprite = turret3Sprite[_age - 1];
                //turret3Image.sprite = turret3Sprite[_age - 1];

                if (_age == 6)
                {
                    troop5Button.SetActive(true);
                }
            }
        }
        else
        {
            Debug.Log("Max age reached");
        }
    }

    public int GetAge()
    {
        return _age;
    }
    public bool CheckCooldown(int id)
    {
        if (id == 1 && Time.time - _lastPlayer1Special > _specialCooldown + ((_age - 1) * 5))
        {
            _lastPlayer1Special = Time.time;
            return true;
        }
        if (id == 2 && Time.time - _lastPlayer2Special > _specialCooldown + ((_age - 1) * 5))
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
            int cost = specialCosts[_age - 1];
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
            float precisionShot = Random.Range(-_precision, _precision) * Random.Range(-500f, 500f);
            //print(precisionShot);
            if (precisionShot < 150f)
            {
                precisionShot = 150f;
            }
            else if (precisionShot > 6280f)
            {
                precisionShot = 6280f;
            }
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
                if(troop1Level < 3 && _money >= _troops1UpgradeCosts[troop1Level][0] && _age >= _troops1UpgradeCosts[troop1Level][1])
                {
                    AddMoney(-_troops1UpgradeCosts[troop1Level][0]);
                    troop1Level += 1;
                    troop1UpgradeButton.image.sprite = troop1UpgradeSprite[_age + troop1Level * 6 - 1];
                }
                break;

            case 2:
                if (troop2Level < 3 && _money >= _troops2UpgradeCosts[troop2Level][0] && _age >= _troops2UpgradeCosts[troop2Level][1])
                {
                    AddMoney(-_troops2UpgradeCosts[troop2Level][0]);
                    troop2Level += 1;
                    troop2UpgradeButton.image.sprite = troop2UpgradeSprite[_age + troop2Level * 6 - 1];
                }
                break;

            case 3:
                if (troop3Level < 3 && _money >= _troops3UpgradeCosts[troop3Level][0] && _age >= _troops3UpgradeCosts[troop3Level][1])
                {
                    AddMoney(-_troops3UpgradeCosts[troop3Level][0]);
                    troop3Level += 1;
                    troop3UpgradeButton.image.sprite = troop3UpgradeSprite[_age + troop3Level * 6 - 1];
                }
                break;

            case 4:
                if (troop4Level < 3 && _money >= _troops4UpgradeCosts[troop4Level][0] && _age >= _troops4UpgradeCosts[troop4Level][1])
                {
                    AddMoney(-_troops4UpgradeCosts[troop4Level][0]);
                    troop4Level += 1;
                    troop4UpgradeButton.image.sprite = troop4UpgradeSprite[_age + troop4Level * 6 - 1];
                }
                break;
        }
    }

    private void Update()
    {
        textMoney.text = "Money : " + castle.player.GetMoney();
        textXp.text = "XP : " + castle.player.GetXp();
        switch (_age)
        {
            case 1:
                _precision = 5f;
                break;
            case 2:
                _precision = 4f;
                break;
            case 3:
                _precision = 3f;
                break;
            case 4:
                _precision = 1f;
                break;
            case 5:
                _precision = 1f;
                break;
            case 6:
                _precision = 0f;
                break;
        }
    }
}