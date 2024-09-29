using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisoinesPersonaje : MonoBehaviour
{
    //public Personaje personaje;
    public bool enArea;
    public string nombreArma;

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("ey");
            //personaje.cogerArma();
        }
    }*/

    private float timerBolso = 0f;

    private void Update()
    {
        if (timerBolso >= 0f)
        {
            timerBolso -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LegiaArea"))
        {
            Debug.Log("SIIIIIIIIIIII");
        }

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
                    if (timerBolso <= 0f)
                    {
                        timerBolso = collision.gameObject.GetComponent<Arma>().cadenciaArma;

                        this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;

                        comprobarVida();
                    }
                    break;
            }
            
        }
        else if (collision.CompareTag("Bala") && collision.gameObject.GetComponent<Bala>().balaEnemigo)
        {
            this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Bala>().damage;

            comprobarVida();
        }
    }

    private void comprobarVida()
    {
        if (this.gameObject.GetComponent<Personaje>().vidaPersonaje <= 0)
        {
            //GAME OVER
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
    }
}
