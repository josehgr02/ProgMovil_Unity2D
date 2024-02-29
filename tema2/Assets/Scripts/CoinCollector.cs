using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public static int totalCoins = 0;
    public static int score = 0;
    public Text scoreText; // Ahora es un campo público para vincular en el Inspector

    void Start()
    {
        // No necesitas buscar el objeto de texto, ya que lo vincularás en el Inspector
        if (scoreText == null)
        {
            Debug.LogError("El campo de texto para la puntuación no está asignado en el Inspector.");
        }
    }

    // Método para agregar una moneda
    public static void AddCoin()
    {
        totalCoins++;
        Debug.Log("Monedas ganadas: " + totalCoins);
    }

    // Método para agregar puntos
    public static void AddPoints(int points)
    {
        score += points;
        Debug.Log("Puntos: " + score);

        UpdateScoreText(); // Llama al método para actualizar el texto UI
    }

    // Método para actualizar el texto UI de la puntuación
    private static void UpdateScoreText()
    {
        if (instance != null && instance.scoreText != null)
        {
            instance.scoreText.text = "Puntuación: " + score;
        }
    }

    // Instancia única del CoinCollector
    private static CoinCollector instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            AddPoints(1);
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("MegaCoin"))
        {
            AddPoints(5);
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("TripleCoin"))
        {
            AddPoints(10);
            Destroy(collision.gameObject);
        }
        else if (collision.collider.CompareTag("Fin"))
        {
            FinDePartida.EndGame();
            // Aquí podrías agregar más acciones como detener el movimiento del jugador, mostrar una pantalla de fin de partida, etc.
        }
    }
}