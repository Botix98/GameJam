using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaCompra : MonoBehaviour
{
    public bool[] lista = new bool[4];
    public int elementosRecogidos;

    public AudioClip audiosound;
    public AudioSource fuente;

    private bool activar = true;

    // Start is called before the first frame update
    void Start()
    {
        elementosRecogidos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (elementosRecogidos == 4 && activar)
        {
            activar = false;
            fuente.PlayOneShot(audiosound);
            //ABRIR PUERTA (activar el colider que permite que me vaya del super)
        }
    }
}
