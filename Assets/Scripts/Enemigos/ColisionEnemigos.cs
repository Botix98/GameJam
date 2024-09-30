using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionEnemigos : MonoBehaviour
{
    public bool legia = false;
    public bool sirope = false;
    public bool aceite = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        //EL COLIDER DEL JAMON QUE SEA UN AREA EN VEZ DE MOVER EL JAMON CON EL COLIDER CON LA FORMA DEL SPRITE
        if (collision.CompareTag("Bala") && !collision.gameObject.GetComponent<Bala>().balaEnemigo)
        {
            //ANIMACION Y SONIDO ENEMIGO PERDIENDO VIDA

            this.gameObject.GetComponent<FuncionalidadEnemigos>().vidaEnemigo -= collision.gameObject.GetComponent<Bala>().damage;
        }
        else if (collision.CompareTag("ArmaMelee") && !collision.gameObject.GetComponent<Arma>().armaEnemigo)
        {
            //ANIMACION Y SONIDO ENEMIGO PERDIENDO VIDA

            GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;

            this.gameObject.GetComponent<FuncionalidadEnemigos>().vidaEnemigo -= collision.gameObject.GetComponent<Arma>().damageArma;
        }
        else if (collision.CompareTag("LegiaArea"))
        {
            legia = true;
        }
        else if (collision.CompareTag("AceiteArea"))
        {
            aceite = true;
        }
        else if (collision.CompareTag("SiropeArea"))
        {
            sirope = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("LegiaArea"))
        {
            legia = true;
            //this.gameObject.GetComponent<FuncionalidadEnemigos>().velocidadEnemigo = 0;
        }
        else if (collision.CompareTag("AceiteArea"))
        {
            aceite = true;
        }
        else if (collision.CompareTag("SiropeArea"))
        {
            sirope = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LegiaArea"))
        {
            legia = false;
            //this.gameObject.GetComponent<Personaje>().moveSpeed = 0;
        }
        else if (collision.CompareTag("AceiteArea"))
        {
            aceite = false;
        }
        else if (collision.CompareTag("SiropeArea"))
        {
            sirope = false;
        }
    }

}
