using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrojado : MonoBehaviour
{
    public float alcance;

    Vector3 mousePosition;
    private float velocidad = 0.02f;

    private float timer = 0f;

    private void Start()
    {
        alcance = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<Arma>().alcanceArma;

        mousePosition = Input.mousePosition;
        mousePosition.z = 10f;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void Update()
    {//NO FUNCIONA LO DEL ALCANCE MAXIMO
        //Cuando pincho en una parte donde se haya superado el alcance maximo se tiene que lanzar al alcance maximo

        transform.position = Vector2.MoveTowards(transform.position, mousePosition, velocidad);
        trayectoria();

        if (mousePosition.Equals(transform.position) && !transform.GetChild(1).gameObject.activeSelf)
        {
            this.gameObject.tag = "LegiaArea";
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            timer = 5f;

            Debug.Log("you garet");
        }

        if (timer >= 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f && transform.GetChild(1).gameObject.activeSelf)
        {
            if (this.gameObject.name.Contains("Legia"))
            {
                foreach (var enemigo in GameObject.FindGameObjectsWithTag("Enemigo"))
                {
                    enemigo.GetComponent<ColisionEnemigos>().legia = false;
                }
            }

            Destroy(this.gameObject);
        }
    }

    private void trayectoria()
    {
        Vector3 posicion = new Vector3();

        posicion = Camera.main.ScreenToWorldPoint(mousePosition);
    }

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
