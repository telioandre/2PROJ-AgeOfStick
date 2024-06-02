// Class managing behavior upon clicking an object in the game. This class controls actions to take when the user clicks on an object in the game, such as creating or deleting turrets.

using System;
using UnityEngine;


public class Clicked : MonoBehaviour
{
    private Archi _archiClass;
    private Castle _castle1;

    // Initialization function
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

    // Function called when clicking an object
    void OnMouseDown()
    {
        StartFunction(); 
    }

    // Start function to handle click actions
    void StartFunction()
    {
        ShopTurret shopTurret = FindObjectOfType<ShopTurret>(); 
        if (shopTurret != null) 
        {
            bool isSpriteEnabled = shopTurret.IsSpriteEnabled(); 
            if (isSpriteEnabled) 
            {
                if (_archiClass.delete == 1) 
                {
                    
                    if (gameObject.CompareTag("Turret1"))
                    {
                        _archiClass.SellSpot(1, 1);
                        rewardDeleteSpot(1); 
                    }
                    else if (gameObject.CompareTag("Turret2"))
                    {
                        _archiClass.SellSpot(2, 1);
                        rewardDeleteSpot(1);
                    }
                    else if (gameObject.CompareTag("Turret3"))
                    {
                        _archiClass.SellSpot(3, 1);
                        rewardDeleteSpot(1);
                    }
                    else if (gameObject.CompareTag("Turret4"))
                    {
                        _archiClass.SellSpot(4, 1);
                        rewardDeleteSpot(1);
                    }
                    _archiClass.SwitchToEnabled(1);
                    _archiClass.delete = 0;
                }
                else 
                {
                    
                    if (gameObject.CompareTag("Turret1"))
                    {
                        _archiClass.PlaceTurret(1, 1, 0);
                    }
                    else if (gameObject.CompareTag("Turret2"))
                    {
                        _archiClass.PlaceTurret(2, 1, 0);
                    }
                    else if (gameObject.CompareTag("Turret3"))
                    {
                        _archiClass.PlaceTurret(3, 1, 0);
                    }
                    else if (gameObject.CompareTag("Turret4"))
                    {
                        _archiClass.PlaceTurret(4, 1, 0);
                    }
                    _archiClass.SwitchToEnabled(1);
                }
            }
        }
    }

    // Reward function for deleting a turret
    private void rewardDeleteSpot(int placement)
    {
        switch (_archiClass.listTurretId1[placement - 1].GetComponent<Turret>().type) 
        {
            case 1:
                _castle1.player.AddMoney(_archiClass.turret1Costs[_archiClass.listTurretId1[placement - 1].GetComponent<Turret>().age] / 2);
                break;
            case 2:
                _castle1.player.AddMoney(_archiClass.turret2Costs[_archiClass.listTurretId1[placement - 1].GetComponent<Turret>().age] / 2);
                break;
            case 3:
                _castle1.player.AddMoney(_archiClass.turret3Costs[_archiClass.listTurretId1[placement - 1].GetComponent<Turret>().age] / 2);
                break;
        }
    }
}
