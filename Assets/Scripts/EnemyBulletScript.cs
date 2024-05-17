using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform target, int bulletDamage)
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * force;
            damage = bulletDamage;
        }
        else
        {
            Debug.LogWarning("La cible est nulle. Impossible de définir la direction de la balle.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifiez si la collision est avec un objet ayant le tag "Target"
        if (collision.CompareTag("Player"))
        {
            // Accédez au composant de script de l'objet touché (peut-être votre ennemi)
            var targetScript = collision.GetComponent<Movement>(); // Remplacez "YourTargetScript" par le nom de votre script de cible

            // Vérifiez si le composant de script a été trouvé
            if (targetScript != null)
            {

                // Appelez la fonction AddDegats() de votre script de cible
                targetScript.life -= damage;
                Debug.Log(targetScript.life);
                if (targetScript.life <= 0)
                {
                    //Movement.DropRewards(targetScript.name[6], otherPlayer, targetScript.player);
                    Destroy(targetScript.gameObject);
                }

                // Détruisez la balle
                Destroy(gameObject);
            }
        }
    }

}