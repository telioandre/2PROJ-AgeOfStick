// Class responsible for controlling camera movement.
// This class allows the camera to move horizontally within specified limits based on user input.
// It takes into account the speed of movement and ensures that the camera does not exceed predefined boundaries.

using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float speedMovement = 2000f;
    public float leftLimit = -75f; 
    public float rightLimit = 2930f; 

    void Update()
    {
        
        float horizontalMovement = Input.GetAxis("Horizontal");

        
        float newXPosition = transform.position.x + horizontalMovement * speedMovement * Time.unscaledDeltaTime;
        float newXPositionClamp = Mathf.Clamp(newXPosition, leftLimit, rightLimit);

        
        transform.position = new Vector2(newXPositionClamp, transform.position.y);
    }
}
