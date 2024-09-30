using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosCarro : MonoBehaviour
{
    public AudioClip carroGolpeado;

    public AudioSource fuenteCarro;

    public void carroChocando()
    {
        fuenteCarro.Pause();
        fuenteCarro.clip = carroGolpeado;
        fuenteCarro.Play();

    }
}
