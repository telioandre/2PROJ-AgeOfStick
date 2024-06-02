using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    private int _xp;
    private int _money;
    private int _age = 1;
    public Castle castle;
    public Casern casern;
    public Ia ia;
    public Archi archi;
    public string baseName;
    public TextMeshProUGUI textMoney;
    public TextMeshProUGUI textXp;

    public TextMeshProUGUI textPriceTroop1;
    public TextMeshProUGUI textPriceTroop2;
    public TextMeshProUGUI textPriceTroop3;
    public TextMeshProUGUI textPriceTroop4;
    public TextMeshProUGUI textPriceTroop1Info;
    public TextMeshProUGUI textPriceTroop2Info;
    public TextMeshProUGUI textPriceTroop3Info;
    public TextMeshProUGUI textPriceTroop4Info;
    public TextMeshProUGUI textPriceTurret1;
    public TextMeshProUGUI textPriceTurret2;
    public TextMeshProUGUI textPriceTurret3;
    public TextMeshProUGUI textPriceTurret1Info;
    public TextMeshProUGUI textPriceTurret2Info;
    public TextMeshProUGUI textPriceTurret3Info;
    public TextMeshProUGUI textPriceBuySpot;
    public TextMeshProUGUI textPriceUpgradeTroop1;
    public TextMeshProUGUI textPriceUpgradeTroop2;
    public TextMeshProUGUI textPriceUpgradeTroop3;
    public TextMeshProUGUI textPriceUpgradeTroop4;
    public TextMeshProUGUI textPriceUpgradeTurretRange;
    public TextMeshProUGUI textPriceUpgradeTurretDamage;
    public TextMeshProUGUI textPriceUpgradeAge;

    public Sprite[] ageSprites = { };
    public List<Sprite> attackSpecialSprite = new();
    public Button specialAttackButton;
    public Image specialAttackImage;
    public List<Sprite> troop1Sprite = new();
    public Button troop1Button;
    public Image troop1Image;
    public List<Sprite> troop2Sprite = new();
    public Button troop2Button;
    public Image troop2Image;
    public List<Sprite> troop3Sprite = new();
    public Button troop3Button;
    public Image troop3Image;
    public List<Sprite> troop4Sprite = new();
    public Button troop4Button;
    public Image troop4Image;
    public GameObject troop5ButtonUnlock;
    public GameObject troop5ButtonUnlockInfo;
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
    public Image turret1Image;
    public List<Sprite> turret2Sprite = new();
    public Button turret2Button;
    public Image turret2Image;
    public List<Sprite> turret3Sprite = new();
    public Button turret3Button;
    public Image turret3Image;
    public List<Sprite> turretRangeSprite = new();
    public Button turretRangeButton;
    public Image turretRangeImage;
    public List<Sprite> turretDamageSprite = new();
    public Button turretDamageButton;
    public Image turretDamageImage;
    public List<GameObject> specialAttack;
    public List<int> specialCosts;
    public List<int> ageCosts;
    
    public int troop1Level;
    public int troop2Level;
    public int troop3Level;
    public int troop4Level;
    
    public int numberOfTroop;

    public int turretRangeLevel;
    public int turretDamageLevel;

    private float _precision;
    private readonly float _specialCooldown = 20f;
    private float _lastPlayerSpecial;

    private readonly float _moneyCooldown = 7f;
    private float _previousMoneyDrop;

    readonly List<List<int>> _troops1UpgradeCosts = new()
    {
        new() { 30, 1 },
        new() { 80, 2 },
        new() { 190, 4 },
    };
    readonly List<List<int>> _troops2UpgradeCosts = new()
    {
        new() { 20, 1 },
        new() { 50, 1 },
        new() { 110, 3 },
    };
    readonly List<List<int>> _troops3UpgradeCosts = new()
    {
        new() { 80, 2 },
        new() { 120, 3 },
        new() { 210, 5 },
    };
    readonly List<List<int>> _troops4UpgradeCosts = new()
    {
        new() { 100, 2 },
        new() { 210, 4 },
        new() { 280, 5 }
    };
    readonly List<List<int>> _turretRangeUpgradeCosts = new()
    {
        new() { 100, 2 },
        new() { 200, 4 },
        new() { 270, 6 }
    };
    readonly List<List<int>> _turretDamageUpgradeCosts = new()
    {
        new() { 30, 1 },
        new() { 150, 3 },
        new() { 230, 5 }
    };

    public GameObject moneyError;
    public GameObject xpError;
    public GameObject troopsError;
    public GameObject ageError;

    /*
     * This start method will set the age, money and xp for each player.
     * It also initializes the costs for the special, the costs for the age upgrades and finally the cooldown for the special.
     */
    private void Start()
    {
        SetAge(1);
        AddMoney(10);
        AddXp(1000);
        
        specialCosts = new List<int> { 2300, 2900, 3000, 3800, 4200, 5800 };
        ageCosts = new List<int> { 6500, 8000, 9500, 11000, 12500 };

        _lastPlayerSpecial = -_specialCooldown;
    }

    /*
     * Coroutine to display a money error.
     */
    public IEnumerator MoneyError()
    {
        moneyError.SetActive(true);
        yield return new WaitForSeconds(1f);
        moneyError.SetActive(false);
    }
    
    /*
     * Coroutine to display a XP error.
     */
    public IEnumerator XpError()
    {
        xpError.SetActive(true);
        yield return new WaitForSeconds(1f);
        xpError.SetActive(false);
    }
    
    /*
     * Coroutine to display a number of troops error.
     */
    public IEnumerator TroopsError()
    {
        troopsError.SetActive(true);
        yield return new WaitForSeconds(1f);
        troopsError.SetActive(false);
    }
    
    /*
     * Coroutine to display a age error.
     */
    public IEnumerator AgeError()
    {
        ageError.SetActive(true);
        yield return new WaitForSeconds(1f);
        ageError.SetActive(false);
    }
    
    
    /*
     * Method to change the current XP of the player.
     */
    public void AddXp(int newXp)
    {
        _xp += newXp;
    }
    
    /*
     * Method to get the current XP of the player.
     */
    public int GetXp()
    {
        return _xp;
    }

    /*
     * Method to set a new amount of XP.
     */
    public void SetXp(int newXp)
    {
        _xp = newXp;
    }

    /*
     * Method to change the current money of the player.
     */
    public void AddMoney(int newMoney)
    {
        _money += newMoney;
    }
    
    /*
     * Method to get the current XP of the player.
     */
    public int GetMoney()
    {
        return _money;
    }
    
    /*
     * Method to set a new amount of money.
     */
    public void SetMoney(int newMoney)
    {
        _money = newMoney;
    }

    /*
     * Method to initialize the age of the player.
     */
    public void SetAge(int newAge)
    {
        _age = newAge;
    }
    
    /*
     * Method to get the current age of the player.
     */
    public int GetAge()
    {
        return _age;
    }

    /*
     * This method will verify if the player can upgrade his age, then buff the castle's life points and change different sprites and images.
     */
    public void AgeUp()
    {
        if (_age < 6)
        {
            if (_xp < ageCosts[_age - 1])
            {
                StartCoroutine(XpError());
            }
            else
            {
                _xp -= ageCosts[_age - 1];
                _age += 1;
                castle.AddLifePoint(Mathf.RoundToInt(castle.lifePoint * 1.35f));
                castle.AddMaxLifePoint(Mathf.RoundToInt(castle.maxLifePoint * 1.35f));
                
                SpriteRenderer sprite = GetComponent<SpriteRenderer>(); 
                sprite.sprite = ageSprites[_age - 1];
                specialAttackButton.image.sprite = attackSpecialSprite[_age - 1];
                troop1Button.image.sprite = troop1Sprite[_age - 1];
                troop1Image.sprite = troop1Sprite[_age - 1];
                troop2Button.image.sprite = troop2Sprite[_age - 1];
                troop2Image.sprite = troop2Sprite[_age - 1];
                troop3Button.image.sprite = troop3Sprite[_age - 1];
                troop3Image.sprite = troop3Sprite[_age - 1];
                troop4Button.image.sprite = troop4Sprite[_age - 1];
                troop4Image.sprite = troop4Sprite[_age - 1];
                troop1UpgradeButton.image.sprite = troop1UpgradeSprite[_age + troop1Level * 6 - 1];
                troop2UpgradeButton.image.sprite = troop2UpgradeSprite[_age + troop2Level * 6 - 1];
                troop3UpgradeButton.image.sprite = troop3UpgradeSprite[_age + troop3Level * 6 - 1];
                troop4UpgradeButton.image.sprite = troop4UpgradeSprite[_age + troop4Level * 6 - 1];
                turret1Button.image.sprite = turret1Sprite[_age - 1];
                turret1Image.sprite = turret1Sprite[_age - 1];
                turret2Button.image.sprite = turret2Sprite[_age - 1];
                turret2Image.sprite = turret2Sprite[_age - 1];
                turret3Button.image.sprite = turret3Sprite[_age - 1];
                turret3Image.sprite = turret3Sprite[_age - 1];
                

                if (_age == 6)
                {
                    troop5ButtonUnlock.SetActive(true);
                }
            }
        }
    }

    /*
     * This method permit to unlock the ultimate troop.
     */
    public void UnlockTroop5()
    {
        if (_money >= 500)
        {
            AddMoney(-500);
            troop5Button.SetActive(true);
            troop5ButtonUnlock.SetActive(false);
            troop5ButtonUnlockInfo.SetActive(false);
        }
        else
        {
            StartCoroutine(MoneyError());
        }
    }
    
    /*
     * This method will return a boolean if the user is able to launch a special based on his cooldown.
     */
    public bool CheckCooldown()
    {
        if (Time.time - _lastPlayerSpecial > _specialCooldown + (_age - 1) * 5)
        {
            return true;
        }
        return false;
    }

    /*
     * This method will verify and launch the special attack.
     */
    public void SpecialAttack(int id)
    {
        if (CheckCooldown())
        {
            int cost = specialCosts[_age - 1];
            if (GetXp() >= cost)
            {
                _lastPlayerSpecial = Time.time;
                AddXp(-cost);
                StartCoroutine(SpecialAttackCoroutine(id));
            }
            else
            {
                StartCoroutine(XpError());
            }
        }
    }

    /*
     * Coroutine to launch the different parts of the special attack.
     * The precision on it will depend on the current age.
     */
    public IEnumerator SpecialAttackCoroutine(int id)
    {
        List<float> positions = new();
        int randomNumber;
        int start = Mathf.RoundToInt(300f);
        int end = Mathf.RoundToInt(4300f);
        if (id == 1)
        {
            if (casern.troopsPlayer2.Count > 0)
            {
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
            float precisionShot = Random.Range(-_precision, _precision) * Random.Range(-500, 500);
            if (id == 1)
            {
                float realShot = positions[i] + precisionShot;
                if (realShot > end)
                {
                    realShot = end;
                }
                else if (realShot < start)
                {
                    realShot = start;
                }
                Vector2 newPosition = transform.position + new Vector3(realShot, 400f, 0f);
                Instantiate(specialAttack[_age-1], newPosition, Quaternion.identity);
            }
            else if (id == 2)
            {
                float realShot = positions[i] + precisionShot;
                if (realShot > end)
                {
                    realShot = end;
                }
                else if (realShot < start)
                {
                    realShot = start;
                }
                Vector2 newPosition = transform.position + new Vector3(-realShot, 400f, 0f);
                Instantiate(specialAttack[_age-1], newPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.6f);
        }
        yield return null;
    }

    /*
     * This method is used to upgrade the range or the damage of every turret.
     */
    public void UpgradeTurret(int upgrade)
    {
        switch (upgrade)
        {
            case 1:
                if (turretRangeLevel <= 3)
                {
                    if (_money >= _turretRangeUpgradeCosts[turretRangeLevel][0])
                    {
                        if (_age >= _turretRangeUpgradeCosts[turretRangeLevel][1])
                        {
                            AddMoney(-_turretRangeUpgradeCosts[turretRangeLevel][0]);
                            turretRangeLevel += 1;
                            turretRangeButton.image.sprite = turretRangeSprite[turretRangeLevel];
                            
                        }
                        else
                        {
                            StartCoroutine(AgeError());
                        }
                    }
                    else
                    {
                        StartCoroutine(MoneyError());
                    }
                }
                break;

            case 2:
                if (turretDamageLevel <= 3)
                {
                    if (_money >= _turretDamageUpgradeCosts[turretDamageLevel][0])
                    {
                        if (_age >= _turretDamageUpgradeCosts[turretDamageLevel][1])
                        {
                            AddMoney(-_turretDamageUpgradeCosts[turretDamageLevel][0]);
                            turretDamageLevel += 1;
                            turretDamageButton.image.sprite = turretDamageSprite[turretDamageLevel];
                        }
                        else
                        {
                            StartCoroutine(AgeError());
                        }
                    }
                    else
                    {
                        StartCoroutine(MoneyError());
                    }
                }
                break;
        }
    }
    
    /*
     * This method is used to upgrade the selected troop.
     */
    public void UpgradeTroopLevel(int troop)
    {
        switch (troop)
        {
            case 1:
                if(troop1Level < 3 && _money >= _troops1UpgradeCosts[troop1Level][0])
                {
                    if (_age >= _troops1UpgradeCosts[troop1Level][1])
                    {

                        AddMoney(-_troops1UpgradeCosts[troop1Level][0]);
                        troop1Level += 1;
                        int imageIndex = _age + troop1Level * 6 - 1;
                        print(imageIndex);
                        if (imageIndex > 18)
                        {
                            imageIndex = 18;
                        }

                        troop1UpgradeButton.image.sprite = troop1UpgradeSprite[imageIndex];
                    }
                    else
                    {
                        StartCoroutine(AgeError());
                    }
                }
                else
                {
                    StartCoroutine(MoneyError());
                }
                break;

            case 2:
                if (troop2Level < 3 && _money >= _troops2UpgradeCosts[troop2Level][0])
                {
                    if (_age >= _troops2UpgradeCosts[troop2Level][1])
                    {
                        AddMoney(-_troops2UpgradeCosts[troop2Level][0]);
                        troop2Level += 1;
                        int imageIndex = _age + troop2Level * 6 - 1;
                        print(imageIndex);
                        if (imageIndex > 18)
                        {
                            imageIndex = 18;
                        }
                        troop2UpgradeButton.image.sprite = troop2UpgradeSprite[imageIndex];
                    }
                    else
                    {
                        StartCoroutine(AgeError());
                    }
                }
                else
                {
                    StartCoroutine(MoneyError());
                }
                break;

            case 3:
                if (troop3Level < 3 && _money >= _troops3UpgradeCosts[troop3Level][0])
                {
                    if (_age >= _troops3UpgradeCosts[troop3Level][1])
                    {
                        AddMoney(-_troops3UpgradeCosts[troop3Level][0]);
                        troop3Level += 1;
                        int imageIndex = _age + troop3Level * 6 - 1;
                        print(imageIndex);
                        if (imageIndex > 18)
                        {
                            imageIndex = 18;
                        }
                        troop3UpgradeButton.image.sprite = troop3UpgradeSprite[imageIndex];
                    }
                    else
                    {
                        StartCoroutine(AgeError());
                    }
                }
                else
                {
                    StartCoroutine(MoneyError());
                }
                break;

            case 4:
                if (troop4Level < 3 && _money >= _troops4UpgradeCosts[troop4Level][0])
                {
                    if (_age >= _troops4UpgradeCosts[troop4Level][1])
                    {
                        AddMoney(-_troops4UpgradeCosts[troop4Level][0]);
                        troop4Level += 1;
                        int imageIndex = _age + troop4Level * 6 - 1;
                        print(imageIndex);
                        if (imageIndex > 18)
                        {
                            imageIndex = 18;
                        }
                        troop4UpgradeButton.image.sprite = troop4UpgradeSprite[imageIndex];
                    }
                    else
                    {
                        StartCoroutine(AgeError());
                    }
                }
                else
                {
                    StartCoroutine(MoneyError());
                }
                break;
        }
    }

    /*
     * This update method is used to dynamically show the remaining cooldown of the special attack.
     * It also show dynamically the current amount of money, XP, and every prices for troops or turrets.
     * The precision for the special attack is set here, based on the current age.
     */
    private void Update()
    {
        if (Time.time - _lastPlayerSpecial > _specialCooldown + (_age - 1) * 5)
        {
            specialAttackImage.fillAmount = 1f;
        }
        else
        {
            specialAttackImage.fillAmount = (Time.time - _lastPlayerSpecial) / (_specialCooldown + (_age - 1) * 5);
        }
        _previousMoneyDrop += Time.deltaTime;
        if (_previousMoneyDrop >= _moneyCooldown)
        {
            AddMoney(1);
            if (castle.id == 2 && ia.GetDifficulty() == "Impossible")
            {
                AddMoney(1);
            }
            _previousMoneyDrop = 0f;
        }
        
        textMoney.text = "Money : " + castle.player.GetMoney();
        textXp.text = "XP : " + castle.player.GetXp();
        textPriceTroop1.text = "" + casern.troop1Costs[_age-1];
        textPriceTroop2.text = "" + casern.troop2Costs[_age-1];
        textPriceTroop3.text = "" + casern.troop3Costs[_age-1];
        textPriceTroop4.text = "" + casern.troop4Costs[_age-1];
        textPriceTroop1Info.text = "" + casern.troop1Costs[_age-1];
        textPriceTroop2Info.text = "" + casern.troop2Costs[_age-1];
        textPriceTroop3Info.text = "" + casern.troop3Costs[_age-1];
        textPriceTroop4Info.text = "" + casern.troop4Costs[_age-1];
        textPriceTurret1.text = "" + archi.turret1Costs[_age - 1];
        textPriceTurret2.text = "" + archi.turret2Costs[_age - 1];
        textPriceTurret3.text = "" + archi.turret3Costs[_age - 1];
        textPriceTurret1Info.text = "" + archi.turret1Costs[_age - 1];
        textPriceTurret2Info.text = "" + archi.turret2Costs[_age - 1];
        textPriceTurret3Info.text = "" + archi.turret3Costs[_age - 1];
        if (troop1Level < 3)
        {
            textPriceUpgradeTroop1.text = "" + _troops1UpgradeCosts[troop1Level][0];
        }
        else
        {
            textPriceUpgradeTroop1.text = "MAX";
        }

        if (troop2Level < 3)
        {
            textPriceUpgradeTroop2.text = "" + _troops2UpgradeCosts[troop2Level][0];
        }
        else
        {
            textPriceUpgradeTroop2.text = "MAX";
        }
        if (troop3Level < 3)
        {
            textPriceUpgradeTroop3.text = "" + _troops3UpgradeCosts[troop3Level][0];
        }
        else
        {
            textPriceUpgradeTroop3.text = "MAX";
        }
        if (troop4Level < 3)
        {
            textPriceUpgradeTroop4.text = "" + _troops4UpgradeCosts[troop4Level][0];
        }
        else
        {
            textPriceUpgradeTroop4.text = "MAX";
        }

        if (turretRangeLevel < 3)
        {
            textPriceUpgradeTurretRange.text = "" + _turretRangeUpgradeCosts[turretRangeLevel][0];
        }
        if (turretDamageLevel < 3)
        {
            textPriceUpgradeTurretDamage.text = "" + _turretDamageUpgradeCosts[turretDamageLevel][0];
        }
        if (_age < 6)
        {
            textPriceUpgradeAge.text = "" + ageCosts[_age-1];
        }
        else
        {
            textPriceUpgradeAge.text = "MAX";
        }
        if (castle.id == 1)
        {
            if (archi.nbPlacementId1 < 4)
            {
                textPriceBuySpot.text = "" + archi.spotCosts[archi.nbPlacementId1];
            }
            else
            {
                textPriceBuySpot.text = "MAX";
            }
        }
        else
        {
            if (archi.nbPlacementId2 < 4)
            {
                textPriceBuySpot.text = "" + archi.spotCosts[archi.nbPlacementId2];
            }
            else
            {
                textPriceBuySpot.text = "MAX";
            }
        }
        
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
