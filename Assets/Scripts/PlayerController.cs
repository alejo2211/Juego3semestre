using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton;
    public bool armado;
    public Shot shot;
    public int dañoMazo;

    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Baculo")
        {
            //print("Baculo recogido");
            GameManager.singleton.StartOleada();

        }
        if (other.tag == "maso")
        {
            //print("Baculo recogido");
            BarraDeVIda.barraVida.RecibirGolpe(dañoMazo);

        }
        if (GameManager.singleton.moneda==800)
        {
            //print("La puerta se puede abrir");
        }


    }

}
