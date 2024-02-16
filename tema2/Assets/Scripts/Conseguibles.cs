using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conseguibles : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            CoinCollector.AddPoints(1);
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("MegaCoin"))
        {
            CoinCollector.AddPoints(5);
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("Fin"))
        {
            FinDePartida.EndGame();
            // Aquí podrías agregar más acciones como detener el movimiento del jugador, mostrar una pantalla de fin de partida, etc.
        }
    }
}
