using UnityEngine;

public class SpecialCollision : MonoBehaviour
{
    public int id;

    /*
     * Method to destroy a special object whenever it touches something.
     */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Special"))
        {
            Destroy(collision.gameObject);
        }
    }
}
