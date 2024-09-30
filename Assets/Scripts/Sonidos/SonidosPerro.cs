using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosPerro : MonoBehaviour
{
    public AudioClip andarPerro;
    public AudioClip ladridoPerro;
    public AudioClip golpeadoPerro;

    public AudioSource fuentePerro;
    public AudioSource fuenteAndar;

    private void Start()
    {
        Invoke("ladrido", 0.1f);
        Invoke("ladrido", 0.5f);
        //fuenteAndar.clip = andarPerro;
        //fuenteAndar.Play();
    }

    private void ladrido()
    {
        fuentePerro.PlayOneShot(ladridoPerro);
    }

    public void dañoPerro()
    {
        fuentePerro.PlayOneShot(golpeadoPerro);
    }
    
}
