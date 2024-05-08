using UnityEngine;

public class SpecialCollision : MonoBehaviour
{
    public int ID = 0;
    public Player player1;
    public Player player2;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Special"))
        {
            Destroy(collision.gameObject);
        }
    }
}
