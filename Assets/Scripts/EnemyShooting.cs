using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
  
    public Transform bulletPos;
    public float detectionRadius = 10f;  // Rayon de détection
    public LayerMask targetLayer;  // Layer des cibles à détecter
    public int damage = 100;
    public float delay = 1f;

    private float timer;
    public List<Transform> targets = new List<Transform>();

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            DetectTargets();  // Détecte les cibles à chaque seconde
            ShootAtTargets(); // Tire sur les cibles détectées
            timer = 0;
        }
    }

    void DetectTargets()
    { 
        targets.Clear();
        Collider2D[] hits = Physics2D.OverlapCircleAll(bulletPos.position, detectionRadius, targetLayer);
        Debug.Log("hits length: " + hits.Length);
        foreach (Collider2D hit in hits)
        {
            Debug.Log(hits.Length);
            var enemyScript = hit.GetComponent<Movement>();
            var turretScript = GetComponent<Turret>();

            if (enemyScript != null)
            {
                int id = enemyScript.GetId();
                int idTurret = turretScript.getIdTurret();

                if (id == 2 && idTurret == 1)
                {
                    targets.Add(hit.transform);
                    Debug.Log(hit);
                }else if(id == 1 && idTurret == 2)
                {
                    targets.Add(hit.transform);
                    Debug.Log(hit);
                }
            }
        }
        Debug.Log("Target Count: " + targets.Count);
    }

    public void ShootAtTargets()
    {
        if (targets.Count > 0)
        {
            if (targets[0] != null && bullet != null && bulletPos != null)
            {
                Debug.Log("Tir à la cible: " + targets[0].name); // Vérifiez si la cible est correctement définie
                //Debug.Log("Balle: " + bullet.name); // Vérifiez si la référence bullet est correctement définie
                //Debug.Log("Position de la balle: " + bulletPos.position); // Vérifiez si la position de la balle est correctement définie

                var newBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);
                var enemyBulletScript = newBullet.GetComponent<EnemyBulletScript>();
                if (enemyBulletScript != null)
                {
                    int i = 0;
                    while (i < targets.Count)
                    {
                        Debug.Log("liste des cibles: " + targets[i].name);
                        i++;
                    }
                    enemyBulletScript.SetTarget(targets[0], damage);
                }
                else
                {
                    Debug.LogError("Le composant EnemyBulletScript n'a pas été trouvé sur le GameObject du projectile.");
                }
            }
            else
            {
                Debug.LogError("Une des références requises (bullet, bulletPos ou target) est null.");
            }
        }
    }
}