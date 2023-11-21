using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasDobles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUps.powerUps.ActivarBalasDobles();
            Destroy(gameObject);
        }
    }
}
