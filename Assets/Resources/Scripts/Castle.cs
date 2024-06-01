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
    
    /*
     * Method to manage life point of each castle when the age is upgraded.
     */
    public void AddLifePoint(int newLifePoint)
    {
        lifePoint = newLifePoint;
    }
    
    /*
     * Method called when a player upgrade his age so the health bar of the castle will be updated.
     */
    public void AddMaxLifePoint(int newMaxLifePoint)
    {
        maxLifePoint = newMaxLifePoint;
    }

    /*
     * Method to delete castle's life points depending on the attack stat and the attack time stat of the troop attacking it.
     * It will consider the id of the troop to not get killed by allies.
     * When a castle has no life points, the winner is show and the win count statistic of the player may improve.
     */
    public IEnumerator DeleteLifePoint(int damage, float attackTime, int attackingId, Castle castle)
    {
        if (attackingId != castle.id)
        {
            while (lifePoint > 0)
            {
                lifePoint -= damage;
                if (lifePoint <= 0)
                {
                    string opponentBaseName = player.baseName == "ally" ? "enemy" : "ally";
                    if (opponentBaseName == "ally")
                    {
                        winner.text = playFabManager.GetName();
                        playFabManager.PostNewVictoryCount();
                    }
                    else
                    {
                        winner.text = "IA";
                    }
                    gameOverUI.SetActive(true);
                    Time.timeScale = 0f;
                }
                yield return new WaitForSeconds(attackTime);
            }
        }
        else
        {
            yield return null;
        }
    }

    /*
     * Update method to display dynamically the castle's life points.
     */
    public void Update()
    {
        bar.fillAmount = (float)lifePoint / maxLifePoint;
    }
}

