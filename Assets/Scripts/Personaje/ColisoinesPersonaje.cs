using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisoinesPersonaje : MonoBehaviour
{
    //public Personaje personaje;
    public bool enArea;
    private bool enAreaRecuperacion;
    public string nombreArma;
    public bool ralentizado = false;

    private GameObject area;

    private float timerEmbutido = 0f;
    private float timerBolso = 0f;
    private float timerPerro = 0f;
    private float timerRalentizado = 0f;

    private float timerInvulnerabilidad = 0f;
    private bool invulnerabilidad = false;

    public AudioClip sonidoRecuperarVida;
    public AudioClip sonidoGolpePersonaje1;
    public AudioClip sonidoGolpePersonaje2;

    public GameObject pantallaBlanco;
    private Color colorAlpha;
    private bool victoria;
    private bool derrota;

    private void Start()
    {
        colorAlpha = pantallaBlanco.GetComponent<SpriteRenderer>().color;
        victoria = false;
        derrota = false;
    }

    private void Update()
    {
        if (timerEmbutido >= 0f)
        {
            timerEmbutido -= Time.deltaTime;
        }
        
        if (timerBolso >= 0f)
        {
            timerBolso -= Time.deltaTime;
        }

        if (timerPerro >= 0f)
        {
            timerPerro -= Time.deltaTime;
        }

        if (timerRalentizado >= 0f)
        {
            timerRalentizado -= Time.deltaTime;
        }

        if(timerInvulnerabilidad >= 0f)
        {
            timerInvulnerabilidad -= Time.deltaTime;
            invulnerabilidad = true;
        }
        else
        {
            invulnerabilidad = false;
        }

        if (timerRalentizado < 0f)
        {
            ralentizado = false;
        }

        if (victoria)
        {
            colorAlpha.a = Mathf.Lerp(colorAlpha.a, 1f, 0.05f);
            pantallaBlanco.GetComponent<SpriteRenderer>().color = colorAlpha;
        }

        if (derrota)
        {
            colorAlpha = Color.black;
            colorAlpha.a = 1f;
            colorAlpha.a = Mathf.Lerp(colorAlpha.a, 1f, 0.05f);
            pantallaBlanco.GetComponent<SpriteRenderer>().color = colorAlpha;
        }

        recuperacion();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ArmaSuelo"))
        {
            Debug.Log("Entras");
            enArea = true;

            if (this.gameObject.GetComponent<Personaje>().armaAux == null)
            {
                nombreArma = collision.gameObject.GetComponent<Arma>().nombreArma;
                Debug.Log(nombreArma);
            }

            //personaje.cogerArma();
        }
        
        if (!invulnerabilidad)
        {   
            if (collision.CompareTag("Bala") && collision.gameObject.GetComponent<Bala>().balaEnemigo)
            {
                this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Bala>().damage;
                this.gameObject.GetComponent<Personaje>().actualizarVida();
                comprobarVida();

                timerInvulnerabilidad = 0.5f;
                //ANIMACION Y SONIDO DE GOLPEO AL PERSONAJE
                sonidoGolpePersonaje();
            }
            if (collision.name.Contains("Carro") && !collision.name.Contains("Vieja"))
            {
                ralentizado = true;
                timerRalentizado = 3f;

                this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
                this.gameObject.GetComponent<Personaje>().actualizarVida();
                comprobarVida();

                timerInvulnerabilidad = 0.5f;
                //ANIMACION Y SONIDO DE GOLPEO AL PERSONAJE
                sonidoGolpePersonaje();
            }
        }

        if (collision.CompareTag("RecuperarVida"))
        {
            enAreaRecuperacion = true;
            area = collision.gameObject;
        }

        if (collision.name.Equals("Victoria")){
            //FIN DEL JUEGO CON VICTORIA

            victoria = true;

            GameObject.Find("Musica").GetComponent<MusicaFondo>().victoriaBool = true;

            Invoke("escenaVictoria", 1f);
        }

        /*Debug.Log(collision.name);
        if (collision.name.Contains("Perro"))
        {
            Debug.Log("Colision con el perro");
            if (timerPerro <= 0f)
            {
                timerPerro = collision.gameObject.GetComponent<Arma>().cadenciaArma;
                this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
                comprobarVida();
            }
        }*/
    }

    private void escenaVictoria()
    {
        SceneManager.LoadScene("Victoria");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ArmaMelee") && collision.gameObject.GetComponent<Arma>().armaEnemigo)
        {
            //IR AÑADIENDO LAS ARMAS DE LOS ENEMIGOS CON UN TIMER ARRIBA
            switch (collision.gameObject.name)
            {
                case "Embutido (1)":
                    if (timerEmbutido <= 0f)
                    {
                        timerEmbutido = collision.gameObject.GetComponent<Arma>().cadenciaArma;
                        this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
                        this.gameObject.GetComponent<Personaje>().actualizarVida();
                        comprobarVida();
                    }
                    break;
                case "Bolso(Clone)":
                    if (timerBolso <= 0f)
                    {
                        timerBolso = collision.gameObject.GetComponent<Arma>().cadenciaArma;
                        this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
                        this.gameObject.GetComponent<Personaje>().actualizarVida();
                        comprobarVida();
                    }
                    break;
                case "PerroArma":
                    if (timerPerro <= 0f)
                    {
                        timerPerro = collision.gameObject.GetComponent<Arma>().cadenciaArma;
                        this.gameObject.GetComponent<Personaje>().vidaPersonaje -= collision.gameObject.GetComponent<Arma>().damageArma;
                        this.gameObject.GetComponent<Personaje>().actualizarVida();
                        comprobarVida();
                    }
                    break;
            }
            timerInvulnerabilidad = 0.5f;
            //ANIMACION Y SONIDO DE GOLPEO AL PERSONAJE
            sonidoGolpePersonaje();
        }
    }

    private void sonidoGolpePersonaje()
    {
        int n = Random.Range(0,2);

        if (n == 0)
        {
            this.gameObject.GetComponent<Personaje>().sonidosPersonaje.PlayOneShot(sonidoGolpePersonaje1);
        }
        else
        {
            this.gameObject.GetComponent<Personaje>().sonidosPersonaje.PlayOneShot(sonidoGolpePersonaje2);
        }
    }

    private void recuperacion()
    {
        if (Input.GetButton("CogerObjeto") && enAreaRecuperacion)
        {
            //ANIMACION Y SONIDO RECUPERAR VIDA

            this.gameObject.GetComponent<Personaje>().sonidosPersonaje.PlayOneShot(sonidoRecuperarVida);

            if (area.name.Contains("2") || area.name.Contains("3"))
            {
                //ANIMACION ZONA DE RECUPERACION DE VIDA DESACTIVADA

                GameObject.Find("RecuperarVida 2").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("RecuperarVida 3").GetComponent<SpriteRenderer>().enabled = false;

                GameObject.Find("RecuperarVida 2").GetComponent<CircleCollider2D>().enabled = false;
                GameObject.Find("RecuperarVida 3").GetComponent<CircleCollider2D>().enabled = false;

                if (this.gameObject.GetComponent<Personaje>().vidaPersonaje >= 7)
                {
                    this.gameObject.GetComponent<Personaje>().vidaPersonaje = 15;
                }
                else
                {
                    this.gameObject.GetComponent<Personaje>().vidaPersonaje += 8;
                }
            }
            else
            {
                //ANIMACION ZONA DE RECUPERACION DE VIDA DESACTIVADA
                GameObject.Find("RecuperarVida 1").GetComponent<CircleCollider2D>().enabled = false;
                GameObject.Find("RecuperarVida 1").GetComponent<SpriteRenderer>().enabled = false;
                if (this.gameObject.GetComponent<Personaje>().vidaPersonaje >= 12)
                {
                    this.gameObject.GetComponent<Personaje>().vidaPersonaje = 15;
                }
                else
                {
                    this.gameObject.GetComponent<Personaje>().vidaPersonaje += 3;
                }
            }
            this.gameObject.GetComponent<Personaje>().actualizarVida();
        }
    }

    private void comprobarVida()
    {


        if (this.gameObject.GetComponent<Personaje>().vidaPersonaje <= 0)
        {
            //GAME OVER

            //ANIMACION Y SONIDO DE CUANDO MUERES

            derrota = true;

            Camera.main.transform.parent = null;

            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;

            Invoke("escenaDerrota", 1f);
        }
    }

    private void escenaDerrota()
    {
        SceneManager.LoadScene("Game_Over");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ArmaSuelo"))
        {
            if (!this.gameObject.GetComponent<Personaje>().armaCogida)
            {
                Destroy(this.gameObject.GetComponent<Personaje>().armaAux);
            }
            else
            {
                this.gameObject.GetComponent<Personaje>().armaAux = null;
                this.gameObject.GetComponent<Personaje>().armaCogida = false;
            }

            Debug.Log("Sales");
            enArea = false;
        }

        if (collision.CompareTag("RecuperarVida"))
        {
            enAreaRecuperacion = false;
        }
    }
}
