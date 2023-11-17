using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasRapidas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUps.powerUps.ActivarBalasRapidas();
        }
    }
}
