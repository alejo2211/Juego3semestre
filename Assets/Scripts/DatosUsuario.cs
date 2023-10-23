using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DatosUsuario : MonoBehaviour
{
    public static DatosUsuario singleton;
    public Usuario usuario;
    public Jugador jugador;
    public Server servidor;
    private void Awake()
    {
        if (singleton==null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void ActualizarDatos(int puntos, int oleadas)
    {
        if (puntos>jugador.puntos)
        {
            StartCoroutine(Actualizar(puntos, oleadas));
        }
    }

    IEnumerator Actualizar(int puntos, int oleadas)
    {
        
        string[] datos = new string[3];
        datos[0] = jugador.id.ToString();
        datos[1] = puntos.ToString();
        datos[2] = oleadas.ToString();
        StartCoroutine(servidor.ConsumirServicio("actualizar jugador", datos, PosCargar));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        
    }
    public void PosCargar()
    {
        switch (servidor.respuesta.codigo)
        {
            case 204:// El usuario o la contraseña son incorrectos
                print("Usuario o contraseña incorrectos");
                break;
            case 208: // Datos actualizados con exito
                SceneManager.LoadScene("Menu");
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
}
