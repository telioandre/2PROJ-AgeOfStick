// Class responsible for managing enemy turret shooting behavior. 
// This class controls the shooting behavior of enemy turrets, including target detection and firing projectiles.

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float detectionRadius = 10f; 
    public LayerMask targetLayer; 
    public int damage;
    public float delay = 1f;
    public int id;

    private float _timer;
    public List<Transform> targets = new List<Transform>(); 

    // Start-up function
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
            DetectTargets();  
            ShootAtTargets(); 
            _timer = 0;
        }
    }

    void DetectTargets() 
    {
        targets.Clear();
        Collider2D[] hits = Physics2D.OverlapCircleAll(bulletPos.position, detectionRadius, targetLayer);
        foreach (Collider2D hit in hits)
        {
            Debug.DrawLine(bulletPos.position, hit.transform.position, Color.green, 1f); 
            var enemyScript = hit.GetComponent<GameManager>(); 
            var turretScript = GetComponent<Turret>(); 
            id = turretScript.GetIdTurret(); 
            damage = turretScript.getDamage(); 
            detectionRadius = turretScript.getRange(); 
            if (enemyScript != null) 
            {
                int enemyId = enemyScript.id; 

                if (enemyId == 2 && id == 1) 
                {
                    targets.Add(hit.transform); 
                    Debug.Log("Target detected : " + hit.name);
                }
                else if (enemyId == 1 && id == 2) 
                {
                    targets.Add(hit.transform); 
                    Debug.Log("Target detected : " + hit.name);
                }
            }
        }
        Debug.Log("Total number of targets : " + targets.Count);
    }

    // Function to shoot at the target
    public void ShootAtTargets()
    {
        if (targets.Count > 0) 
        {
            if (targets[0] != null && bullet != null && bulletPos != null) 
            {
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
                    Debug.LogError("The EnemyBulletScript component was not found on the projectile's GameObject.");
                }
            }
            else
            {
                Debug.LogError("One of the required references(bullet, bulletPos or target) is null.");
            }
        }
    }
}
