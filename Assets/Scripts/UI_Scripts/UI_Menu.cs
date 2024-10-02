using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_Menu : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject mensajePanel;
    public Toggle Toggle;

    public void Iniciar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void PantallaPrincipal()
    {
        SceneManager.LoadScene("Inicio");
    }


    public void Mensaje()
    {
        if (mensajePanel.activeSelf)
        {
            mensajePanel.SetActive(false);
        }
        else
        {
            mensajePanel.SetActive(true);
        }
    }
    public void Info()
    {
        if (infoPanel.activeSelf)
        {
            infoPanel.SetActive(false);
        }
        else
        {
            infoPanel.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

}
