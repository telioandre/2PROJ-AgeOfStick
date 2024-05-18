using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public int id;
    public bool movementAllowed = true;
    public int life;
    public int attack;
    public Player player;
    public int troopLevel;
    public float buildTime;
    public float attackTime;
    public Casern casern;
    public int maxLife;
    public int troopId;
    public string uniqueId;
    /*public Image health;
    public Image background;
    public Image fill;*/


    private List<int> _troop1dropsXp;
    private List<int> _troop2dropsXp;
    private List<int> _troop3dropsXp;
    private List<int> _troop4dropsXp;

    private List<int> _troop1drops;
    private List<int> _troop2drops;
    private List<int> _troop3drops;
    private List<int> _troop4drops;

    private List<int> _troop1dropsRange;
    private List<int> _troop2dropsRange;
    private List<int> _troop3dropsRange;
    private List<int> _troop4dropsRange;

    private void Start()
    {
        _troop1dropsXp = new List<int>() { 190, 200, 210, 220, 230, 240 };
        _troop2dropsXp = new List<int>() { 200, 210, 220, 230, 240, 250 };
        _troop3dropsXp = new List<int>() { 220, 230, 240, 250, 260, 270 };
        _troop4dropsXp = new List<int>() { 250, 260, 270, 280, 290, 300 };

        _troop1drops = new List<int>() { 2, 8, 17, 32, 75, 150 };
        _troop2drops = new List<int>() { 1, 3, 13, 25, 60, 130 };
        _troop3drops = new List<int>() { 4, 9, 19, 34, 85, 175 };
        _troop4drops = new List<int>() { 6, 11, 20, 40, 100, 195 };

        _troop1dropsRange = new List<int>() { 2, 4, 4, 8, 20, 25 };
        _troop2dropsRange = new List<int>() { 1, 4, 4, 10, 20, 30 };
        _troop3dropsRange = new List<int>() { 2, 6, 6, 11, 25, 20 };
        _troop4dropsRange = new List<int>() { 6, 6, 15, 20, 30, 45 };

        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //health.fillAmount = (float)life / maxLife;
        //health.transform.localPosition = rb2d.transform.position;
    }

    //Permet de lancer le mouvement de chaque unité en fonction de leur ID
    void FixedUpdate()
    {
        if (movementAllowed)
        {
            if (id == 1)
            {

                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
            else if (id == 2)
            {
                rb2d.velocity = new Vector2(-(speed), rb2d.velocity.y);
            }
        }
    }

    public int GetId()
    {
        return id;
    }

    public string GetUniqueId()
    {
        return uniqueId;
    }

    //Initialise les paramètres de l'objet prefab
    public void SetPlayer(int playerId, int newTroopId)
    {
        id = playerId;
        troopId = newTroopId;
        uniqueId = System.Guid.NewGuid().ToString();
        char troopName = name[6];
        int troopNumber = int.Parse(troopName.ToString());
        //Debug.Log(name);
        switch (troopNumber)
        {
            case 1:
                troopLevel = player.troop1Level;
                break;

            case 2:
                troopLevel = player.troop2Level;
                break;

            case 3:
                troopLevel = player.troop3Level;
                break;

            case 4:
                troopLevel = player.troop4Level;
                break;
        }
        for (int i = 1; i < player.age; i++)
        {
            life = Mathf.RoundToInt(life * 1.5f);
            speed = Mathf.RoundToInt(speed * 1.1f);
            attack = Mathf.RoundToInt(attack * 1.5f);
            buildTime = Mathf.RoundToInt(buildTime * 1.25f);
            attackTime *= (float)0.9;
        }
        for (int i = 0; i < troopLevel; i++)
        {
            attack = Mathf.RoundToInt(attack * 1.2f);
        }
        maxLife = life;
        if (id == 1)
        {
            transform.position = new Vector2(1500, 0);
        }
        else
        { 
            transform.position = new Vector2(3500, 0);
        }
        Invoke("Endbuild", buildTime);
    }
    private void Endbuild()
    {
        if (id == 1)
        {
            transform.position = new Vector2(50, 600);

        }
        else if (id == 2)
        {
            transform.position = new Vector2(5500, 600);
        }
    }

    public bool SuperEffective(int ally, int enemy)
    {
        if (ally == enemy + 1 || (ally == 4 && enemy == 1))
        {
            return true;
        }
        return false;
    }

    public void DropRewards(int troop, Player ally, Player enemy)
    {
        //Debug.Log(troop + " troop name");

        switch (troop)
        {
            case 1:

                ally.AddMoney(_troop1drops[player.age - 1] + _troop1dropsRange[player.age - 1]);
                ally.AddXp(_troop1dropsXp[player.age - 1]);
                enemy.AddMoney((_troop1drops[player.age - 1] + _troop1dropsRange[player.age - 1]) / 2);
                enemy.AddXp(_troop1dropsXp[player.age - 1] / 2);
                break;

            case 2:

                ally.AddMoney(_troop2drops[player.age - 1] + _troop2dropsRange[player.age - 1]);
                ally.AddXp(_troop2dropsXp[player.age - 1]);
                enemy.AddMoney((_troop2drops[player.age - 1] + _troop2dropsRange[player.age - 1]) / 2);
                enemy.AddXp(_troop2dropsXp[player.age - 1] / 2);
                break;

            case 3:

                ally.AddMoney(_troop3drops[player.age - 1] + _troop3dropsRange[player.age - 1]);
                ally.AddXp(_troop3dropsXp[player.age - 1]);
                enemy.AddMoney((_troop3drops[player.age - 1] + _troop3dropsRange[player.age - 1]) / 2);
                enemy.AddXp(_troop3dropsXp[player.age - 1] / 2);
                break;

            case 4:

                ally.AddMoney(_troop4drops[player.age - 1] + _troop4dropsRange[player.age - 1]);
                ally.AddXp(_troop4dropsXp[player.age - 1]);
                enemy.AddMoney((_troop4drops[player.age - 1] + _troop4dropsRange[player.age - 1]) / 2);
                enemy.AddXp(_troop4dropsXp[player.age - 1] / 2);
                break;
        }

    }

    public IEnumerator AttackPlayer(Movement enemyMovement, Rigidbody2D myRb, Player ally, Player enemy)
    {
        while (enemyMovement.life > 0)
        {
            yield return new WaitForSeconds(attackTime);
            //On divise par 2 car la coroutine se lance 2 fois (1 par objet en contact)
            int damage = attack /*+ random.Next(0, 10)*/;
            //Debug.Log(damage + " damage");
            char allyChar = name[6];
            char enemyChar = enemyMovement.name[6];
            int allyNumber = int.Parse(allyChar.ToString());
            int enemyNumber = int.Parse(enemyChar.ToString());
            
            if (SuperEffective(allyNumber, enemyNumber))
            {
                //Debug.Log("DEGAT AVANT : " + damage);
                damage = Mathf.RoundToInt(damage * 1.5f);
                //Debug.Log("DEGAT APRES : " + damage);
            }
            enemyMovement.life -= damage;
            //life -= damage;
            //enemyMovement.life -= attack / 2 + Random.Range(0, 10);
            if (enemyMovement.life <= 0)
            {
                DropRewards(enemyNumber, ally, enemy);
                enemyMovement.life = 0;
                casern.DestroyTroop(enemyMovement.id, enemyMovement.uniqueId);
                Destroy(enemyMovement.gameObject);
            }
            /*if (life <= 0)
            {
                DropRewards(allyNumber, ally, enemy);
                life = 0;
                casern.DestroyTroop(id, uniqueId);
                Destroy(gameObject);      
            }*/
            myRb.constraints = RigidbodyConstraints2D.None;
        }
    }

        public IEnumerator TroopUnderSpecial(Movement troop, SpecialCollision special, Player otherPlayer)
        {

            char troopChar = troop.name[6];
            int troopNumber = int.Parse(troopChar.ToString());
            int damage;
            //Debug.Log(troop.player.age + " enemy age " + otherPlayer.age + " ally age");
            if (otherPlayer.age == troop.player.age)
            {
                if (troopNumber == 4)
                {
                    damage = troop.maxLife / 2;
                }
                else
                {
                    damage = troop.maxLife;
                }
            }
            else if (otherPlayer.age < troop.player.age)
            {
                if (troopNumber == 4)
                {
                    damage = troop.maxLife / 4;
                }
                else
                {
                    damage = troop.maxLife / 2;
                }

            }
            else
            {
                damage = troop.maxLife;
            }

            //Debug.Log(damage + " damage done by special");
            troop.life -= damage;
            Destroy(special.gameObject);
            if (troop.life <= 0)
            {
                life = 0;
                casern.DestroyTroop(troop.id, troop.uniqueId);
                DropRewards(troopNumber, otherPlayer, troop.player);
                Destroy(troop.gameObject);
            }
            yield return null;
        }
    }