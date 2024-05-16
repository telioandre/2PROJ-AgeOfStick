using UnityEngine;

public class PositionTurret : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer.enabled = !_spriteRenderer.enabled;
    }
}
