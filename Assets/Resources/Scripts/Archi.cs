using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Archi : MonoBehaviour
{
    public int nbPlacementId1;
    public int nbTowerId1;
    public Castle castle1;
    public List<GameObject> listTurretId1 = new();
    public SpriteRenderer spriteRenderer1Id1;
    public SpriteRenderer spriteRenderer2Id1;
    public SpriteRenderer spriteRenderer3Id1;
    public SpriteRenderer spriteRenderer4Id1;
    public Collider2D collider2D1Id1;
    public Collider2D collider2D2Id1;
    public Collider2D collider2D3Id1;
    public Collider2D collider2D4Id1;

    public int nbPlacementId2;
    public int nbTowerId2;
    public Castle castle2;
    public List<GameObject> listTurretId2 = new();
    public SpriteRenderer spriteRenderer1Id2;
    public SpriteRenderer spriteRenderer2Id2;
    public SpriteRenderer spriteRenderer3Id2;
    public SpriteRenderer spriteRenderer4Id2;
    public Collider2D collider2D1Id2;
    public Collider2D collider2D2Id2;
    public Collider2D collider2D3Id2;
    public Collider2D collider2D4Id2;

    private GameObject _objectToInstantiate;

    public GameObject turretType1Age1;
    public GameObject turretType2Age1;
    public GameObject turretType3Age1;

    public GameObject turretType1Age2;
    public GameObject turretType2Age2;
    public GameObject turretType3Age2;

    public GameObject turretType1Age3;
    public GameObject turretType2Age3;
    public GameObject turretType3Age3;

    public GameObject turretType1Age4;
    public GameObject turretType2Age4;
    public GameObject turretType3Age4;

    public GameObject turretType1Age5;
    public GameObject turretType2Age5;
    public GameObject turretType3Age5;

    public GameObject turretType1Age6;
    public GameObject turretType2Age6;
    public GameObject turretType3Age6;

    private int _typeChoice;
    public int delete;

    public List<int> spotCosts = new() { 20, 50, 120, 200, 0 };
    public List<int> turret1Costs = new() { 25, 150, 300, 400, 500, 600 };
    public List<int> turret2Costs = new() { 50, 200, 300, 400, 500, 600 };
    public List<int> turret3Costs = new() { 75, 200, 300, 400, 500, 600 };
    public List<List<int>> DamageTurret = new()
    {
        new() { 40, 30, 20},
        new() { 60, 45, 30},
        new() { 90, 68, 45},
        new() { 135, 102, 68},
        new() { 203, 152, 102},
        new() { 304, 228, 152}
    };

    public void SwitchToEnabled(int id)
    {
        if (id == 1)
        {
            switch (nbPlacementId1)
            {
                case 1:
                    ToggleSpriteAndCollider(spriteRenderer1Id1, collider2D1Id1);
                    break;
                case 2:
                    ToggleSpriteAndCollider(spriteRenderer1Id1, collider2D1Id1);
                    ToggleSpriteAndCollider(spriteRenderer2Id1, collider2D2Id1);
                    break;
                case 3:
                    ToggleSpriteAndCollider(spriteRenderer1Id1, collider2D1Id1);
                    ToggleSpriteAndCollider(spriteRenderer2Id1, collider2D2Id1);
                    ToggleSpriteAndCollider(spriteRenderer3Id1, collider2D3Id1);
                    break;
                case 4:
                    ToggleSpriteAndCollider(spriteRenderer1Id1, collider2D1Id1);
                    ToggleSpriteAndCollider(spriteRenderer2Id1, collider2D2Id1);
                    ToggleSpriteAndCollider(spriteRenderer3Id1, collider2D3Id1);
                    ToggleSpriteAndCollider(spriteRenderer4Id1, collider2D4Id1);
                    break;
            }
        }
        else if (id == 2)
        {
            switch (nbPlacementId2)
            {
                case 1:
                    ToggleSpriteAndCollider(spriteRenderer1Id2, collider2D1Id2);
                    break;
                case 2:
                    ToggleSpriteAndCollider(spriteRenderer1Id2, collider2D1Id2);
                    ToggleSpriteAndCollider(spriteRenderer2Id2, collider2D2Id2);
                    break;
                case 3:
                    ToggleSpriteAndCollider(spriteRenderer1Id2, collider2D1Id2);
                    ToggleSpriteAndCollider(spriteRenderer2Id2, collider2D2Id2);
                    ToggleSpriteAndCollider(spriteRenderer3Id2, collider2D3Id2);
                    break;
                case 4:
                    ToggleSpriteAndCollider(spriteRenderer1Id2, collider2D1Id2);
                    ToggleSpriteAndCollider(spriteRenderer2Id2, collider2D2Id2);
                    ToggleSpriteAndCollider(spriteRenderer3Id2, collider2D3Id2);
                    ToggleSpriteAndCollider(spriteRenderer4Id2, collider2D4Id2);
                    break;
            }
        }
    }

    private void ToggleSpriteAndCollider(SpriteRenderer spriteRenderer, Collider2D collider)
    {
        if (spriteRenderer != null) spriteRenderer.enabled = !spriteRenderer.enabled;
        if (collider != null) collider.enabled = !collider.enabled;
    }

    public void BuySpot(int id)
    {
        if (id == 1 && nbPlacementId1 < 4 && castle1.player.GetMoney() >= spotCosts[nbPlacementId1])
        {
            castle1.player.AddMoney(-spotCosts[nbPlacementId1]);
            nbPlacementId1 += 1;
        }
        
        else if (id == 2 && nbPlacementId2 < 4 && castle2.player.GetMoney() >= spotCosts[nbPlacementId2])
        {
            castle2.player.AddMoney(-spotCosts[nbPlacementId2]);
            nbPlacementId2 += 1;
        }
        else
        {
            StartCoroutine(castle1.player.MoneyError());
        }
    }

    public void SellSpot(int placement, int id)
    {
        if (id == 1)
        {
            if (listTurretId1[placement - 1] != null)
            {
                Destroy(listTurretId1[placement - 1]);
                listTurretId1[placement - 1] = null;
                nbTowerId1 -= 1;
            }
        }
        else
        {
            if (listTurretId2[placement - 1] != null)
            {
                Destroy(listTurretId2[placement - 1]);
                listTurretId2[placement - 1] = null;
                nbTowerId2 -= 1;
            }
        }
    }

    public int ChoiceType(int type) => _typeChoice = type;

    public void PlaceTurret(int placement, int id, int turret)
    {
        if (turret != 0)
        {
            _typeChoice = turret;
        }

        if (id == 1 && castle1 != null)
        {
            if (castle1.player.GetAge() >= 4)
            {
                // Si l'�ge est 4, mettez � jour le nombre de tours d�j� plac�es en fonction du nombre de tours actuellement pr�sentes
                nbTowerId1 = listTurretId1.Count(obj => obj != null);
            }

            if (nbPlacementId1 >= nbTowerId1)
            {
                HandleTurretPlacement(_typeChoice, placement, castle1, ref nbTowerId1, listTurretId1, id);
            }
        }
        else if (id == 2 && castle2 != null)
        {
            if (castle2.player.GetAge() >= 4)
            {
                // Si l'�ge est 4, mettez � jour le nombre de tours d�j� plac�es en fonction du nombre de tours actuellement pr�sentes
                nbTowerId2 = listTurretId2.Count(obj => obj != null);
            }

            if (nbPlacementId2 >= nbTowerId2)
            {
                HandleTurretPlacement(_typeChoice, placement, castle2, ref nbTowerId2, listTurretId2, id);
            }
        }
    }


    private void HandleTurretPlacement(int type, int placement, Castle castle, ref int nbTowerId, List<GameObject> listTurretId, int id)
    {
        if (castle == null || castle.player == null || listTurretId == null)
        {
            return;
        }

        if (placement <= 0 || placement > listTurretId.Count)
        {
            return;
        }

        int age = castle.player.GetAge();
        int cost = GetTurretCost(type, age);
        int range = GetTurretRange(castle.player.turretRangeLevel);
        float damage = GetTurretDamage(type, age, castle.player.turretDamageLevel);

        if (castle.player.GetMoney() >= cost)
        {
            castle.player.AddMoney(-cost);
            nbTowerId++;

            GameObject turretPrefab = GetTurretPrefab(type, age);
            if (turretPrefab == null)
            {
                return;
            }

            GameObject newTurret = Instantiate(turretPrefab, transform.position, Quaternion.identity);
            Turret turretScript = newTurret.GetComponent<Turret>();
            if (turretScript == null)
            {
                return;
            }

            turretScript.Initialize(placement, castle.id, range, damage);
            turretScript.SetPosition(castle.id);

            if (listTurretId[placement - 1] != null)
            {
                SellSpot(placement, id);
                castle.player.AddMoney(cost / 2);
            }

            listTurretId[placement - 1] = newTurret;
        }
        else
        {
            StartCoroutine(castle.player.MoneyError());
        }
    }



    private int GetTurretCost(int type, int age)
    {
        return type switch
        {
            1 => turret1Costs[age - 1],
            2 => turret2Costs[age - 1],
            3 => turret3Costs[age - 1],
            _ => 0
        };
    }

    private int GetTurretRange(int turretLevelRange)
    {
        return turretLevelRange switch
        {
            1 => 1200,
            2 => 1400,
            3 => 1600,
            _ => 1000
        };
    }

    private float GetTurretDamage(int type, int age, int turretDamageUp)
    {
        float baseDamage = DamageTurret[age - 1][type - 1];
        return turretDamageUp switch
        {
            1 => baseDamage * 1.2f,
            2 => baseDamage * 1.4f,
            3 => baseDamage * 1.6f,
            _ => baseDamage
        };
    }

    private GameObject GetTurretPrefab(int type, int age)
    {
        return (type, age) switch
        {
            (1, 1) => turretType1Age1,
            (2, 1) => turretType2Age1,
            (3, 1) => turretType3Age1,
            (1, 2) => turretType1Age2,
            (2, 2) => turretType2Age2,
            (3, 2) => turretType3Age2,
            (1, 3) => turretType1Age3,
            (2, 3) => turretType2Age3,
            (3, 3) => turretType3Age3,
            (1, 4) => turretType1Age4,
            (2, 4) => turretType2Age4,
            (3, 4) => turretType3Age4,
            (1, 5) => turretType1Age5,
            (2, 5) => turretType2Age5,
            (3, 5) => turretType3Age5,
            (1, 6) => turretType1Age6,
            (2, 6) => turretType2Age6,
            (3, 6) => turretType3Age6,
            _ => null
        };
    }
}