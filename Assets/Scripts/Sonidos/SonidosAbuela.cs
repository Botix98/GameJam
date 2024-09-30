using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosAbuela : MonoBehaviour
{
    public AudioClip andarAbuela;
    public AudioClip ataqueAbuela;
    public AudioClip golpeadaAbuela1;
    public AudioClip golpeadaAbuela2;
    public AudioClip aparicionAbuela;

    public AudioSource fuenteAbuela;
    public AudioSource fuenteAndar;

    private void Start()
    {
        fuenteAbuela.PlayOneShot(aparicionAbuela);

        //fuenteAndar.clip = andarAbuela;
        //fuenteAndar.Play();
    }

    public void dañoAbuela()
    {
        if (Random.Range(0, 2) == 0)
        {
            fuenteAbuela.PlayOneShot(golpeadaAbuela1);
        }
        else
        {
            fuenteAbuela.PlayOneShot(golpeadaAbuela2);
        }

    }
}
