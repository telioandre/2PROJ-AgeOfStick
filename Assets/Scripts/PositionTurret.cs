using UnityEngine;

public class PositionTurret : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
}
