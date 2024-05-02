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
        // Fonction � ex�cuter lorsque la case est cliqu�e
        StartFunction();
    }

    void StartFunction()
    {
        
        TourelleLente spriteScript = FindObjectOfType<TourelleLente>();

        if (spriteScript != null)
        {
            bool isSpriteEnabled = spriteScript.IsSpriteEnabled();
            Debug.Log("SpriteRenderer est activ� : " + isSpriteEnabled);
            if (isSpriteEnabled)
            {
                // Personnalisez le comportement que vous souhaitez ex�cuter lors du clic sur la case
                if (gameObject.CompareTag("Turret1"))
                {
                    Debug.Log("Turret1 cliqu�e");
                    archiClass.placeTurret(1);
                }
                else if (gameObject.CompareTag("Turret2"))
                {
                    Debug.Log("Turret2 cliqu�e");
                    archiClass.placeTurret(2);
                }
                else if (gameObject.CompareTag("Turret3"))
                {
                    Debug.Log("Turret3 cliqu�e");
                    archiClass.placeTurret(3);
                }
                archiClass.switchToEnabled();
            }
        }
    }
}
