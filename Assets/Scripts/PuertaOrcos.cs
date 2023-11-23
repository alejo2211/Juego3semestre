using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaOrcos : MonoBehaviour
{
    public int monedasPuerta;
    public GameObject panelPuerta;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (monedasPuerta >= GameManager.singleton.moneda)
            {
                print("Faltan Monedas para abrir la puerta");
                panelPuerta.SetActive(true);
            }
            if (GameManager.singleton.moneda >= monedasPuerta)
            {
                GameManager.singleton.GastarMondeas(monedasPuerta);
                Destroy(gameObject);

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
