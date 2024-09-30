using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrojado : MonoBehaviour
{
    public float alcance;
    private Vector3 posInicial;

    Vector2 shootDirection;

    Vector3 mousePosition;
    private float velocidad = 1f;

    private float timer = 0f;

    private Rigidbody2D rb;

    private void Start()
    {
        posInicial = transform.position;

        rb = GetComponent<Rigidbody2D>();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        shootDirection = (mousePosition - transform.position).normalized;

        alcance = this.gameObject.GetComponent<Arma>().alcanceArma;
    }

    void Update()
    {
        if (Mathf.Abs((mousePosition - posInicial).magnitude) >= alcance)
        {
            if ((transform.position - posInicial).magnitude < alcance)
            {
                rb.velocity = shootDirection * velocidad;
            }
            else
            {
                activarArea();
            }
        }
        else
        {
            if ((transform.position - posInicial).magnitude < Mathf.Abs((mousePosition - posInicial).magnitude))
            {
                rb.velocity = shootDirection * velocidad;
            }
            else
            {
                activarArea();
            }
        }

        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f && transform.GetChild(1).gameObject.activeSelf)
        {
            if (this.gameObject.name.Contains("Aceite")  || this.gameObject.name.Contains("Sirope"))
            {
                foreach (var enemigo in GameObject.FindGameObjectsWithTag("Enemigo"))
                {
                    enemigo.GetComponent<ColisionEnemigos>().legia = false;
                }
            }

            if (this.gameObject.name.Contains("Aceite"))
            {
                //ANIMACION DESAPARECER ACEITE
            }
            else if (this.gameObject.name.Contains("Sirope"))
            {
                //ANIMACION DESAPARECER SIROPE
            }

            Destroy(this.gameObject);
        }
    }

    private void activarArea()
    {
        if (!transform.GetChild(1).gameObject.activeSelf)
        {
            rb.velocity = Vector3.zero;
            switch (this.gameObject.tag)
            {
                case "Legia":
                    //ANIMACION Y SONIDO LEGIA CAYENDO Y CREANDO AREA
                    this.gameObject.GetComponent<AudioSource>().Play();
                    this.gameObject.tag = "LegiaArea";
                    break;
                case "Sirope":
                    //ANIMACION Y SONIDO SIROPE CAYENDO Y CREANDO AREA
                    this.gameObject.GetComponent<AudioSource>().Play();
                    this.gameObject.tag = "SiropeArea";
                    break;
                case "Aceite":
                    //ANIMACION Y SONIDO SIROPE CAYENDO Y CREANDO AREA
                    this.gameObject.GetComponent<AudioSource>().Play();
                    this.gameObject.tag = "AceiteArea";
                    break;
            }
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);

            timer = 5f;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pared"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Enemigo"))
        {
            Destroy(this.gameObject, 0.01f);
        }
    }*/
}
