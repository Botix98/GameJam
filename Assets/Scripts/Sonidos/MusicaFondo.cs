using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaFondo : MonoBehaviour
{
    public AudioSource fuenteMusica;
    public AudioSource fuenteEfectos;

    public AudioClip menuPrincipal;
    public AudioClip entrarJuego;
    public AudioClip empiezaElJuego;
    public AudioClip gameOver;
    public AudioClip gameOverMusic;
    public AudioClip musicaVictoria;

    private bool gameOverBool = false;
    public bool victoriaBool = false;

    private string escenaActual;
    // Start is called before the first frame update
    void Start()
    {
        escenaActual = SceneManager.GetActiveScene().name;

        fuenteMusica.clip = menuPrincipal;
        fuenteMusica.loop = true;
        fuenteMusica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!(escenaActual.Equals(SceneManager.GetActiveScene().name)) && !SceneManager.GetActiveScene().name.Equals("Game_Over"))
        {
            escenaActual = SceneManager.GetActiveScene().name;

            fuenteMusica.Stop();
            fuenteMusica.clip = entrarJuego;
            fuenteMusica.loop = false;
            fuenteMusica.Play();
        }

        if (!fuenteMusica.isPlaying && !gameOverBool)
        {
            fuenteMusica.clip = empiezaElJuego;
            fuenteMusica.loop = true;
            fuenteMusica.Play();
        }

        if (SceneManager.GetActiveScene().name.Equals("SampleScene"))
        {
            if(GameObject.Find("Personaje").GetComponent<Personaje>().vidaPersonaje <= 0)
            {
                gameOverBool = true;
                fuenteMusica.Stop();
                fuenteMusica.clip = gameOver;
                fuenteMusica.loop = false;
                fuenteMusica.Play();
            }
        }

        if (!fuenteMusica.isPlaying && gameOverBool)
        {
            fuenteMusica.clip = empiezaElJuego;
            fuenteMusica.loop = true;
            fuenteMusica.Play();
        }

        if (victoriaBool && !fuenteMusica.clip.name.Equals("music_level_complete"))
        {
            fuenteMusica.Stop();
            fuenteMusica.clip = musicaVictoria;
            fuenteMusica.loop = true;
            fuenteMusica.Play();
        }
    }
}
