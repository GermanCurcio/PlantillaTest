using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Controls_Player player; // Referencia al script del jugador
    private Text healthText; // Componente Text para mostrar la salud

    void Start()
    {
        // Obtiene el componente Text en este objeto
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        if (player != null)
        {
            // Actualiza el texto para mostrar la salud actual del jugador
            healthText.text = "Salud: " + player.vidaActual;
        }
    }
}