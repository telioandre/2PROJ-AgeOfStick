using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float Speed = 300;
    public int ID;
    public bool movementAllowed = true;
    public int life;
    public int maxLife;
    public int attack;
    public int troopLevel;
    public float buildTime;
    public Player player;
    public Casern casern;
    public Image health;
    public Image background;
    public Image fill;

    private System.Random random = new System.Random();
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        health.fillAmount = (float)life / maxLife;
    }

    //Permet de lancer le mouvement de chaque unité en fonction de leur ID
    void FixedUpdate()
    {
        if (movementAllowed)
        {
            if (ID == 1)
            {
                rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
            }
            else if (ID == 2)
            {
                rb2d.velocity = new Vector2(-(Speed+100), rb2d.velocity.y);
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
        life = life + (player.age * 1);
        maxLife = life;
        for(int i = 0; i < player.age; i++) {
            attack = Mathf.RoundToInt(attack * 1.5f);
        }
        buildTime = buildTime + (player.age * 0);
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
            transform.position = new Vector2(3500, 600);
        }
    }

    public IEnumerator attackPlayer(Movement Enemy, Rigidbody2D myRb, Player ally, Player enemy)
    {
        while(life > 0 && Enemy != null && Enemy.life > 0)
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
            //Debug.Log("My life : " + life + " Enemy life : " + Enemy.life);
            if (Enemy.life <= 0)
            {
                ally.AddMoney(100);
                ally.AddXp(10);
                Enemy.life = 0;
                if (Enemy.ID == 2)
                {
                    casern.DestroyTroop2();
                }
                else
                {
                    casern.DestroyTroop1();
                }
                Destroy(Enemy.gameObject);
            }
            if(life <= 0)
            {
                enemy.AddMoney(150);
                enemy.AddXp(15);
                life = 0;
                if(Enemy.ID == 1)
                {
                    casern.DestroyTroop2();
                }
                else
                {
                    casern.DestroyTroop1();
                }
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1f);
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

    public IEnumerator troopUnderSpecial(Movement ally, SpecialCollision special)
    {
        ally.life -= 1000;
        if(ally.life<0)
        {
            life = 0;
            Destroy(special.gameObject);
            Debug.Log("ID du truc détruit : " + ally.ID);
            if(ally.ID == 1)
            {
                casern.DestroyTroop1();
            }
            else if(ally.ID == 2)
            {
                casern.DestroyTroop2();
            }
            Destroy(ally.gameObject);
        }
        yield return null;
    }
}
