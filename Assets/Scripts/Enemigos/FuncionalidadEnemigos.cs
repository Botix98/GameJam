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
    private bool carroDisparado = false;
    private bool perroSoltado = false;

    public GameObject jugador;

    public GameObject balaAux;
    public GameObject carroAux;
    public GameObject bolso;
    public GameObject perro;

    public GameObject balaPrefab;
    public GameObject carroPrefab;
    public GameObject bolsoPrefab;
    public GameObject perroPrefab;
    

    private float timer = 0f;

    private float timerLegia = 0f;

    //private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AIDestinationSetter>().target = GameObject.FindGameObjectWithTag("Player").transform;

        jugador = GameObject.FindGameObjectWithTag("Player");

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
        comprobarDistancia();

        if (armaEnemigo.CompareTag("ArmaDistancia") && !this.gameObject.name.Contains("ViejaCarroYBolso"))
        {
            Debug.Log("Arma a distancia");
            dispararArma();
        }

        if (this.gameObject.name.Contains("ViejaCarroYBolso") && !carroDisparado)
        {
            dispararCarro();
        }

        if (this.gameObject.name.Contains("Ciego") && !perroSoltado)
        {
            soltarPerro();
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

    private void soltarPerro()
    {
        if (timer <= 0f && Mathf.Abs((jugador.transform.position - this.gameObject.transform.position).magnitude) < 5f)
        {
            Debug.Log("Perro soltado");

            //SONIDO PERRO SOLTADO
            perroSoltado = true;
            perro = Instantiate(perroPrefab, transform.position, transform.rotation);
            this.gameObject.GetComponent<AIPath>().enabled = false;
        }
    }

    private void comprobarDistancia()
    {
        if (!this.gameObject.name.Contains("Ciego"))
        {
            if (this.gameObject.transform.GetChild(1).CompareTag("ArmaDistancia"))
            {
                if (Mathf.Abs((this.gameObject.transform.position - GameObject.Find("Personaje").transform.position).magnitude)
                    <= this.gameObject.transform.GetChild(1).GetComponent<Arma>().alcanceArma)
                {
                    this.gameObject.GetComponent<AIPath>().maxSpeed = 0f;
                }
            }
        }
    }

    private void comprobarVida()
    {
        if (vidaEnemigo <= 0)
        {
            //SONIDO Y ANIMACION MURTE ENEMIGO
            Destroy(this.gameObject, 0.1f);
        }
    }

    private void comprobarLegia()
    {
        if (GetComponent<ColisionEnemigos>().legia && timerLegia <= 0f)
        {
            //SONIDO Y ANIMACION ENEMIGO GOLPEADO

            if (this.gameObject.name.Contains("Perro"))
            {
                this.gameObject.GetComponent<SonidosPerro>().dañoPerro();
            }
            else if (this.gameObject.name.Contains("Vieja"))
            {
                this.gameObject.GetComponent<SonidosAbuela>().dañoAbuela();
            }
            else if (this.gameObject.name.Contains("Reponedor"))
            {
                this.gameObject.GetComponent<SonidosReponedor>().dañoReponedor();
            }
            else if (this.gameObject.name.Contains("Ciego"))
            {
                this.gameObject.GetComponent<SonidosCiego>().dañoCiego();
            }
            else if (this.gameObject.name.Contains("Carnicero"))
            {
                this.gameObject.GetComponent<SonidosCarnicero>().dañoCarnicero();
            }

            vidaEnemigo -= 2;
            timerLegia = 1f;
        }
    }

    private void comprobarAceite()
    {
        if (GetComponent<ColisionEnemigos>().aceite)
        {
            //SONIDO Y ANIMACION ENEMIGO RALENTIZADO
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
            //SONIDO Y ANIMACION ENEMIGO RALENTIZADO
            this.gameObject.GetComponent<AIPath>().maxSpeed = 0f;
        }
        else if (!GetComponent<ColisionEnemigos>().aceite && !GetComponent<ColisionEnemigos>().legia)
        {
            this.gameObject.GetComponent<AIPath>().maxSpeed = velocidadEnemigo;
        }
    }

    public void dispararCarro()
    {
        if (timer <= 0f && Mathf.Abs((jugador.transform.position - this.gameObject.transform.position).magnitude) < 5f)
        {
            Debug.Log("Carro disparado");

            //SONIDO CARRO LANZADO (empieza a sonar cuando se crea el carro)

            carroDisparado = true;

            bolso = Instantiate(bolsoPrefab, transform.position, transform.rotation);
            bolso.transform.parent = this.transform;

            carroAux = Instantiate(carroPrefab, armaEnemigo.transform.position, armaEnemigo.transform.rotation);
            carroAux.GetComponent<CarroProyectil>().damage = armaEnemigo.damageArma;
            carroAux.GetComponent<CarroProyectil>().balaEnemigo = true;

            timer = armaEnemigo.GetComponent<Arma>().cadenciaArma;

            armaEnemigo = bolso.GetComponent<Arma>();

            Destroy(this.gameObject.transform.GetChild(1).gameObject);
            //armaEnemigo.GetComponent<Arma>().municionArma--;
        }
    }

    public void dispararArma()
    {
        if (timer <= 0f && Mathf.Abs((jugador.transform.position - this.gameObject.transform.position).magnitude) < this.gameObject.transform.GetChild(1).GetComponent<Arma>().alcanceArma)
        {
            Debug.Log("Arma disparada");

            //SONIDO Y ANIMACION BALA DISPARADA

            //Que desaparezca si choca con una pared, choca contra un enemigo o llega al rango maximo (calcular la distancia que lleva recorrida)
            balaAux = Instantiate(balaPrefab, armaEnemigo.transform.position, armaEnemigo.transform.rotation);
            balaAux.GetComponent<Bala>().damage = armaEnemigo.damageArma;
            balaAux.GetComponent<Bala>().balaEnemigo = true;

            timer = armaEnemigo.GetComponent<Arma>().cadenciaArma;
            //armaEnemigo.GetComponent<Arma>().municionArma--;
        }
    }
}
