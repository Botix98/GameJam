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
