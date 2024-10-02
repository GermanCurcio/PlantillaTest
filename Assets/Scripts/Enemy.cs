using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int salud = 10; // Salud del enemigo
    public int da�o = 1; // Cantidad de da�o que har� al jugador
    public float velocidadMovimiento = 5f; // Velocidad del enemigo
    public GameObject player;
    public ScoreDisplay scoreDisplay;

    void Start()
    {
        // Encontrar el ScoreDisplay en la escena
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }
    void Update()
    {
        // Llamar a la funci�n para mover el enemigo hacia el jugador
        SeguirJugador();
    }

    void SeguirJugador()
    {
        if (player != null)
        {
            // Obtener la posici�n del jugador
            Vector3 direccion = player.transform.position - transform.position;

            // Ajustar la direcci�n para que solo se mueva en el plano XZ
            direccion.y = 0;

            // Normalizar el vector de direcci�n y mover el enemigo hacia el jugador
            Vector3 movimiento = direccion.normalized * velocidadMovimiento * Time.deltaTime;
            transform.position += movimiento;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Controls_Player controlsPlayer = collision.gameObject.GetComponent<Controls_Player>();

            if (controlsPlayer != null)
            {
                controlsPlayer.RecibirDa�o(da�o);
            }
        }

        // Verificar si el enemigo colisiona con un Projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Reducir la salud del enemigo
            salud -= 3;

            // Verificar si el enemigo ha muerto
            if (salud <= 0)
            {
                // Destruir al enemigo
                Destroy(gameObject);

                if (scoreDisplay != null)
                {
                    scoreDisplay.SumarPuntosPorEnemigo();
                }
            }

            // Destruir el projectile
            Destroy(collision.gameObject);
        }


    }

    // Asignar el objeto Player
    public void AsignarObjetivo(GameObject nuevoJugador)
    {
        player = nuevoJugador;
    }
}
