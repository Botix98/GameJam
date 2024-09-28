using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntar : MonoBehaviour
{
    Camera cam;

    //public GameObject armaEquipada;

    //private Transform armaTransform;

    private void Awake()
    {
        cam = Camera.main;
        //armaTransform = transform.Find("Arma");
    }

    /*private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;

        mousePosition = cam.ScreenToWorldPoint(mousePosition);

        //Vector3 mousePosition = Input.mousePosition;

        Vector3 direccionArma = (mousePosition - transform.position).normalized;
        float angulo = Mathf.Atan2(direccionArma.y, direccionArma.x) * Mathf.Rad2Deg;
        armaTransform.eulerAngles = new Vector3(0, 0, angulo);
    }*/

    private void Update()
    {
        apuntar();
    }

    public void apuntar()
    {
        if (this.GetComponent<Personaje>().armaEquipada != null /*armaEquipada != null*/)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;

            mousePosition = cam.ScreenToWorldPoint(mousePosition);

            //Vector3 mousePosition = Input.mousePosition;

            Vector3 direccionArma = (mousePosition - transform.position).normalized;
            float angulo = Mathf.Atan2(direccionArma.y, direccionArma.x) * Mathf.Rad2Deg;
            this.GetComponent<Personaje>().armaEquipada.transform.eulerAngles = new Vector3(0, 0, angulo);
        }
    }
}
