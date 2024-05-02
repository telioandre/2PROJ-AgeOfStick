using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public int maxLifePoint = 1000;
    public int lifePoint = 1000;
    public int numberOfTower = 0;
    public int ID;
    public Image bar;
    public Player player;
    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is not set in Castle.");
            return;
        }
    }
    public void AddTower() {
        if (numberOfTower == 4)
        {
            Debug.Log("Maximum of Tower built.");
        }
        else
        {
            if (player.GetMoney() >= 400)
            {
                numberOfTower++;
                player.SuppMoney(400);
                Debug.Log("tower = " + numberOfTower);
            }
            else
            {
                Debug.Log("Not enough money)");
            }
        }
    }
    public void DeleteTower()
    {
        if (numberOfTower <= 0)
        {
            Debug.Log("No tower to delete.");
        }
        else
        {
            numberOfTower--;
            player.AddMoney(200);
            Debug.Log("tower = " + numberOfTower);
        }
    }

    public void AddLifePoint(int age)
    {
        lifePoint += age*200;
        Debug.Log("life point = " + lifePoint);
    }

    public IEnumerator DeleteLifePoint(int damage, int movement, Castle castle)
    {
        // V�rification des ID diff�rents
        if (movement != castle.ID)
        {
            Debug.Log("num 1 :  " + movement + " num 2 : " + castle.ID);
            while (lifePoint > 0)
            {
                lifePoint -= damage;
                Debug.Log("life point = " + player.GetName() + " " + lifePoint);
                if (lifePoint <= 0)
                {
                    // Op�rateur ternaire qui indique qui a gagn�
                    string opponentBaseName = (player.baseName == "ally") ? "enemy" : "ally";
                    Debug.Log(opponentBaseName + " win !");
                    // Ferme l'appli et la preview
                    Application.Quit();
                    //EditorApplication.ExitPlaymode();
                }
                // 1 seconde de d�lai entre chaque attaque
                yield return new WaitForSeconds(1f);
            }
        }
        else
        {
            yield return null;
        }
    }

    public void Update()
    {
        bar.fillAmount = (float)lifePoint / maxLifePoint;
    }
}

