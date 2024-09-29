using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Bala : MonoBehaviour
{
    public float alcanceMax;
    //public float alcance;

    public int damage;

    //private Rigidbody2D rb;

    //Vector2 posicion;
    Vector2 shootDirection;

    Vector3 posInicialBala;

    Vector3 mousePosition;
    private float velocidad = 10f;

    Rigidbody2D rb;

    public bool balaEnemigo = false;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();

        posInicialBala = transform.position;

        rb = GetComponent<Rigidbody2D>();

        if (!balaEnemigo)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            shootDirection = (mousePosition - transform.position).normalized;

            //alcance = (mousePosition - transform.position).magnitude;

            alcanceMax = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<Arma>().alcanceArma;

            //if (alcance > alcanceMax)
            //{
            //    alcance = alcanceMax;
            //}
        }
        else
        {
            shootDirection = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;

            alcanceMax = GameObject.FindGameObjectWithTag("Enemigo").transform.GetChild(1).GetComponent<Arma>().alcanceArma;
        }
    }

    void Update()
    {
        if ((transform.position - posInicialBala).magnitude < alcanceMax)
        {
            rb.velocity = shootDirection * velocidad;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /*void Update()
    {
        Debug.Log("---------------------");
        Debug.Log("Alcance:    " + alcance);
        Debug.Log("Recorrido:  " + (transform.position - mousePosition).magnitude);
        Debug.Log("Diferencia: " + (alcance - (transform.position - mousePosition).magnitude));
        Destroy(this.gameObject, alcanceMax); //El tiempo de destruccion corresponde con el alcance de la bala
        if (alcance - (transform.position - mousePosition).magnitude < alcance)
        {
            rb.velocity = shootDirection * velocidad;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pared"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Enemigo") && !balaEnemigo)
        {
            Destroy(this.gameObject, 0.01f);
        }
        else if(collision.CompareTag("Player") && balaEnemigo)
        {
            Destroy(this.gameObject, 0.01f);
        }
    }


    /*private void disparo()
    {

        //GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        rb.velocity = shootDirection * velocidad;
        //rb.AddForce(shootDirection * velocidad, ForceMode2D.Impulse);
    }*/

    /*private void disparo()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 shootDirection = (mousePosition - transform.position).normalized;

        //GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection * velocidad, ForceMode2D.Impulse);
    }*/
}