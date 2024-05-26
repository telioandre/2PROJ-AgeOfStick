using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float speedMovement = 2000f;
    public float leftLimit = -8.5f; // Bord gauche
    public float rightLimit = 4300f; // Bord droit

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        // Déplacement horizontal
        float newXPosition = transform.position.x + horizontalMovement * speedMovement * Time.unscaledDeltaTime;
        float newXPositionClamp = Mathf.Clamp(newXPosition, leftLimit, rightLimit);

        // Appliquer la nouvelle position
        transform.position = new Vector2(newXPositionClamp, transform.position.y);
        
    }
}
