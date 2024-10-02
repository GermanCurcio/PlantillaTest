using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; // Punto desde donde se disparar� la bala
    public float bulletSpeed = 20f;

    private Controls_Player playerControls; // Referencia al script del jugador

    void Start()
    {
        // Referencia al script de movimiento del jugador
        playerControls = GetComponent<Controls_Player>();
    }

    void Update()
    {
        // Detectar la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Instanciar la bala en la posici�n y rotaci�n del firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Obtener el Rigidbody para aplicar velocidad 
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null && playerControls != null)
        {
            // Aplicar velocidad en la direcci�n opuesta a la direcci�n del movimiento del jugador
            Vector3 direccionDisparo = -playerControls.rb.velocity.normalized; // Direcci�n opuesta
            rb.velocity = direccionDisparo * bulletSpeed; // La bala sigue la direcci�n opuesta al movimiento del jugador
        }
    }
}