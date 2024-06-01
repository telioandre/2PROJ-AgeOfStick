using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet; // Itself
    public Transform bulletPos; // starting position of the bullet
    public float detectionRadius = 10f;  // Turret detection radius
    public LayerMask targetLayer;  // Layer of targets to be detected
    public int damage; // damage what the ammunition will do
    public float delay = 1f; // delay between each pull
    public int id; // Player ID

    private float _timer;
    public List<Transform> targets = new List<Transform>(); // List of targets for each turret

    // Start-up function
    private void Start()
    {
        var turretScript = GetComponent<Turret>(); // Retrieving the turret script
        damage = turretScript.getDamage(); // Recovery of the damage to be done by the turret
        detectionRadius = turretScript.getRange(); // Recovery of the range to be made by the turret
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > delay)
        {
            DetectTargets();  // Detects targets every second
            ShootAtTargets(); // Shoots at detected targets
            _timer = 0;
        }
    }

    void DetectTargets() // Function that detects all targets and adds them to a list 
    {
        targets.Clear();
        Collider2D[] hits = Physics2D.OverlapCircleAll(bulletPos.position, detectionRadius, targetLayer);
        foreach (Collider2D hit in hits)
        {
            Debug.DrawLine(bulletPos.position, hit.transform.position, Color.green, 1f); // Green line to show detection
            var enemyScript = hit.GetComponent<GameManager>(); // Retrieving the target's GameManager script
            var turretScript = GetComponent<Turret>(); // Turret script recovery
            id = turretScript.GetIdTurret(); // Recovering the ID of the player who installed the turret
            damage = turretScript.getDamage(); // Turret damage recovery
            detectionRadius = turretScript.getRange(); // Turret range recovery
            if (enemyScript != null) // Checking whether the target has the GameManager script
            {
                int enemyId = enemyScript.id; // Recovering the ID of the enemy

                if (enemyId == 2 && id == 1) // If it's a turret belonging to player 1
                {
                    targets.Add(hit.transform); // Add target position
                    Debug.Log("Target detected : " + hit.name);
                }
                else if (enemyId == 1 && id == 2) // If it's a turret belonging to player 2 or IA
                {
                    targets.Add(hit.transform); // Add target position
                    Debug.Log("Target detected : " + hit.name);
                }
            }
        }
        Debug.Log("Total number of targets : " + targets.Count);
    }

    // Function to shoot at the target
    public void ShootAtTargets()
    {
        if (targets.Count > 0) // Check that there is at least 1 target
        {
            if (targets[0] != null && bullet != null && bulletPos != null) // We check that location 0 of the list is not empty and that the bullet is initialized, as well as the starting position of the bullet.
            {
                Vector2 direction = targets[0].GetComponent<Collider2D>().bounds.center - bulletPos.position; // Create the direction in which the bullet will travel
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Create the firing angle of the bullet so that it is aimed at the target 
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Create the rotation of the bullet so that it is aimed at the target 

                var newBullet = Instantiate(bullet, bulletPos.position, rotation); // Instantiate a new bullet at the position and rotation of 'bulletPos'
                var enemyBulletScript = newBullet.GetComponent<EnemyBulletScript>(); // Get the EnemyBulletScript component from the newly created bullet
                if (enemyBulletScript != null)
                {
                    enemyBulletScript.SetTarget(targets[0], bulletPos, damage, id); // Launches the function to shoot at the selected target
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
