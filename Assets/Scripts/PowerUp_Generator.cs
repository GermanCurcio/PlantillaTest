using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarPowerUp : MonoBehaviour
{
    public GameObject powerUpPrefab;

    public Transform LimitX1; // Pared izquierda
    public Transform LimitX2; // Pared derecha
    public Transform LimitY1; // Pared inferior
    public Transform LimitY2; // Pared superior

    // Tiempo entre la generación de PowerUps
    public float tiempoEntrePowerUps = 10f;

    private float timer;

    void Start()
    {
        // Iniciar el temporizador para generar el primer PowerUp
        timer = tiempoEntrePowerUps;
    }

    void Update()
    {
        // Actualizar el temporizador
        timer -= Time.deltaTime;

        // Si el temporizador llega a cero, generar un PowerUp
        if (timer <= 0f)
        {
            GenerarPowerUpAleatorio();
            
            timer = tiempoEntrePowerUps;    // Reiniciar el temporizador
        }
    }

    void GenerarPowerUpAleatorio()
    {
        // Obtener los límites de las paredes
        float randomX = Random.Range(LimitX1.position.x, LimitX2.position.x);
        float randomY = Random.Range(LimitY1.position.y, LimitY2.position.y);

        // Crear el PowerUp en una posición aleatoria (con Y = 0)
        Vector3 posicionAleatoria = new Vector3(randomX, 0f, randomY);

        // Instanciar el PowerUp en la posición calculada
        Instantiate(powerUpPrefab, posicionAleatoria, Quaternion.identity);
    }
}