using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton;

    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Baculo")
        {
            GameManager gm = GameObject.Find("Componentes/Morgoth").GetComponent<GameManager>();
            gm.StartOleada();

        }
    }

}
