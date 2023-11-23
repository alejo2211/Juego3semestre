using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasController : MonoBehaviour
{
    public int monedasPuerta;
    public bool puertaAbierta;
    public Animator animacionPuerta;
    public GameObject panelPuerta;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (monedasPuerta>=GameManager.singleton.moneda)
            {
                print("Faltan Monedas para abrir la puerta");
                panelPuerta.SetActive(true);
            }
            if (GameManager.singleton.moneda>=monedasPuerta)
            {
                GameManager.singleton.GastarMondeas(monedasPuerta);
                animacionPuerta.SetBool("PuertaAbierta", true);
                
            }
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panelPuerta.SetActive(false);
        }
    }
}
