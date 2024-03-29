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


    //
    BoxCollider2D boxCollider2D;
    public bool enSuelo;
    public LayerMask surfaceLayer;


    //animaciones

    public bool isRunning;
    private Animator animator;




    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D= GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo) 
        {
            rigidbody2D.AddForce(Vector2.up * velocidadSalto, ForceMode2D.Impulse);
            
        }
    }


    bool ComprobarSuelo()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, new Vector2(boxCollider2D.bounds.size.x, boxCollider2D.bounds.size.y), 0f, Vector2.down, 0.2f, surfaceLayer);

        return raycastHit2D.collider != null;
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
