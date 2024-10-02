using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int velocidadIncremento = 2; // Cantidad de aumento de velocidad
    public ScoreDisplay scoreDisplay;

    void Start()
    {
        // Encontrar el ScoreDisplay en la escena
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Obtener el componente Controls_Player del jugador
            Controls_Player controlsPlayer = other.GetComponent<Controls_Player>();

            if (controlsPlayer != null)
            {
                // Aumentar la velocidad del jugador
                controlsPlayer.AumentarVelocidad(velocidadIncremento);

                // Sumar puntos al ScoreDisplay
                if (scoreDisplay != null)
                {
                    scoreDisplay.SumarPuntosPorPowerUp();
                }
            }

            // Destruir el PowerUp
            Destroy(gameObject);
        }
    }
}