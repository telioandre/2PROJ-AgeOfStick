using UnityEngine;


public class Collisions : MonoBehaviour
{

    private Collider2D _unitCollider;

    private void Start()
    {
        _unitCollider = GetComponent<Collider2D>();
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager currentGameManager = GetComponent<GameManager>();
        GameManager otherGameManager = collision.gameObject.GetComponent<GameManager>();
        Rigidbody2D myRb = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
        Castle castle = collision.gameObject.GetComponent<Castle>();
        Player ally = currentGameManager.GetPlayer();
        Player otherPlayer;

        if (collision.gameObject.CompareTag("Ground"))
        {
            myRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            Debug.Log("ca a toucher le sol");
            
        }

        if (collision.gameObject.CompareTag("Special") && gameObject.CompareTag("Player"))
        {
            Castle castle1;
            Castle castle2;
            SpecialCollision special = collision.gameObject.GetComponent<SpecialCollision>();
            int specialID = special.id;
            if (specialID == 1)
            {
                castle1 = GameObject.Find("Castle 1").GetComponent<Castle>();
                castle2 = GameObject.Find("Castle 2").GetComponent<Castle>();
            }
            else
            {
                castle1 = GameObject.Find("Castle 2").GetComponent<Castle>();
                castle2 = GameObject.Find("Castle 1").GetComponent<Castle>();
            }
            if (castle1.id == 1)
            {
                otherPlayer = castle1.player;
            }
            else
            {
                otherPlayer = castle2.player;
            }
            
            if (specialID != currentGameManager.id)
            {
                StartCoroutine(currentGameManager.TroopUnderSpecial(currentGameManager, special, otherPlayer));
            }
            else
            if (specialID == currentGameManager.id)
            {
                Destroy(collision.gameObject);
            }
        }

        // Si une collision concerne un chateau
        if ((collision.gameObject.CompareTag("player 1") && currentGameManager.id == 2 || (collision.gameObject.CompareTag("player 2") && currentGameManager.id == 1)))
        {
            if (castle != null)
            {
                //Commence une coroutine qui va faire des dégâts au chateau
                //Debug.Log("envoie " + castle.ID + "recoit : " + currentMovement.ID);
                myRb.constraints = RigidbodyConstraints2D.FreezeAll;
                StartCoroutine(castle.DeleteLifePoint(currentGameManager.attack, currentGameManager.attackTime, currentGameManager.id, castle));
            }
        }

        // Si une collision concerne un autre joueur
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Player"))
        {
            if (otherGameManager != null && currentGameManager.id != otherGameManager.id)
            {
                Player enemy = otherGameManager.GetPlayer();
                //Permet de stop le mouvement 
                if (currentGameManager != null && otherGameManager != null && myRb != null && enemyRb != null)
                {
                    myRb.constraints = RigidbodyConstraints2D.FreezeAll;
                    enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                if (ally != null && enemy != null)
                {
                    //Commence une coroutine qui diminue les pv des 2 joueurs en contact
                    //StartCoroutine(currentGameManager.AttackPlayer(otherGameManager, myRb, ally, enemy));

                }

                else
                {
                    // Si les 2 objets en contact ont le même ID ils ne se font pas de dégâts
                    myRb.constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
        }
        if (collision.gameObject.CompareTag("player " + currentGameManager.id))
        {
            Collider2D wallCollider = collision.collider;
            Physics2D.IgnoreCollision(wallCollider, _unitCollider, true);
        }
    }

    /*public void OnCollisionStay2D(Collision2D collision)
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
    }*/

    public void OnCollisionExit2D(Collision2D collision)
    {
        //Permet qu'aucun objet ne soit figé (par exemple si 2 objets avec le même ID ne bougent pas et que le 1er bat l'ennemi et reprend sa course, alors le 2e ne sera pas figé non plus
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Player") && GetComponent<GameManager>().isAttacking)
        {
            Rigidbody2D myRb = gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            myRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            enemyRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }


        if (collision.gameObject.CompareTag("player " + gameObject.GetComponent<GameManager>().id))
        {
            Collider2D wallCollider = collision.collider;
            Physics2D.IgnoreCollision(wallCollider, _unitCollider, false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player " + gameObject.GetComponent<GameManager>().id))
        {
            Physics2D.IgnoreCollision(other, _unitCollider, true);
            Debug.Log("Ignoring trigger collision with wall: " + other.gameObject.name);
        }
    }

}