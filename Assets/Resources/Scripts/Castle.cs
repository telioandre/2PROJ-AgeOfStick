using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public int maxLifePoint = 1000;
    public int lifePoint = 1000;
    public int id;
    public Image bar;
    public Player player;
    public GameObject gameOverUI;
    public TextMeshProUGUI winner;
    public PlayFabManager playFabManager;
    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player reference is not set in Castle.");
        }
    }

    public void AddLifePoint(int newLifePoint)
    {
        lifePoint = newLifePoint;
        Debug.Log("life point = " + lifePoint);
    }
    public void AddMaxLifePoint(int newMaxLifePoint)
    {
        maxLifePoint = newMaxLifePoint;
        Debug.Log("max life point = " + maxLifePoint);
    }

    public IEnumerator DeleteLifePoint(int damage, float attackTime, int movement, Castle castle)
    {
        // Vérification des ID différents
        if (movement != castle.id)
        {
            //Debug.Log("num 1 :  " + movement + " num 2 : " + castle.ID);
            while (lifePoint > 0)
            {
                lifePoint -= damage;
                //Debug.Log("life point = " + player.GetName() + " " + lifePoint);
                if (lifePoint <= 0)
                {
                    // Opérateur ternaire qui indique qui a gagné
                    string opponentBaseName = player.baseName == "ally" ? "enemy" : "ally";
                    if (opponentBaseName == "ally")
                    {
                        winner.text = playFabManager.GetName();
                        playFabManager.PostNewVictoryCount(playFabManager.GetPlayFabId());
                    }
                    else
                    {
                        winner.text = "IA";
                    }
                    gameOverUI.SetActive(true);
                    Time.timeScale = 0f;
                }
                // 1 seconde de délai entre chaque attaque
                yield return new WaitForSeconds(attackTime);
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

