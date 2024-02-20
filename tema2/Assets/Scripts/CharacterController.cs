using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    float inputMovement;
    Rigidbody2D rigidbody2D;
    public bool mirandoDerecha;
    public float velocidadSalto;
    public int saltosRestantes = 1;


    //
    BoxCollider2D boxCollider2D;
    public bool enSuelo;
    public LayerMask surfaceLayer;


    //animaciones

    public bool isRunning;
    private Animator animator;


    private AudioSource audioSource;
    public AudioClip jumpClip;


    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D= GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        ProcesoMovimiento();
        Saltar();
        enSuelo = ComprobarSuelo();
    }


    private void ProcesoMovimiento()
    {
        inputMovement = Input.GetAxis("Horizontal");
        isRunning = inputMovement !=0 ?true : false;
        animator.SetBool("isRunning", isRunning);
        rigidbody2D.velocity = new Vector2(speed * inputMovement, rigidbody2D.velocity.y);
        OrientacionPersonaje(inputMovement);
    }


    private void Saltar()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enSuelo || saltosRestantes > 0) // Si está en el suelo o le quedan saltos
            {
                if (!enSuelo) // Si no está en el suelo, significa que está en el aire
                {
                    saltosRestantes--; // Reduce el número de saltos restantes
                }
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f); // Detiene la velocidad vertical actual
                rigidbody2D.AddForce(Vector2.up * velocidadSalto, ForceMode2D.Impulse);
                audioSource.PlayOneShot(jumpClip);

            }
        }
    }


    bool ComprobarSuelo()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, new Vector2(boxCollider2D.bounds.size.x, boxCollider2D.bounds.size.y), 0f, Vector2.down, 0.2f, surfaceLayer);

        if (raycastHit2D.collider != null)
        {
            if (!enSuelo) // Solo si no estaba en el suelo antes
            {
                saltosRestantes = 1; // Reinicia el número de saltos restantes a 1 cuando toca el suelo
            }
            return true;
        }

        return false;
    }






    private void OrientacionPersonaje(float inputMovemnet)
    {
        if((mirandoDerecha && inputMovemnet <0) || (!mirandoDerecha && inputMovemnet >0)) 
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x , transform.localScale.y);
        }
    }  
}
