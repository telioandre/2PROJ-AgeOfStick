using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public Rigidbody2D rb; //
    public float force;
    private int _damage;
    public Castle castle1;
    public Castle castle2;
    public int id;
    private Casern _casern;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // RigidBody2D recovery 
        _casern = FindObjectOfType<Casern>(); // Casern recovery 
    }

    // Target setup function
    public void SetTarget(Transform target, Transform bulletPos, int bulletDamage, int ID)
    {
        if (target != null && bulletPos != null)
        {
            Vector3 direction = target.GetComponent<Collider2D>().bounds.center - bulletPos.position; // Use the center of the enemy's collider as a starting point
            rb.velocity = direction.normalized * force; // Just use the direction normalized by the bullet's power.
            _damage = bulletDamage;
            id = ID;
        }
    }

    // Method triggered when an object collides with the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var targetScript = collision.GetComponent<GameManager>(); // Retrieves the GameManager component attached to the object in collision
        if (collision.CompareTag("Player") && targetScript.id != id) // Checks whether the object in collision has the “Player” tag and whether its ID is different from the current ID
        {
            if (targetScript != null) // If targetScript is not null
            {
                targetScript.life -= _damage; // Reduces the target player's life by the damage value
                if (targetScript.life <= 0) // If the target player's life is less than or equal to 0
                {
                    Player enemy = FindPlayerByCastleId(targetScript.id);// Find enemy by castle ID
                    Player player = FindPlayerByCastleId(id); //Find current players by castle ID
                    var movementInstance = collision.GetComponent<GameManager>(); // Retrieves GameManager attached to the object in collision
                    if (movementInstance != null) // If the GameManager instance is found
                    {
                        // Appelle la méthode DropRewards avec l'Id partir du nom du targetScript
                        movementInstance.DropRewards(int.Parse(targetScript.name[6].ToString()), player, enemy);
                    }
                    Destroy(targetScript.gameObject); // Destroys the target game object
                    _casern.DestroyTroop(targetScript.id, targetScript.uniqueId); // Destroys the troop associated with the target ID and its uniqueId in target lists
                    
                }
                Destroy(gameObject); //
            }
        }
        else if (collision.CompareTag("Ground")) // If the object in collision has the “Ground” tag
        { 
            Destroy(gameObject); // Destroys the bullet
        }
    }

    // Function that finds the player using his castle id
    Player FindPlayerByCastleId(int id)
    {
        Castle[] castles = GameObject.FindObjectsOfType<Castle>(); // List les chateaux
        foreach (Castle castle in castles)
        {
            if (castle.id == id) // if the castle id is the same as the bullet id
            {
                return castle.GetComponent<Player>(); 
            }
        }
        return null; // Returns null if no Castle with the specified ID is found
    }
}
