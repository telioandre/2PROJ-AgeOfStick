// Class responsible for managing enemy bullet behavior.
// This class controls the behavior of enemy bullets, including movement, collision detection, and damage calculation.

using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public Rigidbody2D rb; 
    public float force;
    private int _damage;
    public Castle castle1;
    public Castle castle2;
    public int id;
    private Casern _casern;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _casern = FindObjectOfType<Casern>(); 
    }

    // Target setup function
    public void SetTarget(Transform target, Transform bulletPos, int bulletDamage, int ID)
    {
        if (target != null && bulletPos != null)
        {
            Vector3 direction = target.GetComponent<Collider2D>().bounds.center - bulletPos.position; 
            rb.velocity = direction.normalized * force; 
            _damage = bulletDamage;
            id = ID;
            Debug.Log("Shooting direction : " + rb.velocity);
            Debug.DrawLine(bulletPos.position, target.GetComponent<Collider2D>().bounds.center, Color.red, 1f); 
        }
        else
        {
            Debug.LogWarning("The target or starting position of the ball is zero. Impossible to define bullet direction.");
        }
    }

    // Method triggered when an object collides with the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var targetScript = collision.GetComponent<GameManager>(); 
        if (collision.CompareTag("Player") && targetScript.id != id) 
        {
            if (targetScript != null) 
            {
                targetScript.life -= _damage; 
                if (targetScript.life <= 0) 
                {
                    Player enemy = FindPlayerByCastleId(targetScript.id);
                    Player player = FindPlayerByCastleId(id); 
                    var movementInstance = collision.GetComponent<GameManager>(); 
                    if (movementInstance != null) 
                    {
                        
                        movementInstance.DropRewards(int.Parse(targetScript.name[6].ToString()), player, enemy);
                    }
                    else
                    {
                        
                        Debug.LogWarning("Movement instance not found on the collided object.");
                    }
                    Destroy(targetScript.gameObject); 
                    _casern.DestroyTroop(targetScript.id, targetScript.uniqueId); 
                   
                }
                Destroy(gameObject); 
            }
        }
        else if (collision.CompareTag("Ground")) 
        { 
            Destroy(gameObject); 
        }
    }

    // Function that finds the player using his castle id
    Player FindPlayerByCastleId(int id)
    {
        Castle[] castles = GameObject.FindObjectsOfType<Castle>(); 
        foreach (Castle castle in castles)
        {
            if (castle.id == id) 
            {
                return castle.GetComponent<Player>(); 
            }
        }
        return null; 
    }
}
