using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento

    private Rigidbody2D rb;
    private Vector2 movement;

    public GameObject armaAux;
    public GameObject armaEquipada;

    public CogerArma comprobar;

    public bool armaCogida = false;
    
    public ColisoinesPersonaje colisiones;

    public int vidaPersonaje = 15;

    // Start se llama antes del primer frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        /*Debug.Log(GetComponent<ColisionEnemigos>().legia);
        if (GetComponent<ColisionEnemigos>().legia)
        {
            moveSpeed = 0f;
        }
        else
        {
            moveSpeed = 5f;
        }*/
        movimientoPersonaje();
        cogerArma();
    }

    /*public void cogerArma()
    {
        if (Input.GetButtonDown("CogerObjeto") && comprobar != null)
        {
            if (comprobar.enArea)
            {
                Debug.Log("objeto cogido");
            }
        }
    }*/

    public void cogerArma()
    {
        if (Input.GetButtonDown("CogerObjeto") && colisiones.enArea)
        {
            Destroy(armaEquipada);
            armaEquipada = Instantiate(GameObject.Find(GetComponent<ColisoinesPersonaje>().nombreArma)); //CUIDADO CON EL FIND

            if (armaEquipada.GetComponent<Arma>().areaArma)
            {
                armaEquipada.tag = armaEquipada.GetComponent<Arma>().nombreArma;
            }
            else if (armaEquipada.GetComponent<Arma>().armaDistancia)
            {
                armaEquipada.tag = "ArmaDistancia";
            }
            else 
            {
                armaEquipada.tag = "ArmaMelee";
            }

            armaCogida = true;
            armaEquipada.transform.parent = this.transform;

            if (!armaEquipada.GetComponent<Arma>().armaDistancia)
            {
                armaEquipada.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void movimientoPersonaje()
    {
        // Capturamos la entrada del teclado
        movement.x = Input.GetAxisRaw("Horizontal"); // Para izquierda y derecha
        movement.y = Input.GetAxisRaw("Vertical");   // Para arriba y abajo

        // Normalizamos el vector para que no se mueva más rápido en diagonal
        movement = movement.normalized;

        // Movemos el personaje
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}