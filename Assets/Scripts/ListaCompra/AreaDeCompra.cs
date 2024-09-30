using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDeCompra : MonoBehaviour
{
    private float timer = 0f;
    private bool enArea = false;
    public int indicador;
    public GameObject listaDeLaCompra;

    public AudioSource sonidoComprar;
    public AudioClip sonido;

    private bool activar = true;

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

            //ANIMACION Y SONIDO ELEMENTO COMPRADO
            if (activar)
            {
                listaDeLaCompra.GetComponent<ListaCompra>().lista[indicador] = true;
                listaDeLaCompra.GetComponent<ListaCompra>().elementosRecogidos++;
                activar = false;

                if (!(listaDeLaCompra.GetComponent<ListaCompra>().elementosRecogidos == 4))
                {
                    sonidoComprar.PlayOneShot(sonido);
                }
            }

            //SONIDO Y ANIMACION REACTIVACION ZONAS DE RECUPERACION DE VIDA

            GameObject.Find("RecuperarVida 1").GetComponent<CircleCollider2D>().enabled = true;
            GameObject.Find("RecuperarVida 2").GetComponent<CircleCollider2D>().enabled = true;
            GameObject.Find("RecuperarVida 3").GetComponent<CircleCollider2D>().enabled = true;

            Destroy(this.gameObject, 1f);
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
