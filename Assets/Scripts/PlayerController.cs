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
    public float velocidadRotacion = 5.0f;
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
   

   
    public void RecibirDa�o(int cantidadDa�o)
    {
        Debug.Log("da�o causado" + cantidadDa�o);
        vidaActualPlayer -= cantidadDa�o;
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
