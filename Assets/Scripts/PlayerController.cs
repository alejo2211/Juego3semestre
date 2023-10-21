using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton;

  
    public int vidaMaximaPlayer = 100;
    private int vidaActualPlayer;
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

            SceneManager.LoadScene("GameOver");


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
