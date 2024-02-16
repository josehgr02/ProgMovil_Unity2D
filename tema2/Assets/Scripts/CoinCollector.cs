using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public static int totalCoins = 0; 
    public static int score = 0;

    public static void AddCoin()
    {
        totalCoins++;
        Debug.Log("Monedas ganadas: " + totalCoins);
    }
    public static void AddPoints(int points)
    {
        score += points;
        Debug.Log("Puntos: " + score);

    }
}
