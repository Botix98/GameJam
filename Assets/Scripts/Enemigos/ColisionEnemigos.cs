using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionEnemigos : MonoBehaviour
{
    public bool legia = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //EN VEZ DE DESTRUIR AL ENEMIGO LO QUE TENGO QUE HACER ES QUE PIERDA VIDA
        //EL COLIDER DEL JAMON QUE SEA UN AREA EN VEZ DE MOVER EL JAMON CON EL COLIDER CON LA FORMA DEL SPRITE
        if (collision.CompareTag("Bala"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("ArmaMelee"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("LegiaArea"))
        {
            legia = true;
            //this.gameObject.GetComponent<FuncionalidadEnemigos>().velocidadEnemigo = 0;
        }
        else if (collision.CompareTag("Aceite"))
        {

        }
        else if (collision.CompareTag("Sirope"))
        {

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("LegiaArea"))
        {
            legia = true;
            //this.gameObject.GetComponent<FuncionalidadEnemigos>().velocidadEnemigo = 0;
        }
        else if (collision.CompareTag("Aceite"))
        {

        }
        else if (collision.CompareTag("Sirope"))
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LegiaArea"))
        {
            legia = false;
            //this.gameObject.GetComponent<Personaje>().moveSpeed = 0;
        }
        else if (collision.CompareTag("Aceite"))
        {

        }
        else if (collision.CompareTag("Sirope"))
        {

        }
    }

}
