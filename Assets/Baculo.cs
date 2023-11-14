using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baculo : MonoBehaviour
{
    public GameObject arma;
    public Animator aniArma;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            arma.SetActive(true);
            gameObject.SetActive(false);
            aniArma.SetBool("Arma", true);
        }
    }
}
