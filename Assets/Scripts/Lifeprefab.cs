using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifeprefab : MonoBehaviour
{
    public int vidaIncremento = 2; // Cantidad de vida a agregar

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Obtener el componente Controls_Player del jugador
            Controls_Player controlsPlayer = other.GetComponent<Controls_Player>();

            if (controlsPlayer != null)
            {
                // Aumentar la vida del jugador
                controlsPlayer.AumentarVida(vidaIncremento);
            }

            // Destruir el Lifeprefab después de la colisión
            Destroy(gameObject);
        }
    }
}