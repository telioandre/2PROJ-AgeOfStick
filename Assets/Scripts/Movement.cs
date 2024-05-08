using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float speed;
    public int ID;
    public bool movementAllowed = true;
    public int life;
    public int maxLife;
    public int attack;
    public int troopLevel;
    public float buildTime;
    public float attackTime;
    public Player player;
    public Casern casern;
    /*public Image health;
    public Image background;
    public Image fill;*/


    private List<int> troop1dropsXp;
    private List<int> troop2dropsXp;
    private List<int> troop3dropsXp;
    private List<int> troop4dropsXp;

    private List<int> troop1drops;
    private List<int> troop2drops;
    private List<int> troop3drops;
    private List<int> troop4drops;

    private List<int> troop1dropsRange;
    private List<int> troop2dropsRange;
    private List<int> troop3dropsRange;
    private List<int> troop4dropsRange;

    private System.Random random = new System.Random();
    void Start()
    {
        troop1dropsXp = new List<int>() { 190, 200, 210, 220, 230, 240 };
        troop2dropsXp = new List<int>() { 200, 210, 220, 230, 240, 250 };
        troop3dropsXp = new List<int>() { 220, 230, 240, 250, 260, 270 };
        troop4dropsXp = new List<int>() { 250, 260, 270, 280, 290, 300 };

        troop1drops = new List<int>() { 2, 8, 17, 32, 75, 150 };
        troop2drops = new List<int>() { 1, 3, 13, 25, 60, 130 };
        troop3drops = new List<int>() { 4, 9, 19, 34, 85, 175 };
        troop4drops = new List<int>() { 6, 11, 20, 40, 100, 195 };

        troop1dropsRange = new List<int>() { 2, 4, 4, 8, 20, 25 };
        troop2dropsRange = new List<int>() { 1, 4, 4, 10, 20, 30 };
        troop3dropsRange = new List<int>() { 2, 6, 6, 11, 25, 20 };
        troop4dropsRange = new List<int>() { 6, 6, 15, 20, 30, 45 };

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
            if (ID == 1)
            {

                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
            else if (ID == 2)
            {
                rb2d.velocity = new Vector2(-(speed), rb2d.velocity.y);
            }
        }
    }

    public int getId()
    {
        return ID;
    }

    //Initialise les paramètres de l'objet prefab
    public void setPlayer(int playerId)
    {
        ID = playerId;
        char troopName = name[6];
        int troopNumber = int.Parse(troopName.ToString());
        Debug.Log(name);
        switch(troopNumber)
        {
            case 1:
                troopLevel = player.troop1level;
                break;
                
            case 2:
                troopLevel = player.troop2level;
                break;
                
            case 3:
                troopLevel = player.troop3level;
                break;
                
            case 4:
                troopLevel = player.troop4level;
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
        for(int i = 0; i < troopLevel; i++)
        {
            attack = Mathf.RoundToInt(attack * 1.2f);
        }
        maxLife = life;
        transform.position = new Vector2(3500, 0);
        Invoke("Endbuild", buildTime);
    }
    private void Endbuild()
    {
        if (ID == 1)
        {
            transform.position = new Vector2(50, 600);
        }
        else if (ID == 2)
        {
            transform.position = new Vector2(5500, 600);
        }
    }

    public IEnumerator attackPlayer(Movement Enemy, Rigidbody2D myRb, Player ally, Player enemy)
    {
        yield return new WaitForSeconds(attackTime);
        while (life > 0 && Enemy != null && Enemy.life > 0)
        {
            //On divise par 2 car la coroutine se lance 2 fois (1 par objet en contact)
            int damage = Enemy.attack / 2 + random.Next(0, 10);
            char allyChar = name[6];
            char enemyChar = Enemy.name[6];
            int allyNumber = int.Parse(allyChar.ToString());
            int enemyNumber = int.Parse(enemyChar.ToString());

            if (superEffective(allyNumber, enemyNumber))
            {
                damage = Mathf.RoundToInt(damage * 1.5f);
            }
            life -= damage;
            Enemy.life -= attack/2 + random.Next(0, 10); ;
            if (Enemy.life <= 0)
            {
                dropRewards(enemyNumber, ally, enemy);
                Enemy.life = 0;
                casern.DestroyTroop(Enemy.ID);
                Destroy(Enemy.gameObject);
            }
            if(life <= 0)
            {
                dropRewards(allyNumber, ally, enemy);
                life = 0;
                casern.DestroyTroop(Enemy.ID);
                Destroy(gameObject);
            }
        }

        myRb.constraints = RigidbodyConstraints2D.None;
    }

    public bool superEffective(int ally, int enemy)
    {
        if(ally == enemy + 1 || (ally == 1 && enemy == 4))
        {
            return true;
        }
        return false;
    }

    public void dropRewards(int troop, Player ally, Player enemy)
    {
        switch (troop)
        {
            case 1:

                ally.AddMoney(troop1drops[player.age - 1] + troop1dropsRange[player.age - 1]);
                ally.AddXp(troop1dropsXp[player.age-1]);
                enemy.AddMoney((troop1drops[player.age - 1] + troop1dropsRange[player.age - 1]) / 2);
                enemy.AddXp(troop1dropsXp[player.age - 1] / 2);
                break;

            case 2:

                ally.AddMoney(troop2drops[player.age - 1] + troop2dropsRange[player.age - 1]);
                ally.AddXp(troop2dropsXp[player.age - 1]);
                enemy.AddMoney((troop2drops[player.age - 1] + troop2dropsRange[player.age - 1]) / 2);
                enemy.AddXp(troop2dropsXp[player.age - 1] / 2);
                break;

            case 3:

                ally.AddMoney(troop3drops[player.age - 1] + troop3dropsRange[player.age - 1]);
                ally.AddXp(troop3dropsXp[player.age - 1]);
                enemy.AddMoney((troop3drops[player.age - 1] + troop3dropsRange[player.age - 1]) / 2);
                enemy.AddXp(troop3dropsXp[player.age - 1] / 2);
                break;

            case 4:

                ally.AddMoney(troop4drops[player.age - 1] + troop4dropsRange[player.age - 1]);
                ally.AddXp(troop4dropsXp[player.age - 1]);
                enemy.AddMoney((troop4drops[player.age - 1] + troop4dropsRange[player.age - 1]) / 2);
                enemy.AddXp(troop4dropsXp[player.age - 1] / 2);
                break;
        }

    }

    public IEnumerator troopUnderSpecial(Movement troop, SpecialCollision special, Player otherPlayer)
    {

        char troopChar = troop.name[6];
        int troopNumber = int.Parse(troopChar.ToString());
        int damage = 0;
        Debug.Log(troop.player.age + " enemy age " + otherPlayer.age + " ally age");
        if (otherPlayer.age == troop.player.age)
        {
            if(troopNumber == 4)
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

        Debug.Log(damage + " damage done by special");
        troop.life -= damage;
        Destroy(special.gameObject);
        if (troop.life<0)
        {
            life = 0;
            casern.DestroyTroop(troop.ID);
            dropRewards(troopNumber, otherPlayer, troop.player);
            Destroy(troop.gameObject);
        }
        yield return null;
    }
}
