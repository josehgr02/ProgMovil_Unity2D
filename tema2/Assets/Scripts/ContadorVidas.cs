using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorVidas : MonoBehaviour
{
    public int vidasIniciales = 3; // Número inicial de vidas
    public GameObject[] corazones; // Array de GameObjects que contienen las imágenes de los corazones
    private int vidasActuales; // Vidas actuales

    private void Start()
    {
        vidasActuales = vidasIniciales;
        ActualizarCorazones();
    }

    public void PerderVida()
    {
        if (vidasActuales > 0)
        {
            vidasActuales--;
            ActualizarCorazones();
        }
    }

    private void ActualizarCorazones()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < vidasActuales)
            {
                corazones[i].SetActive(true); // Activar el corazón correspondiente
            }
            else
            {
                corazones[i].SetActive(false); // Desactivar el corazón si ya no quedan vidas
            }
        }
    }
}
