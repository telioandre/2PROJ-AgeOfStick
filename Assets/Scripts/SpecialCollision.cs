using UnityEngine;
using UnityEngine.Serialization;

public class SpecialCollision : MonoBehaviour
{
    public int id;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Special"))
        {
            Destroy(collision.gameObject);
        }
    }
}
