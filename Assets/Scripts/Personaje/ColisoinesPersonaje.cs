using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisoinesPersonaje : MonoBehaviour
{
    //public Personaje personaje;
    public bool enArea;
    private bool enAreaRecuperacion;
    public string nombreArma;
    private bool ralentizado = false;

    private GameObject area;

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("ey");
            //personaje.cogerArma();
        }
    }*/

    private float timerEmbutido = 0f;
    private float timerBolso = 0f;
    private float timerPerro = 0f;

    private void Update()
    {
        if (timerEmbutido >= 0f)
        {
            timerEmbutido -= Time.deltaTime;
        }
        
        if (timerBolso >= 0f)
        {
            timerBolso -= Time.deltaTime;
        }

        if (timerPerro >= 0f)
        {
            timerPerro -= Time.deltaTime;
        }

        if (ralentizado)
        {
            this.gameObject.GetComponent<Personaje>().moveSpeed = 2.5f;
        }
        else
        {
            this.gameObject.GetComponent<Personaje>().moveSpeed = 5f;
        }

        recuperacion();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ArmaSuelo"))
        {
            Debug.Log("Entras");
            enArea = true;

            if (this.gameObject.GetComponent<Personaje>().armaAux == null)
            {
                nombreArma = collision.gameObject.GetComponent<Arma>().nombreArma;
                Debug.Log(nombreArma);
            }

            //personaje.cogerArma();
        }
        else if (collision.CompareTag("ArmaMelee") && collision.gameObject.GetComponent<Arma>().armaEnemigo)
        {
            //IR AÑADIENDO LAS ARMAS DE LOS ENEMIGOS CON UN TIMER ARRIBA
            switch (collision.gameObject.name)
            {
                case "Embutido (1)":
                    if (timerEmbutido <= 0f)
                    {
                        timerEmbutido = collision.gameObject.GetComponent<Arma>().cadenciaArma;
                        this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
                        comprobarVida();
                    }
                    break;
                case "Bolso(Clone)":
                    if (timerBolso <= 0f)
                    {
                        timerBolso = collision.gameObject.GetComponent<Arma>().cadenciaArma;
                        this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
                        comprobarVida();
                    }
                    break;
                case "PerroArma":
                    if (timerPerro <= 0f)
                    {
                        timerPerro = collision.gameObject.GetComponent<Arma>().cadenciaArma;
                        this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
                        comprobarVida();
                    }
                    break;
            }
            //ANIMACION Y SONIDO DE GOLPEO AL PERSONAJE
        }
        else if (collision.CompareTag("Bala") && collision.gameObject.GetComponent<Bala>().balaEnemigo)
        {
            this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Bala>().damage;    
            comprobarVida();
            //ANIMACION Y SONIDO DE GOLPEO AL PERSONAJE
        }
        if (collision.name.Contains("Carro"))
        {
            ralentizado = true;
            this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
            comprobarVida();
            //ANIMACION Y SONIDO DE GOLPEO AL PERSONAJE
        }

        if (collision.CompareTag("RecuperarVida"))
        {
            enAreaRecuperacion = true;
            area = collision.gameObject;
        }

        /*Debug.Log(collision.name);
        if (collision.name.Contains("Perro"))
        {
            Debug.Log("Colision con el perro");
            if (timerPerro <= 0f)
            {
                timerPerro = collision.gameObject.GetComponent<Arma>().cadenciaArma;
                this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
                comprobarVida();
            }
        }*/
    }

    private void recuperacion()
    {
        if (Input.GetButton("CogerObjeto") && enAreaRecuperacion)
        {
            //ANIMACION Y SONIDO RECUPERAR VIDA
            if (area.name.Contains("2") || area.name.Contains("3"))
            {
                //ANIMACION ZONA DE RECUPERACION DE VIDA DESACTIVADA
                GameObject.Find("RecuperarVida 2").GetComponent<CircleCollider2D>().enabled = false;
                GameObject.Find("RecuperarVida 3").GetComponent<CircleCollider2D>().enabled = false;
                if (this.gameObject.GetComponent<Personaje>().vidaPersonaje >= 7)
                {
                    this.gameObject.GetComponent<Personaje>().vidaPersonaje = 15;
                }
                else
                {
                    this.gameObject.GetComponent<Personaje>().vidaPersonaje += 8;
                }
            }
            else
            {
                //ANIMACION ZONA DE RECUPERACION DE VIDA DESACTIVADA
                GameObject.Find("RecuperarVida 1").GetComponent<CircleCollider2D>().enabled = false;
                if (this.gameObject.GetComponent<Personaje>().vidaPersonaje >= 12)
                {
                    this.gameObject.GetComponent<Personaje>().vidaPersonaje = 15;
                }
                else
                {
                    this.gameObject.GetComponent<Personaje>().vidaPersonaje += 3;
                }
            }
        }
    }

    private void comprobarVida()
    {
        if (this.gameObject.GetComponent<Personaje>().vidaPersonaje <= 0)
        {
            //GAME OVER

            //ANIMACION Y SONIDO DE CUANDO MUERES
            Debug.Log("La mamastes");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ArmaSuelo"))
        {
            if (!this.gameObject.GetComponent<Personaje>().armaCogida)
            {
                Destroy(this.gameObject.GetComponent<Personaje>().armaAux);
            }
            else
            {
                this.gameObject.GetComponent<Personaje>().armaAux = null;
                this.gameObject.GetComponent<Personaje>().armaCogida = false;
            }

            Debug.Log("Sales");
            enArea = false;
        }

        if (collision.CompareTag("RecuperarVida"))
        {
            enAreaRecuperacion = false;
        }
    }
}
