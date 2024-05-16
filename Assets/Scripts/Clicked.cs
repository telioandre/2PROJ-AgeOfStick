using UnityEngine;

public class Clicked : MonoBehaviour
{
    private Archi _archiClass;


    private void Start()
    {
        _archiClass = FindObjectOfType<Archi>();

    }
    void OnMouseDown()
    {
        // Fonction à exécuter lorsque la case est cliquée
        StartFunction();
    }

    void StartFunction()
    {
        
        TourelleLente spriteScript = FindObjectOfType<TourelleLente>();

        if (spriteScript != null)
        {
            bool isSpriteEnabled = spriteScript.IsSpriteEnabled();
            Debug.Log("SpriteRenderer est activé : " + isSpriteEnabled);
            if (isSpriteEnabled)
            {
                // Personnalisez le comportement que vous souhaitez exécuter lors du clic sur la case
                if (gameObject.CompareTag("Turret1"))
                {
                    Debug.Log("Turret1 cliquée");
                    _archiClass.PlaceTurret(1);
                }
                else if (gameObject.CompareTag("Turret2"))
                {
                    Debug.Log("Turret2 cliquée");
                    _archiClass.PlaceTurret(2);
                }
                else if (gameObject.CompareTag("Turret3"))
                {
                    Debug.Log("Turret3 cliquée");
                    _archiClass.PlaceTurret(3);
                }
                _archiClass.SwitchToEnabled();
            }
        }
    }
}
