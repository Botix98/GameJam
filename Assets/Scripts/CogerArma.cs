using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerArma : MonoBehaviour
{
    public Personaje personaje;
    public bool enArea;

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
        if (collision.CompareTag("Player"))
        {
            personaje.comprobar = this;
            Debug.Log("Entras");
            enArea = true;
            //personaje.cogerArma();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            personaje.comprobar = null;
            Debug.Log("Sales");
            enArea = false;

        }
    }
}
