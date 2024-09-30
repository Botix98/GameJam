using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ControladorSonidos controladorSonidos;

    public AudioClip musicLevelComplete;

    // Start is called before the first frame update
    void Start()
    {
        controladorSonidos.EjecutarSonido(musicLevelComplete);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
