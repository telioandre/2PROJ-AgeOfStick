using UnityEngine;

public class Clicked : MonoBehaviour
{
    private Archi archiClass;


    private void Start()
    {
        archiClass = FindObjectOfType<Archi>();

    }
    void OnMouseDown()
    {
        // Fonction à exécuter lorsque la case est cliquée
        StartFunction();
    }

    void StartFunction()
    {
        
        ShopTurret spriteScript = FindObjectOfType<ShopTurret>();

        if (spriteScript != null)
        {
            bool isSpriteEnabled = spriteScript.IsSpriteEnabled();
            Debug.Log("SpriteRenderer est activé : " + isSpriteEnabled);
            if (isSpriteEnabled)
            {
                if (spriteScript.delete == 1)
                {
                    if (gameObject.CompareTag("Turret1"))
                    {
                        Debug.Log("Turret1 Del");
                        archiClass.SellSpot(1, 1);
                    }
                    else if (gameObject.CompareTag("Turret2"))
                    {
                        Debug.Log("Turret2 Del");
                        archiClass.SellSpot(2, 1);
                    }
                    else if (gameObject.CompareTag("Turret3"))
                    {
                        Debug.Log("Turret3 Del");
                        archiClass.SellSpot(3, 1);
                    }
                    else if (gameObject.CompareTag("Turret4"))
                    {
                        Debug.Log("Turret4 Del");
                        archiClass.SellSpot(4, 1);
                    }
                    archiClass.switchToEnabled(1);
                    spriteScript.delete = 0;
                }
                else
                {
                    Debug.Log("pass 1");
                    // Personnalisez le comportement que vous souhaitez exécuter lors du clic sur la case
                    if (gameObject.CompareTag("Turret1"))
                    {
                        Debug.Log("Turret1 cliquée");
                        archiClass.PlaceTurret(1, 1, 0);
                    }
                    else if (gameObject.CompareTag("Turret2"))
                    {
                        Debug.Log("Turret2 cliquée");
                        archiClass.PlaceTurret(2, 1, 0);
                    }
                    else if (gameObject.CompareTag("Turret3"))
                    {
                        Debug.Log("Turret3 cliquée");
                        archiClass.PlaceTurret(3, 1, 0);
                    }
                    else if (gameObject.CompareTag("Turret4"))
                    {
                        Debug.Log("Turret4 cliquée");
                        archiClass.PlaceTurret(4, 1, 0);
                    }
                    archiClass.switchToEnabled(1);
                }
            }
        }
    }
}
