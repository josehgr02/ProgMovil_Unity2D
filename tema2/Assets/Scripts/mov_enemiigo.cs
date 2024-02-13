using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_enemiigo : MonoBehaviour
{
    public class EnemyMovement : MonoBehaviour
    {
        public float speed = 5f; // Velocidad de movimiento del enemigo
        public Vector3 targetPosition; // La posición a la que se moverá el enemigo

        void Update()
        {
            // Mover el enemigo hacia el objetivo a una velocidad constante
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
