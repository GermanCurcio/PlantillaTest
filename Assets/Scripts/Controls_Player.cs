using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Player : MonoBehaviour
{
    public int velocidad; // Velocidad base
    private int velocidadActual;
    public Rigidbody rb;
    public GameObject projectile;
    public int vidaActual = 10; // Vida inicial del jugador
    public int vidaMaxima = 20; // Vida máxima del jugador

    private Reset_Scene resetScene;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidadActual = velocidad; // Iniciar velocidad actual
        resetScene = FindObjectOfType<Reset_Scene>();
    }

    private void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(inputX * velocidadActual, 0, inputY * velocidadActual);
        rb.velocity = movimiento;
    }

    // Aumentar la velocidad
    public void AumentarVelocidad(int incremento)
    {
        velocidadActual += incremento;
    }

    // Recibir daño
    public void RecibirDaño(int cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log("Salud restante: " + vidaActual);

        // Verificar si la salud del jugador es menor o igual a cero
        if (vidaActual <= 0)
        {
            resetScene.RestartCurrentScene(); // Reiniciar la escena
        }
    }

    // Aumentar la vida
    public void AumentarVida(int cantidad)
    {
        vidaActual += cantidad;
        if (vidaActual > vidaMaxima) // Asegurarse de que no supere la vida máxima
        {
            vidaActual = vidaMaxima;
        }

    }
}