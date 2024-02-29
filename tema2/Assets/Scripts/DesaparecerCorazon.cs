using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerAlDesaparecerElProtagonista : MonoBehaviour
{
    // Referencia al GameObject del protagonista
    public GameObject protagonista;

    // Referencia al GameObject que deseas hacer desaparecer
    public GameObject objetoADesaparecer;

    // Update se llama una vez por frame
    void Update()
    {
        // Verifica si el protagonista ha desaparecido
        if (!protagonista.activeSelf)
        {
            // Hace desaparecer el objeto deseado
            objetoADesaparecer.SetActive(false);
        }
    }
}
