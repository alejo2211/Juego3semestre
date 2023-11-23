using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeTuto : MonoBehaviour
{
    public GameObject mensajeTutorial;
   
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("mensaje");
            mensajeTutorial.SetActive(true);
         
        }
        else
        {
            mensajeTutorial.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("No hay mensaje ");
            mensajeTutorial.SetActive(false);
        }
    }


}
