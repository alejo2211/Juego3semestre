using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUps.powerUps.ActivarMunicion();
            Shot.shot.AumentarMunicion();
        }
    }
}
