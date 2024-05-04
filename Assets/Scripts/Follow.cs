using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform troopTransform;

    public void Update()
    {
        if (troopTransform != null)
        {
            transform.position = new Vector2(troopTransform.position.x, troopTransform.position.y);
        }
    }
}

