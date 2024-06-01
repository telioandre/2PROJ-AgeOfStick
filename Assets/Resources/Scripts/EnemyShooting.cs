using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float detectionRadius = 10f;  // Rayon de détection
    public LayerMask targetLayer;  // Layer des cibles à détecter
    public int damage;
    public float delay = 1f;
    public int id;

    private float _timer;
    public List<Transform> targets = new List<Transform>();

    private void Start()
    {
        var turretScript = GetComponent<Turret>();
        damage = turretScript.getDamage();
        detectionRadius = turretScript.getRange();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > delay)
        {
            DetectTargets();  // Détecte les cibles à chaque seconde
            ShootAtTargets(); // Tire sur les cibles détectées
            _timer = 0;
        }
    }

    void DetectTargets()
    {
        targets.Clear();
        Collider2D[] hits = Physics2D.OverlapCircleAll(bulletPos.position, detectionRadius, targetLayer);
        Debug.Log("Nombre de cibles détectées : " + hits.Length);
        foreach (Collider2D hit in hits)
        {
            Debug.DrawLine(bulletPos.position, hit.transform.position, Color.green, 1f); // Ligne verte pour montrer la détection
            var enemyScript = hit.GetComponent<GameManager>();
            var turretScript = GetComponent<Turret>();
            id = turretScript.GetIdTurret();
            damage = turretScript.getDamage();
            detectionRadius = turretScript.getRange();
            if (enemyScript != null)
            {
                int id = enemyScript.id;
                int idTurret = turretScript.GetIdTurret();

                if (id == 2 && idTurret == 1)
                {
                    targets.Add(hit.transform);
                    Debug.Log("Cible détectée : " + hit.name);
                }
                else if (id == 1 && idTurret == 2)
                {
                    targets.Add(hit.transform);
                    Debug.Log("Cible détectée : " + hit.name);
                }
            }
        }
        Debug.Log("Nombre total de cibles : " + targets.Count);
    }

    public void ShootAtTargets()
    {
        if (targets.Count > 0)
        {
            if (targets[0] != null && bullet != null && bulletPos != null)
            {
                Debug.Log("Tir à la cible : " + targets[0].name); // Vérifiez si la cible est correctement définie

                Vector2 direction = targets[0].GetComponent<Collider2D>().bounds.center - bulletPos.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                var newBullet = Instantiate(bullet, bulletPos.position, rotation);
                var enemyBulletScript = newBullet.GetComponent<EnemyBulletScript>();
                if (enemyBulletScript != null)
                {
                    enemyBulletScript.SetTarget(targets[0], bulletPos, damage, id);
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
