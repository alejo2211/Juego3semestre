using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasController : MonoBehaviour
{
    public int monedasPuerta;
    public bool puertaAbierta;
    public Animator animacionPuerta;
    public GameObject panelPuerta;
    public Collider puertaCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (monedasPuerta>=GameManager.singleton.moneda)
            {
                print("Faltan Monedas para abrir la puerta");
                panelPuerta.SetActive(true);
                if (puertaAbierta==true)
                {
                    panelPuerta.SetActive(false);
                    Destroy(puertaCollider);
                }
            }
            if (GameManager.singleton.moneda>=monedasPuerta)
            {
                puertaAbierta = true;
                GameManager.singleton.GastarMondeas(monedasPuerta);
                animacionPuerta.SetBool("PuertaAbierta", true);
                panelPuerta.SetActive(false);
                
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
