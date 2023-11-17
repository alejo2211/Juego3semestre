using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class PowerUps : MonoBehaviour
{
    public static PowerUps powerUps;
    public bool vidaActiva;
    public bool dañoDobleActiva;
    public bool dañoRapidoActiva;
    public bool municionActiva;

    public Button btVida;
    public Button btDañoDoble;
    public Button btDañoRapido;
    public Button btMunicion;
    public InputActionProperty flechaArriba;
    public int vida=15;
    private void Awake()
    {
        powerUps = this;
        btVida.interactable = false;
        btDañoDoble.interactable = false;
        btDañoRapido.interactable = false;
        btMunicion.interactable = false;
    }

    private void Start()
    {
        flechaArriba.action.performed += EjecutarVidaFlecha;
        flechaArriba.action.Enable();
    }
    public void ActivarVida()
    {
        vidaActiva = true;
        btVida.interactable = true;

    }

    public void EjecutarVidaFlecha(InputAction.CallbackContext flecha)
    {
        EjecutarVida();
    }
    public void EjecutarVida()
    {

        vidaActiva = false;
        btVida.interactable = false;
        BarraDeVIda.barraVida.RecibirGolpe(-vida);
        
    }
    
    

}
