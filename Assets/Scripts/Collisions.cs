using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Collisions : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Movement currentMovement = GetComponent<Movement>();
        Movement otherMovement = collision.gameObject.GetComponent<Movement>();
        Rigidbody2D myRb = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
        Castle castle = collision.gameObject.GetComponent<Castle>();
        Player ally = currentMovement.player;
        Player otherPlayer;

        if (collision.gameObject.CompareTag("Special") && gameObject.CompareTag("Player"))
        {
            SpecialCollision special = collision.gameObject.GetComponent<SpecialCollision>();
            int SpecialID = collision.gameObject.GetComponent<SpecialCollision>().ID;
            Player player1 = special.player1;
            Player player2 = special.player2;
            if (player1.baseName == "ally")
            {
                otherPlayer = player1;
            }
            else
            {
                otherPlayer = player2;
            }

            if (SpecialID != currentMovement.ID)
            {
                StartCoroutine(currentMovement.troopUnderSpecial(currentMovement, special, otherPlayer));
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }

        // Si une collision concerne un chateau
        if ((collision.gameObject.CompareTag("player 1") && currentMovement.ID == 2 || (collision.gameObject.CompareTag("player 2") && currentMovement.ID == 1)))
        {
            if (castle != null)
            {
                //Commence une coroutine qui va faire des dégâts au chateau
                //Debug.Log("envoie " + castle.ID + "recoit : " + currentMovement.ID);
                StartCoroutine(castle.DeleteLifePoint(currentMovement.attack, currentMovement.ID, castle));
            }
        }

        // Si une collision concerne un autre joueur
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Player"))
        {
            if (otherMovement != null && currentMovement.ID != otherMovement.ID)
            {
                Player enemy = otherMovement.player;
                //Permet de stop le mouvement 
                if (currentMovement != null && otherMovement != null && myRb != null && enemyRb != null)
                {
                    myRb.constraints = RigidbodyConstraints2D.FreezeAll;
                    enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                if (otherMovement.ID != currentMovement.ID)
                {

                    if (ally != null && enemy != null)
                    {
                        //Commence une coroutine qui diminue les pv des 2 joueurs en contact
                        StartCoroutine(currentMovement.attackPlayer(otherMovement, myRb, ally, enemy));
                    }
                }
                else
                {
                    // Si les 2 objets en contact ont le même ID ils ne se font pas de dégâts
                    myRb.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D myRb = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Player"))
        {
            if (myRb.constraints == RigidbodyConstraints2D.FreezeAll)
            {
                enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        //Permet qu'aucun objet ne soit figé (par exemple si 2 objets avec le même ID ne bougent pas et que le 1er bat l'ennemi et reprend sa course, alors le 2e ne sera pas figé non plus
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Player"))
        {
            Rigidbody2D myRb = gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            myRb.constraints = RigidbodyConstraints2D.None;
            enemyRb.constraints = RigidbodyConstraints2D.None;
        }
    }
}