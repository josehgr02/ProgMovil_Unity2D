using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinDePartida : MonoBehaviour
{
    public static void EndGame()
    {
        Debug.Log("¡Fin de la partida!");
        Debug.Log("Puntos totales: " + CoinCollector.score);
        // Aquí podrías agregar lógica adicional, como reiniciar el juego o mostrar un menú de fin de partida.
    }

}
