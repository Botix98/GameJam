using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosCiego : MonoBehaviour
{
    public AudioClip golpeadoCiego;

    public AudioSource fuenteCiego;

    public void da�oCiego()
    {
        fuenteCiego.PlayOneShot(golpeadoCiego);
    }
}
