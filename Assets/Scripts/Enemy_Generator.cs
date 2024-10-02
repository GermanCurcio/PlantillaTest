using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public GameObject player; 
    public Transform LimitX1; // L�mite izquierdo
    public Transform LimitX2; // L�mite derecho
    public Transform LimitY1; // L�mite inferior
    public Transform LimitY2; // L�mite superior
    public float tiempoEntreEnemigos = 3f; // Tiempo entre la generaci�n de enemigos

    private float timer;

    void Start()
    {
        // Iniciar el temporizador
        timer = tiempoEntreEnemigos;
    }

    void Update()
    {
        // Actualizar el temporizador
        timer -= Time.deltaTime;

        // Si el temporizador llega a cero, generar un enemigo
        if (timer <= 0f)
        {
            GenerarEnemigoAleatorio();
            timer = tiempoEntreEnemigos; // Reiniciar el temporizador
        }
    }

    void GenerarEnemigoAleatorio()
    {
        // Obtener los l�mites de las paredes
        float randomX = Random.Range(LimitX1.position.x, LimitX2.position.x);
        float randomY = Random.Range(LimitY1.position.y, LimitY2.position.y);

        // Crear el enemigo en una posici�n aleatoria (con Y = 0)
        Vector3 posicionAleatoria = new Vector3(randomX, 0f, randomY);

        // Instanciar el enemigo en la posici�n calculada
        GameObject enemy = Instantiate(enemyPrefab, posicionAleatoria, Quaternion.identity);

        // Asignar el jugador como objetivo del enemigo
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null && player != null)
        {
            enemyScript.AsignarObjetivo(player);
        }
    }
}