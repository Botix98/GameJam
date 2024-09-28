using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour
{

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        //Debug.DrawRay(transform.position, mousePos - transform.position, Color.green);

        //if (Input.GetMouseButtonDown(0))
        //{
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100)) //AÑADIR LA DISTANCIA MAXIMA DONDE EL 100
            {
                Debug.DrawRay(transform.position, mousePos - transform.position, Color.red);
                Debug.Log(hit.transform.name);
            }
            else
            {
                Debug.DrawRay(transform.position, mousePos - transform.position, Color.green);
            }
        //}
    }

    /*RaycastHit2D rchit;

    public float distancia;

    private void Update()
    {
        rchit = Physics2D.Raycast(gameObject.transform.position, Input.mousePosition, distancia);
        if(rchit.collider != null)
        {
            Debug.DrawRay(gameObject.transform.position, Input.mousePosition, Color.green);
        }
        else
        {
            Debug.DrawRay(gameObject.transform.position, Input.mousePosition, Color.red);
        }
    }*/
}
