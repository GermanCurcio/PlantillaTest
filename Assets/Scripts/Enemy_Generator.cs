using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public GameObject player; 
    public Transform LimitX1; // Límite izquierdo
    public Transform LimitX2; // Límite derecho
    public Transform LimitY1; // Límite inferior
    public Transform LimitY2; // Límite superior
    public float tiempoEntreEnemigos = 3f; // Tiempo entre la generación de enemigos

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
        // Obtener los límites de las paredes
        float randomX = Random.Range(LimitX1.position.x, LimitX2.position.x);
        float randomY = Random.Range(LimitY1.position.y, LimitY2.position.y);

        // Crear el enemigo en una posición aleatoria (con Y = 0)
        Vector3 posicionAleatoria = new Vector3(randomX, 0f, randomY);

        // Instanciar el enemigo en la posición calculada
        GameObject enemy = Instantiate(enemyPrefab, posicionAleatoria, Quaternion.identity);

        // Asignar el jugador como objetivo del enemigo
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null && player != null)
        {
            enemyScript.AsignarObjetivo(player);
        }
    }
}