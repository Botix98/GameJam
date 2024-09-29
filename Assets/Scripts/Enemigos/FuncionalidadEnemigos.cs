using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionalidadEnemigos : MonoBehaviour
{
    public float velocidadEnemigo = 2.5f;
    public Arma armaEnemigo;
    public int vidaEnemigo = 3;

    public GameObject balaAux;
    public GameObject balaPrefab;

    private float timer = 0f;
    
    //private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<ColisionEnemigos>().legia);
        if (GetComponent<ColisionEnemigos>().legia)
        {
            velocidadEnemigo = 0f;
        }
        else
        {
            velocidadEnemigo = 2.5f;
        }

        if (armaEnemigo.CompareTag("ArmaDistancia"))
        {
            dispararArma();
        }

        if (timer >= 0f)
        {
            timer -= Time.deltaTime;
        }

        //float step = velocidadEnemigo * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
    }

    public void dispararArma()
    {
        if (timer <= 0f)
        {
            Debug.Log("Arma disparada");

            //Que vaya en la direccion del raton
            //Que desaparezca si choca con una pared, choca contra un enemigo o llega al rango maximo (calcular la distancia que lleva recorrida)
            balaAux = Instantiate(balaPrefab, armaEnemigo.transform.position, armaEnemigo.transform.rotation);
            balaAux.GetComponent<Bala>().damage = armaEnemigo.damageArma;
            balaAux.GetComponent<Bala>().balaEnemigo = true;

            timer = armaEnemigo.GetComponent<Arma>().cadenciaArma;
            //armaEnemigo.GetComponent<Arma>().municionArma--;
        }
    }
}
