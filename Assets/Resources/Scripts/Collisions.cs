using UnityEngine;


public class Collisions : MonoBehaviour
{

    private Collider2D _unitCollider;

    /*
     * Start method to initialize the Collider component and set up the constraints of the Rigibody
     */
    private void Start()
    {
        _unitCollider = GetComponent<Collider2D>();
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    
    /*
     * This method will get every component it needs from each GameObjects in the collision, then proceed to compare the Tags to make different actions.
     * It will update the constraints of the troop's Rigibody when it's the ground.
     * It will start different Coroutine (Special Attack, Enemy troop or Enemy castle).
     */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager currentGameManager = GetComponent<GameManager>();
        GameManager otherGameManager = collision.gameObject.GetComponent<GameManager>();
        Rigidbody2D myRb = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
        Castle castle = collision.gameObject.GetComponent<Castle>();
        Player otherPlayer;

        if (collision.gameObject.CompareTag("Ground"))
        {
            myRb.constraints = RigidbodyConstraints2D.FreezeRotation;
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

        if ((collision.gameObject.CompareTag("player 1") && currentGameManager.id == 2 || (collision.gameObject.CompareTag("player 2") && currentGameManager.id == 1)))
        {
            if (castle != null)
            {
                myRb.constraints = RigidbodyConstraints2D.FreezeAll;
                StartCoroutine(castle.DeleteLifePoint(currentGameManager.attack, currentGameManager.attackTime, currentGameManager.id, castle));
            }
        }

        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Player"))
        {
            if (otherGameManager != null && currentGameManager.id != otherGameManager.id)
            {
                if (currentGameManager != null && otherGameManager != null && myRb != null && enemyRb != null)
                {
                    myRb.constraints = RigidbodyConstraints2D.FreezeAll;
                    enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
                }

                else
                {
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

    /*
     * This method permits to a group of troops with the same id to not get block when the first one passed from being freeze to moving.
     */
    public void OnCollisionExit2D(Collision2D collision)
    {
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

    /*
     * This method permits to get rid of the castle's collision when a unit with the same id of the castle spawn.
     */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player " + gameObject.GetComponent<GameManager>().id))
        {
            Physics2D.IgnoreCollision(other, _unitCollider, true);
        }
    }
}