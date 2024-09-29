using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_Menu : MonoBehaviour
{
    public GameObject infoPanel;
    public Toggle Toggle;

    public void Iniciar()
    {
        SceneManager.LoadScene("SampleScene");
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
