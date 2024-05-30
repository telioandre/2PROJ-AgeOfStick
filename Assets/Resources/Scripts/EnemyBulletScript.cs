// EnemyBulletScript.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    private int damage;
    public Castle castle1;
    public Castle castle2;
    public int ID;
    private Casern casern;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        casern = FindObjectOfType<Casern>();
    }

    public void SetTarget(Transform target, Transform bulletPos, int bulletDamage, int id)
    {
        if (target != null && bulletPos != null)
        {
            Vector3 direction = target.GetComponent<Collider2D>().bounds.center - bulletPos.position; // Utilisez le centre du collider de l'ennemi comme point de départ
            rb.velocity = direction.normalized * force; // Utilisez juste la direction normalisée
            damage = bulletDamage;
            ID = id;

            // Débogage : Afficher la direction de tir de la balle
            Debug.Log("Direction de tir : " + rb.velocity);
            Debug.DrawLine(bulletPos.position, target.GetComponent<Collider2D>().bounds.center, Color.red, 1f); // Ligne rouge pour montrer la direction de tir
        }
        else
        {
            Debug.LogWarning("La cible ou la position de départ de la balle est nulle. Impossible de définir la direction de la balle.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var targetScript = collision.GetComponent<GameManager>();

        if (collision.CompareTag("Player") && targetScript.id != ID)
        {
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
                    casern.DestroyTroop(targetScript.id, targetScript.uniqueId);
                }
                // Détruisez la balle
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
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
