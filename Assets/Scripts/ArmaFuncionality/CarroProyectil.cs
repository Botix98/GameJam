using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarroProyectil : MonoBehaviour
{
    public float alcanceMax;
    public int damage;

    Vector2 shootDirection;
    Vector3 posInicialCarro;
    Vector3 mousePosition;

    private float velocidad = 3f;

    Rigidbody2D rb;

    public bool balaEnemigo = false;

    private void Start()
    {
        posInicialCarro = transform.position;

        rb = GetComponent<Rigidbody2D>();

        shootDirection = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
        //alcanceMax = GameObject.FindGameObjectWithTag("Enemigo").transform.GetChild(1).GetComponent<Arma>().alcanceArma * 2;
        alcanceMax = 1000;
    }
    void Update()
    {
        if ((transform.position - posInicialCarro).magnitude < alcanceMax)
        {
            rb.velocity = shootDirection * velocidad;
        }
        else
        {
            //ANIMACION DESTRUCCION DEL CARRO Y SONIDO
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pared"))
        {
            //ANIMACION DESTRUCCION DEL CARRO Y SONIDO
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Player") && balaEnemigo)
        {
            //ANIMACION DESTRUCCION DEL CARRO Y SONIDO
            Destroy(this.gameObject, 0.01f);
        }
    }
}
