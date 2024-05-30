using UnityEngine;

public class Clicked : MonoBehaviour
{
    private Archi _archiClass;
    private Castle _castle1;


    private void Start()
    {
        _archiClass = FindObjectOfType<Archi>();
        Castle[] castles = FindObjectsOfType<Castle>();

        foreach (Castle castle in castles)
        {
            if (castle.CompareTag("player 1"))
            {
                _castle1 = castle;
            }
        }
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
                if (_archiClass.delete == 1)
                {
                    Debug.Log("Del pass = 1");
                    if (gameObject.CompareTag("Turret1"))
                    {
                        Debug.Log("Turret1 Del");
                        _archiClass.SellSpot(1, 1);
                        _castle1.player.AddMoney(200);
                    }
                    else if (gameObject.CompareTag("Turret2"))
                    {
                        Debug.Log("Turret2 Del");
                        _archiClass.SellSpot(2, 1);
                        _castle1.player.AddMoney(200);
                    }
                    else if (gameObject.CompareTag("Turret3"))
                    {
                        Debug.Log("Turret3 Del");
                        _archiClass.SellSpot(3, 1);
                        _castle1.player.AddMoney(200);
                    }
                    else if (gameObject.CompareTag("Turret4"))
                    {
                        Debug.Log("Turret4 Del");
                        _archiClass.SellSpot(4, 1);
                        _castle1.player.AddMoney(200);
                    }
                    _archiClass.SwitchToEnabled(1);
                    _archiClass.delete = 0;
                }
                else
                {
                    Debug.Log("pass 1");
                    // Personnalisez le comportement que vous souhaitez exécuter lors du clic sur la case
                    if (gameObject.CompareTag("Turret1"))
                    {
                        Debug.Log("Turret1 cliquée");
                        _archiClass.PlaceTurret(1, 1, 0);
                    }
                    else if (gameObject.CompareTag("Turret2"))
                    {
                        Debug.Log("Turret2 cliquée");
                        _archiClass.PlaceTurret(2, 1, 0);
                    }
                    else if (gameObject.CompareTag("Turret3"))
                    {
                        Debug.Log("Turret3 cliquée");
                        _archiClass.PlaceTurret(3, 1, 0);
                    }
                    else if (gameObject.CompareTag("Turret4"))
                    {
                        Debug.Log("Turret4 cliquée");
                        _archiClass.PlaceTurret(4, 1, 0);
                    }
                    _archiClass.SwitchToEnabled(1);
                }
            }
        }
    }
}
