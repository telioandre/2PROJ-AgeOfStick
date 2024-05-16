using UnityEngine;
using UnityEngine.Serialization;

public class SpecialCollision : MonoBehaviour
{
    public int id;
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
