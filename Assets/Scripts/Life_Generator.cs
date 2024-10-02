using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Generator : MonoBehaviour
{
    public GameObject lifeprefab;

    // Límites de las paredes
    public Transform limitX1; // Pared izquierda
    public Transform limitX2; // Pared derecha
    public Transform limitY1; // Pared inferior
    public Transform limitY2; // Pared superior

    // Tiempo entre la generación de Lifeprefabs
    public float tiempoEntreLifes = 10f;

    private float timer;

    void Start()
    {
        // Iniciar el temporizador para generar el primer Lifeprefab
        timer = tiempoEntreLifes;
    }

    void Update()
    {
        // Actualizar el temporizador
        timer -= Time.deltaTime;

        // Si el temporizador llega a cero, generar un Lifeprefab
        if (timer <= 0f)
        {
            GenerarLifeprefabAleatorio();
            
            timer = tiempoEntreLifes;   // Reiniciar el temporizador
        }
    }

    void GenerarLifeprefabAleatorio()
    {
        // Obtener los límites de las paredes
        float randomX = Random.Range(limitX1.position.x, limitX2.position.x);
        float randomY = Random.Range(limitY1.position.y, limitY2.position.y);

        // Crear el Lifeprefab en una posición aleatoria (con Y = 0)
        Vector3 posicionAleatoria = new Vector3(randomX, 0f, randomY);

        // Instanciar el Lifeprefab en la posición calculada
        Instantiate(lifeprefab, posicionAleatoria, Quaternion.identity);
    }
}