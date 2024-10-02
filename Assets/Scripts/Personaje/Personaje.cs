using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Sprite personajeFrente;
    public Sprite personajeEspalda;
    public Sprite personajePerfilIzquierda;
    public Sprite personajePerfilDerecha;

    private GameObject cuerpoPersonaje;

    private bool paso = false;

    public GameObject frutas;
    public GameObject embutido;
    public GameObject embutido1;
    public GameObject embutido2;
    public GameObject legia;
    public GameObject aceite;
    public GameObject sirope;
    public GameObject limpieza;
    public GameObject limpieza1;
    public GameObject limpieza2;
    public GameObject limpieza3;
    public GameObject patatas;
    public GameObject papelH;
    public GameObject huevos;
    public GameObject jamon1;
    public GameObject jamon2;
    public GameObject lataConservas;
    public GameObject lataConservas1;
    public GameObject lataConservas2;
    public GameObject cebollas;

    public GameObject icono;
    public Text municion;
    Color colora;

    // Start se llama antes del primer frame
    void Start()
    {
        iconoInvisible();
        cuerpoPersonaje = this.gameObject.transform.GetChild(0).gameObject;
        cuerpoPersonaje.GetComponent<SpriteRenderer>().sprite = personajeFrente;
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

    public void iconoInvisible()
    {
        colora = icono.GetComponent<UnityEngine.UI.Image>().color;
        colora.a = 0f;
        icono.GetComponent<UnityEngine.UI.Image>().color = colora;
    }

    public void iconoVisible()
    {
        colora = icono.GetComponent<UnityEngine.UI.Image>().color;
        colora.a = 1f;
        icono.GetComponent<UnityEngine.UI.Image>().color = colora;
    }

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

            this.gameObject.GetComponent<Personaje>().iconoInvisible();

            Destroy(armaEquipada);
            //armaEquipada = Instantiate(GameObject.Find(GetComponent<ColisoinesPersonaje>().nombreArma)); //CUIDADO CON EL FIND

            instanciarArma();

            armaEquipada.transform.position = this.transform.position;

            this.gameObject.GetComponent<Personaje>().municion.text = this.GetComponent<Personaje>().armaEquipada.GetComponent<Arma>().municionArma.ToString();

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

    private void instanciarArma()
    {
        iconoVisible();

        switch (this.gameObject.GetComponent<ColisoinesPersonaje>().nombreArma)
        {
            case "Frutas":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = frutas.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(frutas);
                break;
            case "Embutido 2":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = embutido2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(embutido2);
                break;
            case "Embutido 1":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = embutido1.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(embutido1);
                break;
            case "Embutido":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = embutido.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(embutido);
                break;
            case "Legia":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = legia.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(legia);
                break;
            case "Aceite":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = aceite.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(aceite);
                break;
            case "Sirope":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = sirope.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(sirope);
                break;
            case "Limpieza 3":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = limpieza3.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(limpieza3);
                break;
            case "Limpieza 2":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = limpieza2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(limpieza2);
                break;
            case "Limpieza 1":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = limpieza1.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(limpieza1);
                break;
            case "Limpieza":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = limpieza.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(limpieza);
                break;
            case "Patatas":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = patatas.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(patatas);
                break;
            case "PapelHigienico(1)":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = papelH.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(papelH);
                break;
            case "PapelHigienico":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = papelH.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(papelH);
                break;
            case "Huevos":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = huevos.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(huevos);
                break;
            case "Jamon":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = jamon1.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(jamon1);
                break;
            case "Jamon 1":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = jamon2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(jamon2);
                break;
            case "LataConservas 2":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = lataConservas2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(lataConservas2);
                break;
            case "LataConservas 1":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = lataConservas1.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(lataConservas1);
                break;
            case "LataConservas":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = lataConservas.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(lataConservas);
                break;
            case "Cebollas":
                icono.GetComponent<UnityEngine.UI.Image>().sprite = cebollas.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
                armaEquipada = Instantiate(cebollas);
                break;
        }
    }

    private void movimientoPersonaje()
    {
        // Capturamos la entrada del teclado
        movement.x = Input.GetAxisRaw("Horizontal"); // Para izquierda y derecha
        movement.y = Input.GetAxisRaw("Vertical");   // Para arriba y abajo

        if (movement.y == 1)
        {
            cuerpoPersonaje.GetComponent<SpriteRenderer>().sprite = personajeEspalda;
        }
        else if (movement.y == -1)
        {
            cuerpoPersonaje.GetComponent<SpriteRenderer>().sprite = personajeFrente;
        }
        else if (movement.x == -1)
        {
            cuerpoPersonaje.GetComponent<SpriteRenderer>().sprite = personajePerfilIzquierda;
        }
        else if (movement.x == 1)
        {
            cuerpoPersonaje.GetComponent<SpriteRenderer>().sprite = personajePerfilDerecha;
        }

        // Normalizamos el vector para que no se mueva más rápido en diagonal
        movement = movement.normalized;

        if (Input.GetKeyDown("space") && timerFlash <= 0f)
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