using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararArma : MonoBehaviour
{
    //public Arma arma;

    private float timer = 0f;

    public GameObject balaPrefab;

    public GameObject balaAux;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dispararArma();

        if (timer >= 0f)
        {
            timer -= Time.deltaTime;
        }
    }

    public void dispararArma()
    {
        if (this.GetComponent<Personaje>().armaEquipada != null)
        {
            if (Input.GetMouseButtonDown(0) && timer <= 0f)
            {
                Debug.Log("Arma disparada");

                //Que vaya en la direccion del raton
                //Que desaparezca si choca con una pared, choca contra un enemigo o llega al rango maximo
                balaAux = Instantiate(balaPrefab, this.GetComponent<Personaje>().armaEquipada.transform.position, this.GetComponent<Personaje>().armaEquipada.transform.rotation);

                timer = this.GetComponent<Personaje>().armaEquipada.GetComponent<Arma>().cadenciaArma;
                this.GetComponent<Personaje>().armaEquipada.GetComponent<Arma>().municionArma--;
            }
        }
    }
}
