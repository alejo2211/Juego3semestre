using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PanelPause;
    public GameObject PanelJuego;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            PanelPause.SetActive(true);
            PanelJuego.SetActive(false);
            Debug.Log("Presionaste ESC");
            
        }
        else
        {
            Time.timeScale = 1;
            PanelPause.SetActive(false);
            PanelJuego.SetActive(true);
        }
    }

    public void Cerrar()
    {
        Application.Quit();
        Debug.Log("saliste");
    }
}