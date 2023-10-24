using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BarraDeVIda : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual=100;
    public float vidaMaxima=100;
    public Text saludTexto;
    public CanvasGroup sangre;
    public Animator animatorMuerte;
    
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
            StartCoroutine(MuerteEscena());
        }

        sangre.alpha = 1;
    }

    IEnumerator MuerteEscena()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameOver");
    }
}


