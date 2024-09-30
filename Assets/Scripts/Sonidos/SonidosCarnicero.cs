using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosCarnicero : MonoBehaviour
{
    public AudioClip andarCarnicero;
    public AudioClip golpeadoCarnicero;

    public AudioSource fuenteCarnicero;
    public AudioSource fuenteAndar;

    private void Start()
    {
        fuenteAndar.clip = andarCarnicero;
        fuenteAndar.Play();
    }

    public void dañoCarnicero()
    {
        fuenteCarnicero.PlayOneShot(golpeadoCarnicero);
    }
}
