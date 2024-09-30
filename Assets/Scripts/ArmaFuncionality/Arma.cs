using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public int municionArma;
    public string nombreArma;
    public int alcanceArma;
    public int damageArma;
    public float cadenciaArma;
    public bool areaArma;
    public int valorArea = 10;
    public int tiempoAreaArma = 10;
    public bool armaDistancia;
    public bool armaEnemigo = false;

    private void Update()
    {
        if (municionArma == 0)
        {
            //ANIMIACION Y SONIDO CUANDO EL ARMA SE DESTRUYE POR FALTA DE MUNICION
            Destroy(this.gameObject, 0.5f);
        }
    }
}
