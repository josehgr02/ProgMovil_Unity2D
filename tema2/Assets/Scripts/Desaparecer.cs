using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desaparecer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Player")) // Verifica si el objeto que colisiona es el jugador
        {
            // Destruye el objeto
            Destroy(colision.gameObject); // Destruye este objeto
        }
    }

}
