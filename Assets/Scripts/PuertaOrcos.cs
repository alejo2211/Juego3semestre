using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaOrcos : MonoBehaviour
{
    public int monedasPuerta;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (monedasPuerta >= GameManager.singleton.moneda)
            {
                print("Faltan Monedas para abrir la puerta");
            }
            if (GameManager.singleton.moneda >= monedasPuerta)
            {
                GameManager.singleton.GastarMondeas(monedasPuerta);
                Destroy(gameObject);

            }
        }
    }
}
