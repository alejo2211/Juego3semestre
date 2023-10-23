using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Registro : MonoBehaviour
{
    public Server servidor;
    public TMP_InputField inpuNuevoUsuario;
    public TMP_InputField inpuNuevaPass;
    public TMP_InputField inpuConfirmadaPass;
    public GameObject imLoading;
    public GameObject panelLogin;
    public GameObject panelRegister;

    public void RegistrarUsuario()
    {
        StartCoroutine(Registrar());
    }
    public IEnumerator Registrar()
    {
        if (inpuNuevaPass.text!=inpuConfirmadaPass.text)
        {
            Debug.LogWarning("Error las contraseñas son diferentes");
        }
        else
        {
            imLoading.SetActive(true);
            string[] datos = new string[2];
            datos[0] = inpuNuevoUsuario.text;
            datos[1] = inpuNuevaPass.text;
            StartCoroutine(servidor.ConsumirServicio("reg_usuario", datos, PosCargar));
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => !servidor.ocupado);
            imLoading.SetActive(false);
        }
    }
    public void PosCargar()
    {
        switch (servidor.respuesta.codigo)
        {
            case 204:// El usuario o la contraseña son incorrectos
                print("Usuario o contraseña incorrectos");
                break;
            case 201: // Inicio de sesion correcto
                panelRegister.SetActive(false);
                panelLogin.SetActive(true);
                SceneManager.LoadScene("Tierra Media");

                break;
            case 402: // Faltan datos para ejecutar la accion solicitada
                print(servidor.respuesta.mensaje);
                break;
            case 401: //  Error intentando crear un usuario
                print(servidor.respuesta.mensaje);
                break;
            case 400: // Error intentando conectar
                print(servidor.respuesta.mensaje);
                break;
            case 404: // Error
                print("Error, no se puede conectar con el servidor");
                break;

            default:
                break;
        }
    }


}
