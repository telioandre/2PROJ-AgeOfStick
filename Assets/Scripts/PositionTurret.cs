using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTurret : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
}
