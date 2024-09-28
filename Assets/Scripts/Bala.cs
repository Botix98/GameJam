using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Bala : MonoBehaviour
{
    public float alcance;

    private Rigidbody2D rb;

    //Vector2 posicion;
    Vector2 shootDirection;

    Vector3 mousePosition;
    private float velocidad = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        shootDirection = (mousePosition - transform.position).normalized;

        alcance = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<Arma>().alcanceArma;
    }

    void Update()
    {
        Destroy(this.gameObject, alcance); //El tiempo de destruccion corresponde con el alcance de la bala

        disparo();
    }

    /*private void trayectoriaBala()
    {
        Vector3 posicion = new Vector3();

        posicion = Camera.main.ScreenToWorldPoint(mousePosition);
    }*/

    private void disparo()
    {

        //GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * velocidad;
        //rb.AddForce(shootDirection * velocidad, ForceMode2D.Impulse);
    }

    /*private void disparo()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 shootDirection = (mousePosition - transform.position).normalized;

        //GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection * velocidad, ForceMode2D.Impulse);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pared"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Enemigo"))
        {
            Destroy(this.gameObject, 0.01f);
        }
    }
}