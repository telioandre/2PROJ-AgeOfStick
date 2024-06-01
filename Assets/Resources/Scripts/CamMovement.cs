using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float speedMovement = 2000f;
    public float leftLimit = -75f; // Left boundary
    public float rightLimit = 2930f; // Right boundary

    void Update()
    {
        // Get horizontal movement input
        float horizontalMovement = Input.GetAxis("Horizontal");

        // Calculate new horizontal position
        float newXPosition = transform.position.x + horizontalMovement * speedMovement * Time.unscaledDeltaTime;
        float newXPositionClamp = Mathf.Clamp(newXPosition, leftLimit, rightLimit);

        // Apply the new position
        transform.position = new Vector2(newXPositionClamp, transform.position.y);
    }
}
