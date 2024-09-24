using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public string nombrePersonaje = "Zagreo";
    string nombreVideojuego = "Hades";

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("El personaje principal de " + nombreVideojuego + " se llama: " + nombrePersonaje);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
