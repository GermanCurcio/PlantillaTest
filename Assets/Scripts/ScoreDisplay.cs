using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText; // Referencia al componente Text en la UI
    private int score; // Puntuación actual

    void Start()
    {
        score = 0;
        ActualizarTextoScore();
    }

    // Sumar puntos por enemigo destruido
    public void SumarPuntosPorEnemigo()
    {
        score += 15;
        ActualizarTextoScore();
    }

    // Sumar puntos por power-up destruido
    public void SumarPuntosPorPowerUp()
    {
        score += 10;
        ActualizarTextoScore();
    }

    // Actualizar el texto de la puntuación en la UI
    private void ActualizarTextoScore()
    {
        scoreText.text = "Puntuaje:" + score;
    }
}
