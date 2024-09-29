using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaCompra : MonoBehaviour
{
    public bool[] lista = new bool[4];
    private bool completa = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in lista)
        {
            if (!item)
            {
                completa = false;
            }
        }

        if (completa)
        {
            //ABRIR PUERTA (activar el colider que permite que me vaya del super)
        }
    }
}
