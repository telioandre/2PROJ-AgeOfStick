using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float vitesseDeplacement = 30f;
    public float limiteGauche = -8.5f; // Bord gauche
    public float limiteDroite = 67.5f; // Bord droit

    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");

        // Déplacement horizontal
        float nouvellePositionX = transform.position.x + (deplacementHorizontal * vitesseDeplacement * Time.unscaledDeltaTime);
        float nouvellePositionXClamp = Mathf.Clamp(nouvellePositionX, limiteGauche, limiteDroite);

        // Appliquer la nouvelle position
        transform.position = new Vector2(nouvellePositionXClamp, transform.position.y);
        
    }
}
