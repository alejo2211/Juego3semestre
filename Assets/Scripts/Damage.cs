using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&other.GetComponent<BarraDeVIda>())
        {
            other.GetComponent<BarraDeVIda>().RecibirGolpe(damage);
        }
    }


}
