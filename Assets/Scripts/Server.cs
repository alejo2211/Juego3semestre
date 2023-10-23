using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="Servidor",menuName = "Monky/Servidor",order =1)]
public class Server : ScriptableObject
{
    public string servidor;
    public Servicio[] servicios;
    public bool ocupado = false;
    public Respuesta respuesta;
    public IEnumerator ConsumirServicio(string nombre, string[] datos,UnityAction e) 
    {
        ocupado = true;
        WWWForm formulario = new WWWForm();
        Servicio s = new Servicio();
        string parametros = "?";
        for (int i = 0; i < servicios.Length; i++)
        {
            if (servicios[i].nombre.Equals(nombre))
            {
                s = servicios[i];
            }
        }
        for (int i = 0; i < s.parametros.Length; i++)
        {
            formulario.AddField(s.parametros[i], datos[i]);
            if (i>0)
            {
                parametros += "&";
            }
            parametros += s.parametros[i] + "=" + datos[i];
        }

        UnityWebRequest www = UnityWebRequest.Get(servidor + "/" + s.URL + parametros);
        Debug.Log(servidor + "/" + s.URL + parametros);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            respuesta = new Respuesta();
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            respuesta = JsonUtility.FromJson<Respuesta>(www.downloadHandler.text);
        }
        ocupado = false;
        e.Invoke();
    }
}

[System.Serializable]
public class Servicio
{
    public string nombre;
    public string URL;
    public string[] parametros;
}[System.Serializable]
public class Respuesta
{
    public int codigo;
    public string mensaje;
    public string respuesta;
    public Respuesta()
    {
        codigo = 404;
        mensaje = "Error";
    }
}

[System.Serializable]
public class Usuario
{
    public int id;
    public string pass;
    public string usuario;
}
[System.Serializable]
public class Jugador
{
    public int id;
    public int id_usuario;
    public int puntos;
    public int oleadas;
}