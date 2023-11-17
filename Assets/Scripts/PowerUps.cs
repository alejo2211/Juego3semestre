using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class PowerUps : MonoBehaviour
{
    public static PowerUps powerUps;
    public bool vidaActiva;
    public bool da�oDobleActiva;
    public bool da�oRapidoActiva;
    public bool municionActiva;
    public Button btVida;
    public Button btDa�oDoble;
    public Button btDa�oRapido;
    public Button btMunicion;
    public InputActionProperty flechaArriba;
    public InputActionProperty botonIzquierdo;
    public InputActionProperty botonAbajo;
    public InputActionProperty botonDerecho;
    public int vida=15;
    private void Awake()
    {
        powerUps = this;
        btVida.interactable = false;
        btDa�oDoble.interactable = false;
        btDa�oRapido.interactable = false;
        btMunicion.interactable = false;
    }
    private void Start()
    {
        flechaArriba.action.performed += EjecutarVidaFlecha;
        flechaArriba.action.Enable();
        botonIzquierdo.action.performed += EjecutarBalasDobles;
        botonIzquierdo .action.Enable();
        botonAbajo.action.performed += EjecutarBalasRapidas;
        botonAbajo.action.Enable();
        botonDerecho.action.performed += EjecutarMunicion;
        botonDerecho.action.Enable();
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
    public void ActivarBalasDobles()
    {
        da�oDobleActiva = true;
        btDa�oDoble.interactable = true;

    }
    public void EjecutarBalasDobles()
    {
        da�oDobleActiva = false;
        btDa�oDoble.interactable = false;
        
    }
    public void EjecutarBalasDobles(InputAction.CallbackContext balas)
    {
        print("balas dobles");
        EjecutarBalasDobles();
    }

    public void ActivarBalasRapidas()
    {
        da�oRapidoActiva = true;
        btDa�oRapido.interactable = true;
    }

    public void EjecutandoBalasRapidas()
    {
        da�oRapidoActiva = false;
        btDa�oRapido.interactable = false;
    }

    public void EjecutarBalasRapidas(InputAction.CallbackContext rapidas)
    {
        print("balas rapidasa");
        EjecutandoBalasRapidas();
    }

    public void ActivarMunicion()
    {
        municionActiva = true;
        btMunicion.interactable = true;
    }

    public void EjecutandoMunicion()
    {
        municionActiva = false;
        btMunicion.interactable = false;
    }

    public void EjecutarMunicion(InputAction.CallbackContext municion)
    {
        print("municion");
        EjecutandoMunicion();
    }





}
