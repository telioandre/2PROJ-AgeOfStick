using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float Speed = 300;
    public int ID;
    public bool movementAllowed = true;
    public int life;
    public int attack;
    public Player player;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
                rb2d.velocity = new Vector2(-(Speed + 100), rb2d.velocity.y);
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
        life = 100;
        attack = 0;
        if (ID == 1)
        {
            transform.position = new Vector2(50, 600);

        }
        else if (ID == 2)
        {
            transform.position = new Vector2(3000, 600);
        }
    }

    public IEnumerator attackPlayer(Movement Enemy, Rigidbody2D myRb, Player ally, Player enemy)
    {
        while (life > 0 && Enemy != null && Enemy.life > 0)
        {
            //On divise par 2 car la coroutine se lance 2 fois (1 par objet en contact)
            life -= Enemy.attack / 2;
            Enemy.life -= attack / 2;
            Debug.Log("My life : " + life + " Enemy life : " + Enemy.life);
            if (Enemy.life <= 0)
            {
                ally.AddMoney(100);
                ally.AddXp(10);
                Enemy.life = 0;
                Destroy(Enemy.gameObject);
            }
            if (life <= 0)
            {
                enemy.AddMoney(150);
                enemy.AddXp(15);
                life = 0;
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1f);
        }

        myRb.constraints = RigidbodyConstraints2D.None;
    }

    public IEnumerator troopUnderSpecial(Movement ally, SpecialCollision special)
    {
        ally.life -= 1000;
        if (ally.life < 0)
        {
            life = 0;
            Destroy(special.gameObject);
            Destroy(ally.gameObject);
        }
        yield return null;
    }
}