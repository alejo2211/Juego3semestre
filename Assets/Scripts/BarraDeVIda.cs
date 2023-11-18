using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BarraDeVIda : MonoBehaviour
{
    public static BarraDeVIda barraVida;
    public Image barraDeVida;
    public float vidaActual=100;
    public float vidaMaxima=100;
    public Text saludTexto;
    public CanvasGroup sangre;
    public Animator animatorMuerte;
    public GameObject panelGameOver;

    private void Awake()
    {
        barraVida = this;
    }
    void Update()
    {
        if (sangre.alpha>0)
        {
            sangre.alpha -= Time.deltaTime;
        }
        ActulizarInterfaz();

    }

    public void ActulizarInterfaz()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
        saludTexto.text = "Salud: " + vidaActual.ToString("f0");
    }

    public void RecibirGolpe(float golpe)
    {
        
        vidaActual -= golpe;
        if (vidaActual==0)
        {
            animatorMuerte.SetTrigger("muerteElfo");
            Pause();
            panelGameOver.SetActive(true);  
            
        }
        else if (vidaActual>vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
        sangre.alpha = 1;
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}


