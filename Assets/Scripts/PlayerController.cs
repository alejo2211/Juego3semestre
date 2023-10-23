using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton;

  
    public int vidaMaximaPlayer = 100;
    public int vidaActualPlayer;
    public Text textoVida;
    
    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
        
        vidaActualPlayer = vidaMaximaPlayer;
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RecibirDaño(5);
        }

    }
   

   
    public void RecibirDaño(int cantidadDaño)
    {
        Debug.Log("daño causado" + cantidadDaño);
        vidaActualPlayer -= cantidadDaño;
        if (vidaActualPlayer == 0)
        {
            //Metodo o Estado Morir
            Debug.Log("Muerto......");

            Destroy(gameObject);

            DatosUsuario.singleton.ActualizarDatos(GameManager.singleton.Puntosenemigos,GameManager.singleton.oleadas);


        }
        ActualizarTextoVida();
    }

    public void ActualizarTextoVida()
    {
        if (textoVida != null)
        {
            textoVida.text = " " + vidaActualPlayer.ToString();
        }
    }

}
