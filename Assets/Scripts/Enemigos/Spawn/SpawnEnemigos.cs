using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject meleePrefab;
    public GameObject distanciaPrefab;
    public GameObject abuelaPrefab;
    public GameObject ciegoPrefab;
    public GameObject carniceroPrefab;
    public GameObject reponedorPrefab;

    private float timerMelee = 0f;
    private float timerDistancia = 0f;
    private float timerAbuela = 0f;
    private float timerCiego = 0f;
    private float timerCarnicero = 0f;
    private float timerReponedor = 0f;

    private ListaCompra listaCompra;

    private void Start()
    {
        listaCompra = GameObject.FindObjectOfType<ListaCompra>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerMelee <= 0f)
        {
            enemigoMelee();
            timerMelee = 10f - listaCompra.elementosRecogidos * 2; //PONER AQUI EL TIEMPO DE SPAWN
        }
        if (timerMelee > 0f)
        {
            timerMelee -= Time.deltaTime;
        }

        if (timerDistancia <= 0f)
        {
            enemigoDistancia();
            timerDistancia = 10f - listaCompra.elementosRecogidos * 2; //PONER AQUI EL TIEMPO DE SPAWN
        }
        if (timerDistancia > 0f)
        {
            timerDistancia -= Time.deltaTime;
        }

        if (timerAbuela <= 0f)
        {
            vieja();
            timerAbuela = 10f - listaCompra.elementosRecogidos * 2; //PONER AQUI EL TIEMPO DE SPAWN
        }
        if (timerAbuela > 0f)
        {
            timerAbuela -= Time.deltaTime;
        }

        if (timerCiego <= 0f)
        {
            ciego();
            timerCiego = 10f - listaCompra.elementosRecogidos * 2; //PONER AQUI EL TIEMPO DE SPAWN
        }
        if (timerCiego > 0f)
        {
            timerCiego -= Time.deltaTime;
        }

        if (timerCarnicero <= 0f)
        {
            carnicero();
            timerCarnicero = 10f - listaCompra.elementosRecogidos * 2; //PONER AQUI EL TIEMPO DE SPAWN
        }
        if (timerCarnicero > 0f)
        {
            timerCarnicero -= Time.deltaTime;
        }

        if (timerReponedor <= 0f)
        {
            reponedor();
            timerReponedor = 10f - listaCompra.elementosRecogidos * 2; //PONER AQUI EL TIEMPO DE SPAWN
        }
        if (timerReponedor > 0f)
        {
            timerReponedor -= Time.deltaTime;
        }

    }

    private void reponedor()
    {
        if (this.gameObject.name.Equals("SpawnReponedor"))
        {
            //ANIMACION SPAWN ENEMIGO
            Instantiate(reponedorPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }

    private void carnicero()
    {
        if (this.gameObject.name.Equals("SpawnCarnicero"))
        {
            //ANIMACION SPAWN ENEMIGO
            Instantiate(carniceroPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }

    private void enemigoMelee()
    {
        if (this.gameObject.name.Equals("SpawnMelee"))
        {
            //ANIMACION SPAWN ENEMIGO
            Instantiate(meleePrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }

    private void enemigoDistancia()
    {
        if (this.gameObject.name.Equals("SpawnDistancia"))
        {
            //ANIMACION SPAWN ENEMIGO
            Instantiate(distanciaPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }

    private void vieja()
    {
        if (this.gameObject.name.Equals("SpawnAbuela"))
        {
            //ANIMACION SPAWN ENEMIGO
            Instantiate(abuelaPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }
    private void ciego()
    {
        Debug.Log("CIEGO");
        if (this.gameObject.name.Equals("SpawnCiego"))
        {
            //ANIMACION SPAWN ENEMIGO
            Instantiate(ciegoPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }
}
