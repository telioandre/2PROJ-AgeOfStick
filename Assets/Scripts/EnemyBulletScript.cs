using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    private int damage;
    public Castle castle1;
    public Castle castle2;
    public int ID;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform target, int bulletDamage, int id)
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * force;
            damage = bulletDamage;
            ID = id;
        }
        else
        {
            Debug.LogWarning("La cible est nulle. Impossible de définir la direction de la balle.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var targetScript = collision.GetComponent<GameManager>();

            if (targetScript != null)
            {
                targetScript.life -= damage;
                Debug.Log(targetScript.life);
                if (targetScript.life <= 0)
                {
                    Player enemy = FindPlayerByCastleId(targetScript.id);
                    Player player = FindPlayerByCastleId(ID);

                    // Obtenir une référence à l'instance de Movement
                    var movementInstance = collision.GetComponent<GameManager>();

                    if (movementInstance != null)
                    {
                        movementInstance.DropRewards(targetScript.name[6], enemy, player);
                    }
                    else
                    {
                        Debug.LogWarning("Movement instance not found on the collided object.");
                    }
                    Destroy(targetScript.gameObject);
                }
                // Détruisez la balle
                Destroy(gameObject);
            }
        }
    }

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
        return null; // Retourne null si aucun Castle avec l'ID spécifié n'est trouvé
    }
}
