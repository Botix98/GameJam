using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararArma : MonoBehaviour
{
    //public Arma arma;

    private float timer = 0f;

    public GameObject balaPrefab;
    public GameObject aceitePrefab;
    public GameObject lejiaPrefab;
    public GameObject siropePrefab;

    public AudioClip sonidoLanzarEquipamiento;
    public AudioClip sonidoAtaqueMelee;

    public GameObject balaAux;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Personaje>().armaEquipada != null)
        {
            if (this.gameObject.transform.GetChild(1).GetComponent<Arma>().areaArma)
            {
                equipamiento();
            }
            else if (this.gameObject.transform.GetChild(1).GetComponent<Arma>().armaDistancia)
            {
                dispararArma();
            }
            else
            {
                ataqueMelee();
            }
            
        }

        if (timer >= 0f)
        {
            timer -= Time.deltaTime;
        }
    }

    public void equipamiento()
    {
        if (Input.GetMouseButtonDown(0) && timer <= 0f)
        {
            //SONIDO LANZAR EQUIPAMIENTO

            GameObject.Find("SonidoManager").GetComponent<AudioSource>().PlayOneShot(sonidoLanzarEquipamiento);

            Debug.Log("Equipamiento");
            switch (this.gameObject.transform.GetChild(1).GetComponent<Arma>().tag)
            {
                case "Sirope":
                    balaAux = Instantiate(siropePrefab, this.GetComponent<Personaje>().armaEquipada.transform.position, this.GetComponent<Personaje>().armaEquipada.transform.rotation);
                    break;
                case "Aceite":
                    balaAux = Instantiate(aceitePrefab, this.GetComponent<Personaje>().armaEquipada.transform.position, this.GetComponent<Personaje>().armaEquipada.transform.rotation);
                    break;
                case "Legia":
                    balaAux = Instantiate(lejiaPrefab, this.GetComponent<Personaje>().armaEquipada.transform.position, this.GetComponent<Personaje>().armaEquipada.transform.rotation);
                    break;
            }
            Destroy(this.GetComponent<Personaje>().armaEquipada);
        }
    }

    public void ataqueMelee()
    {
        if (Input.GetMouseButtonDown(0) && timer <= 0f)
        {
            //ANIMACION ATAQUE ARMA Y SONIDO ATAQUE ARMA

            GameObject.Find("SonidoManager").GetComponent<AudioSource>().PlayOneShot(sonidoAtaqueMelee);

            Debug.Log("Ataque");

            //METER ANIMACION DE USO DE ARMA
            //HACER UN ARMA PARA EL PERRO
            
            this.gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;

            timer = this.GetComponent<Personaje>().armaEquipada.GetComponent<Arma>().cadenciaArma;
            this.GetComponent<Personaje>().armaEquipada.GetComponent<Arma>().municionArma--;
        }
    }

    public void dispararArma()
    {
        if (Input.GetMouseButtonDown(0) && timer <= 0f)
        {
            //ANIMACION DISPARAR Y SONIDO DISPARO
            Debug.Log("Arma disparada");

            balaAux = Instantiate(balaPrefab, this.GetComponent<Personaje>().armaEquipada.transform.position, this.GetComponent<Personaje>().armaEquipada.transform.rotation);
            balaAux.GetComponent<Bala>().damage = this.gameObject.transform.GetChild(1).GetComponent<Arma>().damageArma;

            /*if (this.gameObject.transform.GetChild(1).GetComponent<Arma>().armaEnemigo)
            {
                balaAux.GetComponent<Bala>().balaEnemigo = true;
            }*/

            timer = this.GetComponent<Personaje>().armaEquipada.GetComponent<Arma>().cadenciaArma;
            this.GetComponent<Personaje>().armaEquipada.GetComponent<Arma>().municionArma--;
        }
    }
}
