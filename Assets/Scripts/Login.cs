using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    public Server servidor;
    public TMP_InputField inpuUsuario;
    public TMP_InputField inpuPass;
    public GameObject imLoading;
    
   public void IniciarSesion()
    {
        StartCoroutine(Inicar());
    }

    IEnumerator Inicar()
    {
        imLoading.SetActive(true);
        string[] datos = new string[2];
        datos[0] = inpuUsuario.text;
        datos[1] = inpuPass.text;
        StartCoroutine(servidor.ConsumirServicio("login", datos,PosCargar));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() =>!servidor.ocupado);
        imLoading.SetActive(false);
    }
    IEnumerator Consultar()
    {
        imLoading.SetActive(true);
        string[] datos = new string[1];
        datos[0] = DatosUsuario.singleton.usuario.id.ToString();
        StartCoroutine(servidor.ConsumirServicio("consultar jugador", datos, PosCargar2));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        imLoading.SetActive(false);
    }
    public void PosCargar()
    {
        switch (servidor.respuesta.codigo)
        {
            case 204:// El usuario o la contraseña son incorrectos
                print("Usuario o contraseña incorrectos");
                break;  
            case 205: // Inicio de sesion correcto
                print(servidor.respuesta.respuesta.Replace("#", "\""));
                DatosUsuario.singleton.usuario = JsonUtility.FromJson<Usuario>(servidor.respuesta.respuesta.Replace("#", "\""));
                StartCoroutine(Consultar());
                break;
            case 402: // Faltan datos para ejecutar la accion solicitada
                print(servidor.respuesta.mensaje);
                break;
            case 404: // Error
                print("Error, no se puede conectar con el servidor");
                break;

            default:
                break;
        }
    }
    public void PosCargar2()
    {
        switch (servidor.respuesta.codigo)
        {
           
            case 207: // datos de jugador correctamente cargados
                DatosUsuario.singleton.jugador = JsonUtility.FromJson<Jugador>(servidor.respuesta.respuesta.Replace("#", "\""));
                SceneManager.LoadScene("TierraMedia");

                break;
            case 402: // Faltan datos para ejecutar la accion solicitada
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
