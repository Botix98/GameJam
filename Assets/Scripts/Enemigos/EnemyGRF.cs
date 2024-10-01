using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGRF : MonoBehaviour
{
    public AIPath aiPath;

    public GameObject cuerpoCP;
    
    public Sprite ciegoPerroFrente;
    public Sprite ciegoPerroPerfil;
    public Sprite ciegoPerroEspalda;
    public Sprite ciegoFrente;

    public Sprite carniceroFrente;
    public Sprite carniceroPerfil;
    public Sprite carniceroEspalda;

    public Sprite viejaCarroFrontal;
    public Sprite viejaCarroPerfil;
    public Sprite viejaCarroEspalda;

    public Sprite viejaFrontal;
    public Sprite viejaPerfil;
    public Sprite viejaEspalda;

    public Sprite reponedorFrontal;
    public Sprite reponedorPerfil;
    public Sprite reponedorEspalda;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name.Contains("Ciego") && !this.gameObject.GetComponent<FuncionalidadEnemigos>().perroSuelto)
        {
            ciegoPerro();
        }
        else if (this.gameObject.name.Contains("Ciego"))
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = ciegoFrente;
        }
        else if (this.gameObject.name.Contains("Carnicero"))
        {
            carnicero();
        }
        else if (this.gameObject.name.Contains("Vieja") && !this.gameObject.GetComponent<FuncionalidadEnemigos>().carroSuelto)
        {
            viejaCarro();
        }
        else if (this.gameObject.name.Contains("Vieja"))
        {
            vieja();
        }
        else if (this.gameObject.name.Contains("Reponedor"))
        {
            reponedor();
        }
    }

    private void reponedor()
    {
        if (aiPath.desiredVelocity.y >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = reponedorEspalda;
        }
        else if (aiPath.desiredVelocity.y <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = reponedorFrontal;
        }
        else if (aiPath.desiredVelocity.x >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = reponedorPerfil;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = reponedorPerfil;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void vieja()
    {
        if (aiPath.desiredVelocity.y >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = viejaEspalda;
        }
        else if (aiPath.desiredVelocity.y <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = viejaFrontal;
        }
        else if (aiPath.desiredVelocity.x >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = viejaPerfil;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = viejaPerfil;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void viejaCarro()
    {
        if (aiPath.desiredVelocity.y >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = viejaCarroEspalda;
        }
        else if (aiPath.desiredVelocity.y <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = viejaCarroFrontal;
        }
        else if (aiPath.desiredVelocity.x >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = viejaCarroPerfil;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = viejaCarroPerfil;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void carnicero()
    {
        if (aiPath.desiredVelocity.y >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = carniceroEspalda;
        }
        else if (aiPath.desiredVelocity.y <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = carniceroFrente;
        }
        else if (aiPath.desiredVelocity.x >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = carniceroPerfil;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = carniceroPerfil;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void ciegoPerro()
    {
        if (aiPath.desiredVelocity.y >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = ciegoPerroEspalda;
        }
        else if (aiPath.desiredVelocity.y <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = ciegoPerroFrente;
        }
        else if (aiPath.desiredVelocity.x >= 0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = ciegoPerroPerfil;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            cuerpoCP.GetComponent<SpriteRenderer>().sprite = ciegoPerroPerfil;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
