using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraDeVIda : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual=100;
    public float vidaMaxima=100;
    public Text saludTexto;
    public CanvasGroup sangre;
    
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

        sangre.alpha = 1;
    }
}


