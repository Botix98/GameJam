using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DontDestroyOn : MonoBehaviour
{
    public static DontDestroyOn instancia;

    // Start is called before the first frame update
    void Start()
    {
        if (instancia == null)  //Si es la primera vez que entra en la escena H1, guarda el canvas en la instancia
        {
            instancia = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else //Si la instancia ya tiene un Canvas, elimina el nuevo Canvas"
        {
            Destroy(gameObject);
        }
    }
}
