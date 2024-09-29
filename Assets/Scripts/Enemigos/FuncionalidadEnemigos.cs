using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.UIElements;

public class FuncionalidadEnemigos : MonoBehaviour
{
    //public float velocidadEnemigo;
    public Arma armaEnemigo;
    public int vidaEnemigo = 3;
    public float velocidadEnemigo;

    public GameObject jugador;

    public GameObject balaAux;
    public GameObject balaPrefab;

    private float timer = 0f;

    private float timerLegia = 0f;

    //private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<AIPath>().maxSpeed = velocidadEnemigo;
        //target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        comprobarVida();
        comprobarAceite();
        comprobarLegia();
        comprobarSirope();

        if (armaEnemigo.CompareTag("ArmaDistancia"))
        {
            dispararArma();
        }

        if (timer >= 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timerLegia >= 0)
        {
            timerLegia -= Time.deltaTime;
        }

        //float step = velocidadEnemigo * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
    }

    private void comprobarVida()
    {
        if (vidaEnemigo <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void comprobarLegia()
    {
        if (GetComponent<ColisionEnemigos>().legia && timerLegia <= 0f)
        {
            vidaEnemigo -= 2;
            timerLegia = 1f;
        }
    }

    private void comprobarAceite()
    {
        if (GetComponent<ColisionEnemigos>().aceite)
        {
            this.gameObject.GetComponent<AIPath>().maxSpeed = velocidadEnemigo * 0.5f;
        }
        else if (!GetComponent<ColisionEnemigos>().legia && !GetComponent<ColisionEnemigos>().sirope)
        {
            this.gameObject.GetComponent<AIPath>().maxSpeed = velocidadEnemigo;
        }
    }

    private void comprobarSirope()
    {
        if (GetComponent<ColisionEnemigos>().sirope)
        {
            this.gameObject.GetComponent<AIPath>().maxSpeed = 0f;
        }
        else if (!GetComponent<ColisionEnemigos>().aceite && !GetComponent<ColisionEnemigos>().legia)
        {
            this.gameObject.GetComponent<AIPath>().maxSpeed = velocidadEnemigo;
        }
    }

    public void dispararArma()
    {
        if (timer <= 0f && Mathf.Abs((jugador.transform.position - this.gameObject.transform.position).magnitude) < this.gameObject.transform.GetChild(1).GetComponent<Arma>().alcanceArma)
        {
            Debug.Log("Arma disparada");

            //Que desaparezca si choca con una pared, choca contra un enemigo o llega al rango maximo (calcular la distancia que lleva recorrida)
            balaAux = Instantiate(balaPrefab, armaEnemigo.transform.position, armaEnemigo.transform.rotation);
            balaAux.GetComponent<Bala>().damage = armaEnemigo.damageArma;
            balaAux.GetComponent<Bala>().balaEnemigo = true;

            timer = armaEnemigo.GetComponent<Arma>().cadenciaArma;
            //armaEnemigo.GetComponent<Arma>().municionArma--;
        }
    }
}
