using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosReponedor : MonoBehaviour
{
    public AudioClip andarReponedor;
    public AudioClip golpeadoReponedor;

    public AudioSource fuenteReponedor;
    public AudioSource fuenteAndar;

    private void Start()
    {

        fuenteAndar.clip = andarReponedor;
        fuenteAndar.Play();
    }

    public void dañoReponedor()
    {
        fuenteReponedor.PlayOneShot(golpeadoReponedor);
    }
}
