using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Personaje : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento actual
    public float maxMoveSpeed = 20f;
    public float minMoveSpeed = 5f;

    public bool flashActivo = false;

    private Rigidbody2D rb;
    private Vector2 movement;

    Vector3 shootDirection;
    Vector3 mousePosition;

    public GameObject armaAux;
    public GameObject armaEquipada;

    public CogerArma comprobar;

    public bool armaCogida = false;
    
    public ColisoinesPersonaje colisiones;

    public int vidaPersonaje = 15;

    public GameObject[] vidas;

    private float timer = 0f;
    public float timerFlash = 0f;

    public AudioSource sonidosPersonaje;

    public AudioClip pasosPersonaje;
    public AudioClip cogerObjeto;
    //public AudioClip respiracionPersonaje;

    private float timerPasos = 0f;

    private bool paso = false;

    // Start se llama antes del primer frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        if (timerPasos > 0f)
        {
            timerPasos -= Time.deltaTime;
        }

        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timerFlash > 0f)
        {
            timerFlash -= Time.deltaTime;
        }

        movimientoPersonaje();
        cogerArma();
        //personajeRespirando();
    }

    //RESPIRACION PERSONAJE
    /*private void personajeRespirando()
    {
            if (timerPasos <= 0f)
            {
                if (paso)
                {
                    paso = false;
                    sonidosPersonaje.pitch = 1.1f;
                }
                else
                {
                    paso = true;
                    sonidosPersonaje.pitch = 1f;
                }

                timerPasos = 0.3f;
                sonidosPersonaje.PlayOneShot(respiracionPersonaje);
            }
    }*/

    public void actualizarVida()
    {
        for (int i = 0; i < 15; i++)
        {
            vidas[i].gameObject.SetActive(false);
        }

        if (vidaPersonaje < 0)
        {
            vidaPersonaje = 0;
        }

        for (int i = 0; i < vidaPersonaje; i++)
        {
            vidas[i].gameObject.SetActive(true);
        }
    }

    public void cogerArma()
    {
        if (Input.GetButtonDown("CogerObjeto") && colisiones.enArea)
        {
            //ANIMACION Y SONIDO COGER ARMA

            sonidosPersonaje.PlayOneShot(cogerObjeto);

            Destroy(armaEquipada);
            armaEquipada = Instantiate(GameObject.Find(GetComponent<ColisoinesPersonaje>().nombreArma)); //CUIDADO CON EL FIND
            armaEquipada.transform.position = this.transform.position;

            if (armaEquipada.GetComponent<Arma>().areaArma)
            {
                armaEquipada.tag = armaEquipada.GetComponent<Arma>().nombreArma;
            }
            else if (armaEquipada.GetComponent<Arma>().armaDistancia)
            {
                //DESACTIVAR EL COLLIDER DEL ARMA A DISTANCIA??
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

        // Normalizamos el vector para que no se mueva m�s r�pido en diagonal
        movement = movement.normalized;

        if (Input.GetKeyDown("space"))// && timer <= 0f)
        {
            //ANIMACION Y SONIDO DEL DASH

            flashActivo = true;
        }

        if (flashActivo && timerFlash <= 0f)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, maxMoveSpeed, 0.05f);
            if (Mathf.Round(moveSpeed) == maxMoveSpeed)
            {
                timerFlash = 5f;
                flashActivo = false;
            }
        }
        else if (this.GetComponent<ColisoinesPersonaje>().ralentizado)
        {
            moveSpeed = 2.5f;
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, minMoveSpeed, 0.1f);
        }

        //ANIMACION Y SONIDO DE MOVERSE

        /*if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (timerPasos <= 0f)
            {
                if (paso)
                {
                    paso = false;
                    sonidosPersonaje.pitch = 1.1f;
                }
                else
                {
                    paso = true;
                    sonidosPersonaje.pitch = 1f;
                }

                timerPasos = 0.3f;
                sonidosPersonaje.PlayOneShot(pasosPersonaje);
            }
        }*/

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}