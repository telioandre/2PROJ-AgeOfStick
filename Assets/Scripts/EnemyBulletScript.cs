using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    private int damage;
    private int idBullet;

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
            idBullet = id;
        }
        else
        {
            Debug.LogWarning("La cible est nulle. Impossible de d�finir la direction de la balle.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var targetScript = collision.GetComponent<Movement>(); 
        // V�rifiez si la collision est avec un objet ayant le tag "Target"
        if (collision.CompareTag("Player") && targetScript.GetId() != idBullet)
        {
            // Acc�dez au composant de script de l'objet touch� (peut-�tre votre ennemi)
            

            // V�rifiez si le composant de script a �t� trouv�
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

                // D�truisez la balle
                Destroy(gameObject);
            }
        }
    }

}