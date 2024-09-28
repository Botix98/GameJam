using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncionalidadEnemigos : MonoBehaviour
{
    public float velocidadEnemigo = 2.5f;
    public Arma armaEnemigo;
    public int vidaEnemigo;

    private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<ColisionEnemigos>().legia);
        if (GetComponent<ColisionEnemigos>().legia)
        {
            velocidadEnemigo = 0f;
        }
        else
        {
            velocidadEnemigo = 2.5f;
        }

        float step = velocidadEnemigo * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
    }
}
