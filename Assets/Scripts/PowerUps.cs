using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class PowerUps : MonoBehaviour
{
    public static PowerUps powerUps;
    public bool vidaActiva;
    public bool da�oDobleActiva;
    public bool da�oRapidoActiva;
    public bool municionActiva;
    public bool temporadaDa�oDoble;
    public bool temporadaRapida;
    public Button btVida;
    public Button btDa�oDoble;
    public Button btDa�oRapido;
    public Button btMunicion;
    public InputActionProperty flechaArriba;
    public InputActionProperty botonIzquierdo;
    public InputActionProperty botonAbajo;
    public InputActionProperty botonDerecho;
    public Image imTiempoDa�oDoble;
    public Image imTiempoDa�oRapido;
    public int vida=15;
    public TextMeshProUGUI municionTexto;
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
        if (vidaActiva)
        {
            vidaActiva = false;
            btVida.interactable = false;
            BarraDeVIda.barraVida.RecibirGolpe(-vida);
        }

    }
    public void ActivarBalasDobles()
    {
        da�oDobleActiva = true;
        btDa�oDoble.interactable = true;

    }
    public void EjecutarBalasDobles()
    {
        if (da�oDobleActiva)
        {
            da�oDobleActiva = false;
            btDa�oDoble.interactable = false;
            temporadaDa�oDoble = true;
            StartCoroutine(DesactivarTemporadaDoble());

        }
    }
    public IEnumerator DesactivarTemporadaDoble()
    {
        float tiempo = 8;

        for (int i = 20; i >= 0; i--)
        {

            imTiempoDa�oDoble.fillAmount = i / 20f;
            yield return new WaitForSeconds((tiempo/20f));
        }
        temporadaDa�oDoble = false;
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
        if (da�oRapidoActiva)
        {
            da�oRapidoActiva = false;
            btDa�oRapido.interactable = false;
            temporadaRapida = true;
            PlayerController.singleton.shot.modificador = 0.5f;
            Invoke("DesactivarBalasDobles", 5f);
            StartCoroutine(DesactivarTemporadaRapida());
        }

    }
    public IEnumerator DesactivarTemporadaRapida()
    {
        float tiempo = 8;

        for (int i = 20; i >= 0; i--)
        {

            imTiempoDa�oRapido.fillAmount = i / 20f;
            yield return new WaitForSeconds((tiempo / 20f));
        }
        temporadaRapida = false;
    }
    void DesactivarBalasDobles()
    {
        PlayerController.singleton.shot.modificador = 1;
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

    public void ContadorMunicion()
    {
        municionTexto.text =   Shot.shot.cantidadBalas.ToString();
    }





}
