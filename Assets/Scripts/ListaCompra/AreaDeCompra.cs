using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDeCompra : MonoBehaviour
{
    private float timer = 0f;
    private bool enArea = false;
    public int indicador;
    public GameObject listaDeLaCompra;

    // Update is called once per frame
    void Update()
    {
        if (enArea)
        {
            timer += Time.deltaTime;
        }
        else if (timer != 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0f)
        {
            timer = 0f;
        }

        if (timer >= 7f)
        {
            //SONIDO Y ANIMACION REACTIVACION ZONAS DE RECUPERACION DE VIDA

            listaDeLaCompra.GetComponent<ListaCompra>().lista[indicador] = true;
            listaDeLaCompra.GetComponent<ListaCompra>().elementosRecogidos++;

            GameObject.Find("RecuperarVida 1").GetComponent<CircleCollider2D>().enabled = true;
            GameObject.Find("RecuperarVida 2").GetComponent<CircleCollider2D>().enabled = true;
            GameObject.Find("RecuperarVida 3").GetComponent<CircleCollider2D>().enabled = true;

            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //ANIMACION DE LA ZONA DEL SUELO DE COMPRAR OBJETOS (DENTRO DE LA ZONA)
            enArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //ANIMACION DE LA ZONA DEL SUELO DE COMPRAR OBJETOS (FUERA DE LA ZONA)
            enArea = false;
        }
    }
}
