using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlInterfaz : MonoBehaviour
{
    public InputActionProperty botonPausa;
    public GameObject menuUI;


    public void Start()
    {
        botonPausa.action.Enable();
        botonPausa.action.performed += Pausar;
    }

     void Pausar(InputAction.CallbackContext context)
    {
        EjecutarPausa();
    }

    public void EjecutarPausa()
    {
        menuUI.SetActive(!menuUI.activeSelf);
    }
}
