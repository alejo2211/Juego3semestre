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
    public bool dañoDobleActiva;
    public bool dañoRapidoActiva;
    public bool municionActiva;
    public bool temporadaDañoDoble;
    public bool temporadaRapida;
    public Button btVida;
    public Button btDañoDoble;
    public Button btDañoRapido;
    public Button btMunicion;
    public InputActionProperty flechaArriba;
    public InputActionProperty botonIzquierdo;
    public InputActionProperty botonAbajo;
    public InputActionProperty botonDerecho;
    public Image imTiempoDañoDoble;
    public Image imTiempoDañoRapido;
    public int vida=15;
    public TextMeshProUGUI municionTexto;
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
        dañoDobleActiva = true;
        btDañoDoble.interactable = true;

    }
    public void EjecutarBalasDobles()
    {
        if (dañoDobleActiva)
        {
            dañoDobleActiva = false;
            btDañoDoble.interactable = false;
            temporadaDañoDoble = true;
            StartCoroutine(DesactivarTemporadaDoble());

        }
    }
    public IEnumerator DesactivarTemporadaDoble()
    {
        float tiempo = 8;

        for (int i = 20; i >= 0; i--)
        {

            imTiempoDañoDoble.fillAmount = i / 20f;
            yield return new WaitForSeconds((tiempo/20f));
        }
        temporadaDañoDoble = false;
    }
    public void EjecutarBalasDobles(InputAction.CallbackContext balas)
    {
        print("balas dobles");
        EjecutarBalasDobles();
    }

    public void ActivarBalasRapidas()
    {
        dañoRapidoActiva = true;
        btDañoRapido.interactable = true;
    }

    public void EjecutandoBalasRapidas()
    {
        if (dañoRapidoActiva)
        {
            dañoRapidoActiva = false;
            btDañoRapido.interactable = false;
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

            imTiempoDañoRapido.fillAmount = i / 20f;
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
        municionTexto.text = "Tu magia: " + Shot.shot.cantidadBalas.ToString();
    }





}
