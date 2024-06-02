using UnityEngine;

public class Clicked : MonoBehaviour
{
    private Archi _archiClass;
    private Castle _castle1;

    // Start-up function
    private void Start()
    {
        _archiClass = FindObjectOfType<Archi>(); // Archi recovery
        Castle[] castles = FindObjectsOfType<Castle>(); // Castle list retrieval

        foreach (Castle castle in castles)
        {
            if (castle.CompareTag("player 1")) // if tag of the castle is "player 1"
            {
                _castle1 = castle; // castle1 recovery
            }
        }
    }
    void OnMouseDown()
    {
        // Function to be executed when the box is clicked
        StartFunction();
    }

    void StartFunction()
    {
        ShopTurret shopTurret = FindObjectOfType<ShopTurret>(); // ShopTurret Recovery
        if (shopTurret != null) // if shopTurret exists
        {
            bool isSpriteEnabled = shopTurret.IsSpriteEnabled(); // Recovers whether shopTurret has its Sprite activated
            if (isSpriteEnabled) // if sprite is activate
            {
                if (_archiClass.delete == 1) // if in “delete” mode
                {
                    if (gameObject.CompareTag("Turret1"))
                    {
                        rewardDeleteSpot(0); // Recovery of gold from the sale
                        _archiClass.SellSpot(1, 1); // Delete object from list 
                    }
                    else if (gameObject.CompareTag("Turret2"))
                    {
                        rewardDeleteSpot(1);
                        _archiClass.SellSpot(2, 1);
                    }
                    else if (gameObject.CompareTag("Turret3"))
                    {
                        rewardDeleteSpot(2);
                        _archiClass.SellSpot(3, 1);
                    }
                    else if (gameObject.CompareTag("Turret4"))
                    {
                        rewardDeleteSpot(3);
                        _archiClass.SellSpot(4, 1);
                    }
                    _archiClass.SwitchToEnabled(1);
                    _archiClass.delete = 0;
                }
                else // if in “creation” mode
                {
                    if (gameObject.CompareTag("Turret1"))
                    {
                        _archiClass.PlaceTurret(1, 1, 0); // turret creation on slot 1
                    }
                    else if (gameObject.CompareTag("Turret2"))
                    {
                        _archiClass.PlaceTurret(2, 1, 0); // turret creation on slot 2
                    }
                    else if (gameObject.CompareTag("Turret3"))
                    {
                        _archiClass.PlaceTurret(3, 1, 0); // turret creation on slot 3
                    }
                    else if (gameObject.CompareTag("Turret4"))
                    {
                        _archiClass.PlaceTurret(4, 1, 0); // turret creation on slot 4
                    }
                    _archiClass.SwitchToEnabled(1);
                }
            }
        }
    }

    private void rewardDeleteSpot(int placement)
    {
        switch (_archiClass.listTurretId1[placement].GetComponent<Turret>().type) // Depending on turret type
        {
            case 1:
                Debug.Log("vente 1");
                _castle1.player.AddMoney(_archiClass.turret1Costs[_archiClass.listTurretId1[placement].GetComponent<Turret>().age - 1] / 2); // récupération de 50 % de son prix

                break;
            case 2:
                Debug.Log("vente 1");
                _castle1.player.AddMoney(_archiClass.turret2Costs[_archiClass.listTurretId1[placement].GetComponent<Turret>().age - 1] / 2);
                break;
            case 3:
                Debug.Log("vente 1");
                _castle1.player.AddMoney(_archiClass.turret3Costs[_archiClass.listTurretId1[placement].GetComponent<Turret>().age - 1] / 2);
                break;
        }
    }
}