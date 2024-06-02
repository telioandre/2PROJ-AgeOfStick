using UnityEngine;

public class Restart : MonoBehaviour
{
    public Castle castle1;
    public Castle castle2;
    public Casern casern;
    public Archi archi;

    /*
     * This method is used when the user leave the game.
     * It permits to reset every statistic in order to play a new one.
     */
    public void ResetGame()
    {
        castle1.player.SetMoney(10);
        castle2.player.SetMoney(10);
        
        castle1.player.SetAge(1);
        castle2.player.SetAge(1);
        
        castle1.player.SetXp(1000);
        castle2.player.SetXp(1000);

        castle1.player.numberOfTroop = 0;
        castle1.player.troop1Level = 0;
        castle1.player.troop2Level = 0;
        castle1.player.troop3Level = 0;
        castle1.player.troop4Level = 0;
        castle1.player.turretRangeLevel = 0;
        castle1.player.turretDamageLevel = 0;
        archi.nbPlacementId1 = 0;
        
        castle2.player.numberOfTroop = 0;
        castle2.player.troop1Level = 0;
        castle2.player.troop2Level = 0;
        castle2.player.troop3Level = 0;
        castle2.player.troop4Level = 0;
        castle2.player.turretRangeLevel = 0;
        castle2.player.turretDamageLevel = 0;
        archi.nbPlacementId2 = 0;

        castle1.lifePoint = 1000;
        castle1.maxLifePoint = 1000;
        
        castle1.lifePoint = 1000;
        castle1.maxLifePoint = 1000;

        for (int i = 0; i < casern.queue1.Count; i++)
        {
            casern.queue1.Remove(casern.queue1[i]);
        }
        for (int i = 0; i < casern.queue2.Count; i++)
        {
            casern.queue2.Remove(casern.queue2[i]);
        }
        
        for (int i = 0; i < casern.troopsPlayer1.Count; i++)
        {
            Destroy(casern.troopsPlayer1[i].gameObject);
        }
        
        for (int i = 0; i < casern.troopsPlayer2.Count; i++)
        {
            Destroy(casern.troopsPlayer2[i].gameObject);
        }
        
        for (int i = 0; i < casern.troopsPlayer1.Count; i++)
        {
            casern.troopsPlayer1.Remove(casern.troopsPlayer1[i]);
        }
        for (int i = 0; i < casern.troopsPlayer2.Count; i++)
        {
            casern.troopsPlayer2.Remove(casern.troopsPlayer2[i]);
        }
        Time.timeScale = 1f;

    }

}
